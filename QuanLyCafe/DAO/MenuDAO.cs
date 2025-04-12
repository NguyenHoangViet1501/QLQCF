using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;
using QuanLyCafe.DAO;

namespace QuanLyCafe.DAO
{
    public class MenuDAO
    {
       DBModelDataContext _context = new DBModelDataContext();  

       public FunctionResult<List<Menu>> GetListMenuByTable(string id)
       {
            FunctionResult<List<Menu>> rs = new FunctionResult<List<Menu>>();
            try
            {

                var query = from bi in _context.BillInfos
                            join b in _context.Bills on bi.BillID equals b.BillID
                            join f in _context.Foods on bi.FoodID equals f.FoodID
                            where b.Status == 0 && b.TableFoodID == id
                            select new Menu
                            {
                                FoodName = f.Name,
                                Count = bi.Count,
                                Price = f.Price,
                                TotalPrice = f.Price * bi.Count
                            };
                if (!query.Any())
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Danh sách thực đơn rỗng";
                    rs.Data = null;
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Lấy danh sách thành công";
                    rs.Data = query.ToList();
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

    }
}
