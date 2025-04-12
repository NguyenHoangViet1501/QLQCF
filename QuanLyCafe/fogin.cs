using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.DTO;
using QuanLyCafe.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCafe
{
    public partial class fogin : Form
    {
        DBModelDataContext _db = new DBModelDataContext();
        public Account crrUser;
        public fogin()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string userName = accTextBox.Text;
            string password = passTextBox.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Login(userName, password))
            {
                
                crrUser = _db.Accounts.FirstOrDefault(u => u.UserName == userName && u.Password == password);

                fTableManager fTableManager = new fTableManager(crrUser);
                this.Hide();
                fTableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        bool Login(string userName, string password)
        {
            LoginDAO loginDAO = new LoginDAO();
            if (loginDAO.checkLogin(userName, password))
            {
               return true;
            }
            else
            {
                return false;
            }

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fogin_Load(object sender, EventArgs e)
        {

        }

        private void fogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình?","Confirmation",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
