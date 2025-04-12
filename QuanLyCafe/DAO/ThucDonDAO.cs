using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DAO;
using System.Data.Linq;

namespace QuanLyCafe.DAO
{
    public class ThucDonDAO
    {
        DBModelDataContext _context = new DBModelDataContext();

        public FunctionResult<List<FoodWithCategoryDTO>> LoadListThucDon()
        {
            FunctionResult<List<FoodWithCategoryDTO>> rs = new FunctionResult<List<FoodWithCategoryDTO>>();
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.FoodCategories);
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Foods);
            try
            {
                var query = from f in _context.Foods
                                        join c in _context.FoodCategories on f.CategoryID equals c.CategoryID
                                        select new FoodWithCategoryDTO
                                        {
                                            FoodId = f.FoodID,
                                            Name = f.Name,
                                            CategoryName = c.Name,
                                            CategoryID = c.CategoryID,
                                            Price = (decimal)f.Price,
                                        };

                if (!query.Any())
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Danh sách thực đơn rỗng";
                    rs.Data = null;
                }
                else
                {
                    rs.ErrCode=EnumErrCode.Suceess;
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

        public FunctionResult<FoodWithCategoryDTO> AddFood(string FoodId, string name, string categoryID,decimal Price)
        {
            FunctionResult<FoodWithCategoryDTO> rs = new FunctionResult<FoodWithCategoryDTO>();

            try
            {
                Food newFoodObj = new Food();
                newFoodObj.FoodID = FoodId;
                newFoodObj.Name = name;
                newFoodObj.CategoryID = categoryID;
                newFoodObj.Price = (double)Price;
                
                _context.Foods.InsertOnSubmit(newFoodObj);
                _context.SubmitChanges();

                rs.ErrCode = EnumErrCode.Suceess;
                rs.Desc = "Thêm món thành công!";
                rs.Data = null;
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data= null;
            }
            return rs;
        }

        public FunctionResult<Food> EditFood(string foodID,string name,string categoryID,decimal price)
        {
            FunctionResult<Food> rs = new FunctionResult<Food>();

            try
            {
                var foodObj = GetFoodByID(foodID);
                if (foodObj == null)
                {
                    rs.ErrCode= EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy món!";
                    rs.Data = null;
                }else
                {
                    foodObj.FoodID = foodID;
                    foodObj.Name = name;
                    foodObj.CategoryID = categoryID;
                    foodObj.Price = (double)price;
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Sửa món thành công!";
                    rs.Data = foodObj;
                }
            }
            catch (Exception e)
            {
                rs.ErrCode =EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctionResult<Food> DeleteFood(string foodID)
        {
            FunctionResult<Food> rs = new FunctionResult<Food>();

            try
            {
                var foodObj = GetFoodByID(foodID);
                if (foodObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy món!";
                    rs.Data = null;
                }
                else
                {
                    _context.Foods.DeleteOnSubmit(foodObj);
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Xoá món thành công!";
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

        public FunctionResult<List<FoodWithCategoryDTO>> SearchFoodByName(string foodName)
        {
            FunctionResult<List<FoodWithCategoryDTO>> rs = new FunctionResult<List<FoodWithCategoryDTO>>();

            try
            {
                var query = from f in _context.Foods
                            join c in _context.FoodCategories on f.CategoryID equals c.CategoryID
                            where f.Name.Contains(foodName) 
                            select new FoodWithCategoryDTO
                            {
                                FoodId = f.FoodID,
                                Name = f.Name,
                                CategoryName = c.Name,
                                CategoryID = c.CategoryID,
                                Price = (decimal)f.Price,
                            };

                if (!query.Any())
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy món phù hợp!";
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

        public Food GetFoodByID(string foodID)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Foods);
            var foodObj = _context.Foods.FirstOrDefault(x=> x.FoodID == foodID);
            return foodObj;
        }
        public List<Food> GetFoodListByCategoryID(string id)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Foods);
            var list = _context.Foods.Where( x => x.CategoryID == id).ToList();
            return list;
        }

        public double getFoodPriceByID(string id)
        {
            _context.Refresh(RefreshMode.OverwriteCurrentValues, _context.Foods);
            var foodObj = _context.Foods.FirstOrDefault(x => x.FoodID == id);
            return foodObj.Price;
        }
    }
}
