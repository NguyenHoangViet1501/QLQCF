using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class fAddAccount : Form
    {
        AccountDAO accountDAO = new AccountDAO();
        public fAddAccount()
        {
            InitializeComponent();
        }

        private void addAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hienThiTextBox.Text) || string.IsNullOrEmpty(unameTextBox.Text)
                || string.IsNullOrEmpty(passConTextBox.Text) || string.IsNullOrEmpty(passTextBox.Text)
                || typeComboBox.SelectedIndex == -1 || string.IsNullOrEmpty(sdtTextBox.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passTextBox.Text != passConTextBox.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var rs = accountDAO.AddAccount(hienThiTextBox.Text, unameTextBox.Text, passTextBox.Text, typeComboBox.Text,sdtTextBox.Text);

            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Empty:
                    break;
                case DTO.EnumErrCode.Suceess:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void fAddAccount_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
