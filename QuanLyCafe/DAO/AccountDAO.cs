using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class AccountDAO
    {
        DBModelDataContext _context = new DBModelDataContext();

        public FunctionResult<List<Account>> LoadAccountList()
        {
            FunctionResult<List<Account>> rs = new FunctionResult<List<Account>>();
            try
            {
                var query = _context.Accounts;

                if (!query.Any())
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Danh sách tài khoản rỗng";
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

        public FunctionResult<Account> AddAccount(string displayName,string userName,string password,string Type,string sdt)
        {
            FunctionResult<Account> rs = new FunctionResult<Account>();

            try
            {
                Account accObj = new Account();
                accObj.AccountID = Guid.NewGuid().ToString();
                accObj.DisplayName = displayName;
                accObj.UserName = userName;
                accObj.Password = password;
                accObj.PhoneNum = sdt;
                if (String.Equals(Type,"Quản lý"))
                {
                    accObj.Type = 0;
                }else
                {
                    accObj.Type = 1;
                }

                _context.Accounts.InsertOnSubmit(accObj);
                _context.SubmitChanges();

                rs.ErrCode = EnumErrCode.Suceess;
                rs.Desc = "Thêm tài khoản thành công!";
                rs.Data = null;
            }
            catch (Exception e)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.Desc = e.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctionResult<Account> EditAccount(string accID, string tenHienThi,string sdt)
        {
            FunctionResult<Account> rs = new FunctionResult<Account>();

            try
            {
                var accObj = GetAccountByID(accID);
                if (accObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy tài khoản!";
                    rs.Data = null;
                }
                else
                {
                    accObj.DisplayName = tenHienThi;
                    accObj.PhoneNum = sdt;
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Sửa tài khoản thành công!";
                    rs.Data = accObj;
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

        public FunctionResult<Account> DeleteAccount(string accID)
        {
            FunctionResult<Account> rs = new FunctionResult<Account>();
            try
            {
                var accObj = GetAccountByID(accID);
                if (accObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy tài khoản!";
                    rs.Data = null;
                }
                else
                {
                    _context.Accounts.DeleteOnSubmit(accObj);
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Xoá tài khoản thành công!";
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

        public Account GetAccountByID(string ID)
        {
            var accObj = _context.Accounts.FirstOrDefault(x => x.AccountID == ID);
            return accObj;
        }

        public string getPasswordByID(string accID)
        {
            var accObj = _context.Accounts.FirstOrDefault(x => x.AccountID == accID);
            return accObj.Password;
        }

        public FunctionResult<Account> ResetPassword(string accID,string password)
        {
            FunctionResult<Account> rs = new FunctionResult<Account>();
            try
            {
                var accObj = GetAccountByID(accID);
                if (accObj == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.Desc = "Không tìm thấy tài khoản!";
                    rs.Data = null;
                }
                else
                {
                    accObj.Password = password;
                    _context.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Suceess;
                    rs.Desc = "Đặt lại mật khẩu thành công!";
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
    }
}
