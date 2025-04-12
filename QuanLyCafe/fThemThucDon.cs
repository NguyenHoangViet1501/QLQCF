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
    public partial class fThemThucDon : Form
    {
        DanhMucDAO danhMucDAO = new DanhMucDAO();
        ThucDonDAO thucDonDAO = new ThucDonDAO();
        public fThemThucDon()
        {
            InitializeComponent();
            loadCategoryComboBox();
        }

        private void loadCategoryComboBox()
        {
            var categoryList = danhMucDAO.getListFoodCategories();
            danhMucComboBox.DataSource = categoryList;
            danhMucComboBox.DisplayMember = "Name";
            danhMucComboBox.ValueMember = "CategoryID";
        }

        private void themMonBtn_Click(object sender, EventArgs e)
        {
            var price = (decimal)priceNumeric.Value;
            if (string.IsNullOrEmpty(monNameTextBox.Text) || price <= 0)
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string foodId = Guid.NewGuid().ToString();
            string name = monNameTextBox.Text;
            string categoryID = danhMucComboBox.SelectedValue.ToString();
            var foodPrice = price;

            var rs = thucDonDAO.AddFood(foodId,name,categoryID,foodPrice);

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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void priceNumeric_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
