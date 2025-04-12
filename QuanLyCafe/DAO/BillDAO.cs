using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillDAO
    {
        DBModelDataContext _context = new DBModelDataContext();
        public FunctionResult<string> GetUncheckBillIDByTableID(string id)
        {
            DBModelDataContext _context = new DBModelDataContext();
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Bills);

            FunctionResult<string> result = new FunctionResult<string>();
            try
            {
                
                var bill = _context.Bills.FirstOrDefault(b => b.TableFoodID == id && b.Status == 0);

                if (bill != null)
                {
                    
                    result.ErrCode = EnumErrCode.Suceess;
                    result.Desc = "Hóa đơn chưa thanh toán được tìm thấy.";
                    result.Data = bill.BillID; 
                }
                else
                {
                    
                    result.ErrCode = EnumErrCode.Empty;
                    result.Desc = "Không có hóa đơn chưa thanh toán.";
                    result.Data = null; 
                }
            }
            catch (Exception ex)
            {
                
                result.ErrCode = EnumErrCode.Error;
                result.Desc = "Lỗi trong quá trình truy vấn: " + ex.Message;
                result.Data = null; 
            }

            return result;
        }

        public FunctionResult<Bill> CreateBill(string tableID)
        {
            try
            {
                Bill newBill = new Bill
                {
                    BillID = Guid.NewGuid().ToString(),
                    DateCheckIn = DateTime.Now,
                    DateCheckOut = null,
                    TableFoodID = tableID,
                    Status = 0,
                };

                _context.Bills.InsertOnSubmit(newBill);
                _context.SubmitChanges();

                // Cập nhật trạng thái bàn
                var tableFood = _context.TableFoods.FirstOrDefault(t => t.TableFoodId == tableID);
                if (tableFood != null)
                {
                    tableFood.Status = "Có người";
                    _context.SubmitChanges();
                }

                return new FunctionResult<Bill>
                {
                    ErrCode = EnumErrCode.Suceess,
                    Desc = "New Bill inserted successfully.",
                    Data = newBill
                };
            }
            catch (Exception ex)
            {
                return new FunctionResult<Bill>
                {
                    ErrCode = EnumErrCode.Error,
                    Desc = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }
        public FunctionResult<bool> CheckOut(string billID, float totalPrice,int discount)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Bills);
            try
            {
                var bill = _context.Bills.FirstOrDefault(b => b.BillID == billID);

                if (bill == null)
                {
                    return new FunctionResult<bool>
                    {
                        ErrCode = EnumErrCode.Error,
                        Desc = "Không thấy bill(null).",
                        Data = false
                    };
                }
                bill.Discount = discount;
                bill.DateCheckOut = DateTime.Now;
                bill.Status = 1; // Đã thanh toán
                bill.TotalPrice = totalPrice;

                _context.SubmitChanges();

                var table = _context.TableFoods.FirstOrDefault(t => t.TableFoodId == bill.TableFoodID);

                if (table != null)
                {
                    table.Status = "Trống";  
                }
                _context.SubmitChanges();

                return new FunctionResult<bool>
                {
                    ErrCode = EnumErrCode.Suceess,
                    Desc = "Thanh toán thành công.",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new FunctionResult<bool>
                {
                    ErrCode = EnumErrCode.Error,
                    Desc = $"Lỗi: {ex.Message}",
                    Data = false
                };
            }
        }

    }
}
