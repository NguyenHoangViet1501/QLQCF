using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class FoodWithCategoryDTO
    {
        public string FoodId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string CategoryID { get; set; }
        public decimal Price { get; set; }
    }
}
