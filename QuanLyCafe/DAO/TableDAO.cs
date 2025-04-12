using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class TableDAO
    {
        DBModelDataContext _context = new DBModelDataContext();

        public static int tableWidth = 115;
        public static int tableHeight = 115;

        public FunctionResult<List<TableFood>> LoadTableList()
        {
            FunctionResult<List<TableFood>> rs = new FunctionResult<List<TableFood>>();
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.TableFoods);
            try
            {
                var qr = _context.TableFoods;
                if (qr.Any())
                {
                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Lấy dữ liệu thành công";
                    rs.Data = qr.ToList();
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "List rỗng";
                    rs.Data = null;
                }
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }
        // Load danh sách bàn ăn
        public FunctionResult<List<TableFood>> LoadTableList1()
        {

            try
            {
                _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.TableFoods);
                // Lấy danh sách bảng
                var tables = _context.TableFoods.ToList();

                if (tables.Count > 0)
                {
                    return new FunctionResult<List<TableFood>>
                    {
                        ErrCode = EnumErrCode.Suceess,
                        Desc = "Lấy dữ liệu thành công",
                        Data = tables
                    };
                }

                return new FunctionResult<List<TableFood>>
                {
                    ErrCode = EnumErrCode.Empty,
                    Desc = "Không có bảng nào.",
                    Data = new List<TableFood>() // Trả về danh sách rỗng thay vì null
                };
            }
            catch (Exception e)
            {
                return new FunctionResult<List<TableFood>>
                {
                    ErrCode = EnumErrCode.Error,
                    Desc = $"Lỗi: {e.Message}",
                    Data = null
                };
            }
        }


        // Thêm mới bàn ăn
        public FunctionResult<TableFood> AddNewTable(string id, string name, string status)
        {
            FunctionResult<TableFood> rs = new FunctionResult<TableFood>();
            try
            {
                // Tạo mới đối tượng TableFood
                TableFood table = new TableFood();
                table.TableFoodId = Guid.NewGuid().ToString(); // ID tự động tạo
                table.Name = name;
                table.Status = status; // Trạng thái bàn ăn, có thể là "Trống" hoặc "Đã Đặt"

                // Thêm vào cơ sở dữ liệu
                _context.TableFoods.InsertOnSubmit(table);
                _context.SubmitChanges();

                rs.ErrCode = EnumErrCode.Suceess;
                rs.Desc = "Thêm bàn ăn thành công";
                rs.Data = table;
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }

        // Sửa bàn ăn
        public FunctionResult<TableFood> EditTable(string idBanAn, string tenBanAn, string trangThai)
        {
            FunctionResult<TableFood> rs = new FunctionResult<TableFood>();
            try
            {
                var table = _context.TableFoods.FirstOrDefault(t => t.TableFoodId == idBanAn);
                if (table == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy bàn ăn";
                    rs.Data = null;
                }
                else
                {
                    table.Name = tenBanAn;
                    table.Status = trangThai;
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Sửa bàn ăn thành công";
                    rs.Data = table;
                }
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }

        // Xóa bàn ăn
        public FunctionResult<bool> DeleteTable(string idBanAn)
        {
            FunctionResult<bool> rs = new FunctionResult<bool>();
            try
            {
                var table = _context.TableFoods.FirstOrDefault(t => t.TableFoodId == idBanAn);
                if (table == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy bàn ăn để xóa";
                    rs.Data = false;
                }
                else
                {
                    _context.TableFoods.DeleteOnSubmit(table);
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Xóa bàn ăn thành công";
                    rs.Data = true;
                }
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = false;
            }
            return rs;
        }
        public TableFood GetTableByIdAndStatus(string idBanAn, string name, string status)
        {
            return _context.TableFoods
                .FirstOrDefault(t => t.TableFoodId == idBanAn && t.Name == name && t.Status == status);
        }

        public List<TableFood> getTableList()
        {
            return _context.TableFoods.ToList();
        }

        public FunctionResult<bool> SwitchTable(string tableId1, string tableId2)
        {
            try
            {
                using (var context = new DBModelDataContext())
                {
                    // Lấy hóa đơn chưa thanh toán của hai bàn
                    var firstBill = context.Bills.FirstOrDefault(b => b.TableFoodID == tableId1 && b.Status == 0);
                    var secondBill = context.Bills.FirstOrDefault(b => b.TableFoodID == tableId2 && b.Status == 0);

                    // Nếu bàn 1 chưa có hóa đơn, tạo mới
                    if (firstBill == null)
                    {
                        firstBill = new Bill
                        {
                            BillID = Guid.NewGuid().ToString(),  // Sử dụng GUID làm ID
                            TableFoodID = tableId1,
                            DateCheckIn = DateTime.Now,
                            Status = 0
                        };
                        context.Bills.InsertOnSubmit(firstBill);
                        context.SubmitChanges();  // Chú ý gọi SubmitChanges để lưu vào DB
                    }

                    // Nếu bàn 2 chưa có hóa đơn, tạo mới
                    if (secondBill == null)
                    {
                        secondBill = new Bill
                        {
                            BillID = Guid.NewGuid().ToString(),  // Sử dụng GUID làm ID
                            TableFoodID = tableId2,
                            DateCheckIn = DateTime.Now,
                            Status = 0
                        };
                        context.Bills.InsertOnSubmit(secondBill);
                        context.SubmitChanges();  // Chú ý gọi SubmitChanges để lưu vào DB
                    }

                    // Hoán đổi các BillInfo giữa hai hóa đơn
                    var firstBillDetails = context.BillInfos.Where(bi => bi.BillID == firstBill.BillID).ToList();
                    var secondBillDetails = context.BillInfos.Where(bi => bi.BillID == secondBill.BillID).ToList();

                    foreach (var detail in firstBillDetails)
                    {
                        detail.BillID = secondBill.BillID;
                    }

                    foreach (var detail in secondBillDetails)
                    {
                        detail.BillID = firstBill.BillID;
                    }

                    context.SubmitChanges();

                    // Cập nhật trạng thái bàn 1 thành "Trống"
                    var table1 = context.TableFoods.FirstOrDefault(t => t.TableFoodId == tableId1);
                    if (table1 != null)
                    {
                        table1.Status = "Trống";  // Cập nhật bàn 1 thành "Trống"
                    }

                    // Cập nhật trạng thái bàn 2 thành "Có người"
                    var table2 = context.TableFoods.FirstOrDefault(t => t.TableFoodId == tableId2);
                    if (table2 != null)
                    {
                        table2.Status = "Có người";  // Cập nhật bàn 2 thành "Có người"
                    }

                    context.SubmitChanges();

                    return new FunctionResult<bool>
                    {
                        ErrCode = EnumErrCode.Suceess,
                        Desc = "Chuyển bàn thành công.",
                        Data = true
                    };
                }
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
