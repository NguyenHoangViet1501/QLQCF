using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    internal class LoginDAO 
    {
        DBModelDataContext _context = new DBModelDataContext();
        public LoginDAO() { }

        public bool checkLogin(string username, string password)
        {
            var user = _context.Accounts.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
