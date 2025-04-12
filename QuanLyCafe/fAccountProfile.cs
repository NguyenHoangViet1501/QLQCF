using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class fAccountProfile : Form
    {
        public Account logined;
        AccountDAO accountDAO = new AccountDAO();

        public fAccountProfile(Account user)
        {
            InitializeComponent();
            logined = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(oldPassTextBox.Text) || string.IsNullOrEmpty(passTextBox.Text) || string.IsNullOrEmpty(reEnterPassTextBox.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!string.Equals(oldPassTextBox.Text, accountDAO.getPasswordByID(logined.AccountID)))
                {
                    MessageBox.Show("Sai mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!string.Equals(passTextBox.Text, reEnterPassTextBox.Text))
                {
                    MessageBox.Show("Mật khẩu mới không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rs = accountDAO.ResetPassword(logined.AccountID, passTextBox.Text);

                switch (rs.ErrCode)
                {
                    case EnumErrCode.Error:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case EnumErrCode.Empty:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case EnumErrCode.Suceess:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        break;
                    default:
                        break;
                }
            

        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            accTextBox.Text = logined.UserName;
            usernameTextBox.Text = logined.DisplayName;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void accTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
