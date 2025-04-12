using QuanLyCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fThemDanhMuc : Form
    {
        public fThemDanhMuc()
        {
            InitializeComponent();
        }

        private void themDanhMucBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(danhMucTextBox.Text))
            {
                MessageBox.Show("Tên danh mục trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            var rs = danhMucDAO.AddNewCategory(danhMucTextBox.Text);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
