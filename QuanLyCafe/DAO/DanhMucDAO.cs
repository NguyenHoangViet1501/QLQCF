using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class DanhMucDAO
    {
        DBModelDataContext _context = new DBModelDataContext();

        public FunctionResult<FoodCategory> AddNewCategory(string danhMucName)
        {
            FunctionResult<FoodCategory> rs = new FunctionResult<FoodCategory>();
            try
            {
                FoodCategory ctgObj = new FoodCategory();
                ctgObj.CategoryID = Guid.NewGuid().ToString();
                ctgObj.Name = danhMucName;
                _context.FoodCategories.InsertOnSubmit(ctgObj);
                _context.SubmitChanges();

                rs.ErrCode = EnumErrCode.Suceess;
                rs.Desc = "Danh Mục thêm thành công";
                rs.Data = ctgObj;
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctionResult<List<FoodCategory>> LoadDanhMucList()
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.FoodCategories);
            FunctionResult<List<FoodCategory>> rs = new FunctionResult<List<FoodCategory>>();

            try
            {
                var qr = _context.FoodCategories;
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

        public FunctionResult<FoodCategory> EditCategory(string id,string name)
        {
            FunctionResult<FoodCategory> rs = new FunctionResult<FoodCategory>();
            try
            {
                var ctgObj = findCategoryByID(id);
                if (ctgObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy danh mục";
                    rs.Data = null;
                }else
                {
                    ctgObj.Name = name;
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Sửa danh mục thành công";
                    rs.Data = ctgObj;
                }
            }
            catch (Exception e)
            {
                rs.Desc += e.Message;
                rs.Data = null;
                rs.ErrCode = EnumErrCode.Error;
            }
            return rs;
        }

        public FunctionResult<FoodCategory> DeleteCategory(string id)
        {
            FunctionResult<FoodCategory> rs = new FunctionResult<FoodCategory>();
            try
            {
                var ctgObj = findCategoryByID(id);
                if (ctgObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy danh mục";
                    rs.Data = null;
                }else
                {
                    _context.FoodCategories.DeleteOnSubmit(ctgObj);
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Xoá danh mục thành công";
                    rs.Data = ctgObj;
                } 
            }
            catch (Exception e)
            {
                rs.Desc += e.Message;
                rs.Data = null;
                rs.ErrCode = EnumErrCode.Error;
            }
            return rs;
        }

        public FoodCategory findCategoryByID(string id)
        {
            var ctgObj = _context.FoodCategories.FirstOrDefault(x => x.CategoryID == id);
            return ctgObj;
        }

        public List<FoodCategory> getListFoodCategories()
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.FoodCategories);
            return _context.FoodCategories.ToList();
        }

        public string getCategoryByName(string name)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.FoodCategories);
            var foodCategoryObj = _context.FoodCategories.FirstOrDefault(c => c.Name == name);
            return foodCategoryObj.CategoryID;
        }
        public FunctionResult<List<FoodCategory>> SearchCategoryByName(string categoryName)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.FoodCategories);
            FunctionResult<List<FoodCategory>> rs = new FunctionResult<List<FoodCategory>>();

            try
            {
                var query = _context.FoodCategories
                    .Where(fc => fc.Name.Contains(categoryName))
                    .ToList()
                    .Select(fc => new FoodCategory
                    {
                        CategoryID = fc.CategoryID,
                        Name = fc.Name,
                    })
                    .ToList();

                if (!query.Any())
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy danh mục phù hợp!";
                    rs.Data = null;
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Lấy danh sách thành công";
                    rs.Data = query;
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
