using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Menu
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; } 
        public double TotalPrice { get; set; }
    }
}
