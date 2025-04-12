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

namespace QuanLyCafe
{
    public partial class fThemBanAn : Form
    {
        public fThemBanAn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
                // Kiểm tra tên bàn ăn
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Tên bàn ăn trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng TableDAO và gọi phương thức AddTable
                TableDAO tableDAO = new TableDAO();
                string status = "Trống"; // Set trạng thái bàn ăn mặc định là "Trống"
                var rs = tableDAO.AddNewTable(Guid.NewGuid().ToString(), textBox1.Text, status);

                // Xử lý kết quả trả về từ AddTable
                switch (rs.ErrCode)
                {
                    case DTO.EnumErrCode.Error:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case DTO.EnumErrCode.Empty:
                        break;
                    case DTO.EnumErrCode.Suceess:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Đóng form sau khi thêm bàn ăn thành công
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
        
    }
}
