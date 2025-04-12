using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class BillInfoDAO
    {
        DBModelDataContext _context = new DBModelDataContext();
        ThucDonDAO thucDonDAO = new ThucDonDAO();
        public FunctionResult<BillInfo> InsertBillInfo(string idBill, string idFood, int count)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.BillInfos);
            try
            {
                var existingBillInfo = _context.BillInfos
                    .FirstOrDefault(b => b.BillID == idBill && b.FoodID == idFood);

                if (existingBillInfo != null)
                {
                    // Cập nhật số lượng nếu BillInfo đã tồn tại
                    existingBillInfo.Count += count;

                    if (existingBillInfo.Count > 0)
                    {
                        _context.SubmitChanges();
                        return new FunctionResult<BillInfo>
                        {
                            ErrCode = EnumErrCode.Suceess,
                            Desc = "BillInfo updated successfully.",
                            Data = existingBillInfo
                        };
                    }
                    else
                    {
                        _context.BillInfos.DeleteOnSubmit(existingBillInfo);
                        _context.SubmitChanges();
                        return new FunctionResult<BillInfo>
                        {
                            ErrCode = EnumErrCode.Suceess,
                            Desc = "BillInfo deleted successfully.",
                            Data = null
                        };
                    }
                }
                else
                {
                    var foodPrice = thucDonDAO.getFoodPriceByID(idFood);

                    // Thêm mới BillInfo nếu chưa tồn tại
                    BillInfo newBillInfo = new BillInfo
                    {
                        BillInfoID = Guid.NewGuid().ToString(),
                        BillID = idBill,
                        FoodID = idFood,
                        Count = count,
                        Price = foodPrice * count
                    };

                    _context.BillInfos.InsertOnSubmit(newBillInfo);
                    _context.SubmitChanges();

                    return new FunctionResult<BillInfo>
                    {
                        ErrCode = EnumErrCode.Suceess,
                        Desc = "BillInfo inserted successfully.",
                        Data = newBillInfo
                    };
                }
            }
            catch (Exception ex)
            {
                return new FunctionResult<BillInfo>
                {
                    ErrCode = EnumErrCode.Error,
                    Desc = $"Lỗi: {ex.Message}",
                    Data = null
                };
            }
        }


    }
}
