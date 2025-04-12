using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fAdmin : Form
    {
        DanhMucDAO danhMucDAO = new DanhMucDAO();
        ThucDonDAO thucDonDAO = new ThucDonDAO();
        AccountDAO accountDAO = new AccountDAO();
        DoanhThuDAO doanhThuDAO = new DoanhThuDAO();
        TableDAO tableDAO = new TableDAO();
        public fAdmin()
        {
            InitializeComponent();
        }
        private void fAdmin_Load(object sender, EventArgs e)
        {
            //DANH MUC
            LoadListDanhMuc();
            AddDanhMucBinding();
            //THUCDON
            LoadThucDonData();
            AddThucDonBinding();
            LoadFoodCategories();
            //TAIKHOAN
            LoadAccountData();
            AddAccountBinding();
            //BANAN
            LoadListBanAn();
            AddBananBinding();

     
        }
        #region Trash

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Danh Mục
        private void btnSearchCategory_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearchCategory.Text))
            {
                MessageBox.Show("Vui lòng nhập danh mục cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = danhMucDAO.SearchCategoryByName(txbSearchCategory.Text);
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Suceess:
                    dtgvDanhMuc.DataSource = rs.Data;
                    dtgvDanhMuc.ReadOnly = true;
                    dtgvDanhMuc.Columns["CategoryID"].Visible = false;
                    dtgvDanhMuc.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    RefreshDanhMucBinding();
                    break;
                default:
                    break;
            }
        }

        private void themDanhMucBtn_Click(object sender, EventArgs e)
        {
            fThemDanhMuc f = new fThemDanhMuc();
            f.ShowDialog();
            LoadListDanhMuc();
            RefreshDanhMucBinding();
        }

        public void LoadListDanhMuc()
        {
            DanhMucDAO dao = new DanhMucDAO();
            var rs = dao.LoadDanhMucList();
            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Suceess:
                    dtgvDanhMuc.DataSource = rs.Data;
                    dtgvDanhMuc.Columns["CategoryID"].Visible = false;
                    dtgvDanhMuc.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                default:
                    break;
            }
        }

        public void AddDanhMucBinding()
        {
            idDanhMucTextBox.DataBindings.Add(new Binding("Text", dtgvDanhMuc.DataSource, "CategoryID"));
            danhMucTextBox.DataBindings.Add(new Binding("Text", dtgvDanhMuc.DataSource, "Name"));
        }

        private void suaDanhMucBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(danhMucTextBox?.Text))
            {
                MessageBox.Show("Không đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = danhMucDAO.EditCategory(idDanhMucTextBox.Text,danhMucTextBox.Text);
            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Suceess:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    LoadListDanhMuc();
                    RefreshDanhMucBinding();
                    break;
                default:
                    break;
            }
        }

        private void xoaDanhMucBtn_Click(object sender, EventArgs e)
        {
            var rs = danhMucDAO.DeleteCategory(idDanhMucTextBox.Text);
            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Suceess:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    LoadListDanhMuc();
                    RefreshDanhMucBinding();
                    break;
                default:
                    break;
            }
        }

        private void dtgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            suaThucDonBtn.Visible = true;
            xoaThucDonBtn.Visible = true;
        }

        private void RefreshDanhMucBinding()
        {
            idDanhMucTextBox.DataBindings.Clear();
            danhMucTextBox.DataBindings.Clear();
            AddDanhMucBinding();
        }

        #endregion

        #region Thực đơn
        private void LoadThucDonData()
        {
            var rs = thucDonDAO.LoadListThucDon();
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Suceess:
                    dtgvThucDon.DataSource = rs.Data;
                    dtgvThucDon.ReadOnly = true;
                    dtgvThucDon.Columns["CategoryName"].DefaultCellStyle.NullValue = "N/A";
                    dtgvThucDon.Columns["CategoryID"].Visible = false;
                    dtgvThucDon.Columns["FoodId"].Visible = false;
                    dtgvThucDon.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                default:
                    break;
            }
        }

        private void addFoodBtn_Click(object sender, EventArgs e)
        {
            fThemThucDon f = new fThemThucDon();
            f.ShowDialog();
            LoadThucDonData();
            RefreshThucDonBinding();
        }

        private void dtgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow == -1)
            {
                return;
            }
            DataGridViewRow selectedRow = dtgvThucDon.Rows[e.RowIndex];
            string categoryRowId = selectedRow.Cells["CategoryID"].Value?.ToString();
            var categoryList = danhMucDAO.getListFoodCategories();
            if (categoryList != null)
            {
                var selectedCategory = categoryList.FirstOrDefault(c => c.CategoryID == categoryRowId);
                if (selectedCategory != null)
                {
                    foodCategoryComboBox.SelectedValue = selectedCategory.CategoryID;
                }
                else
                {
                    foodCategoryComboBox.SelectedIndex = -1;
                }
            }

            suaMonBtn.Visible = true;
            xoaMonBtn.Visible = true;
        }

        private void AddThucDonBinding()
        {
            foodIDTextBox.DataBindings.Add(new Binding("Text",dtgvThucDon.DataSource,"FoodId"));
            foodNameTextBox.DataBindings.Add(new Binding(("Text"), dtgvThucDon.DataSource, "Name"));
            //foodCategoryComboBox.DataBindings.Add("SelectedValue", dtgvThucDon.DataSource, "CategoryName");
            foodPriceNumeric.DataBindings.Add("Value", dtgvThucDon.DataSource, "Price");
        }

        private void LoadFoodCategories()
        {
            var categoryList = danhMucDAO.getListFoodCategories();
            foodCategoryComboBox.DataSource = categoryList;
            foodCategoryComboBox.DisplayMember = "Name";
            foodCategoryComboBox.ValueMember = "CategoryID";
        }

        #region Trash

        private void dtgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        #endregion
        private void suaMonBtn_Click(object sender, EventArgs e)
        {
            string monID = foodIDTextBox.Text;
            string monName = foodNameTextBox.Text;
            string monCategoryID = foodCategoryComboBox.SelectedValue.ToString();
            decimal monPrice = foodPriceNumeric.Value;
            
            var rs = thucDonDAO.EditFood(monID, monName, monCategoryID, monPrice);
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
                    LoadThucDonData();
                    RefreshThucDonBinding();
                    break;
                default:
                    break;
            }
        }

        private void RefreshThucDonBinding()
        {
            foodIDTextBox.DataBindings.Clear();
            foodNameTextBox.DataBindings.Clear();
            foodPriceNumeric.DataBindings.Clear();
            AddThucDonBinding();
        }

        private void xoaMonBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá sản phẩm này?",    
                "Xác nhận xoá",                                
                MessageBoxButtons.YesNo,                      
                MessageBoxIcon.Question                       
            );

            if (confirmResult == DialogResult.Yes)
            {
                var rs = thucDonDAO.DeleteFood( foodIDTextBox.Text );

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
                        LoadThucDonData();
                        RefreshThucDonBinding();
                        break;
                    default:
                        break;
                }
            }
        }

        private void searchMonBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchMonTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập món cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = thucDonDAO.SearchFoodByName( searchMonTextBox.Text );
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Suceess:
                    dtgvThucDon.DataSource = rs.Data;
                    dtgvThucDon.ReadOnly = true;
                    dtgvThucDon.Columns["CategoryName"].DefaultCellStyle.NullValue = "N/A";
                    dtgvThucDon.Columns["CategoryID"].Visible = false;
                    dtgvThucDon.Columns["FoodId"].Visible = false;
                    dtgvThucDon.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    RefreshThucDonBinding();
                    break;
                default:
                    break;
            }
        }

        private void loadFoodDataBtn_Click(object sender, EventArgs e)
        {
            LoadThucDonData();
            RefreshThucDonBinding();
            LoadListDanhMuc();
            RefreshThucDonBinding() ;
        }
        #endregion

        #region Tài khoản
        private void LoadAccountData()
        {
            var rs = accountDAO.LoadAccountList();
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EnumErrCode.Suceess:
                    dtgvAccount.DataSource = rs.Data;
                    dtgvAccount.ReadOnly = true;
                    dtgvAccount.Columns["AccountID"].Visible = false;
                    dtgvAccount.Columns["Password"].Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void AddAccountBinding()
        {
            idAccTextBox.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource,"AccountID"));
            accountTextBox.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource,"UserName"));
            displayNameTextBox.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName"));
            phoneNumTextBox.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource,"PhoneNum"));
        }

        private void RefreshAccountBinding()
        {
            idAccTextBox.DataBindings.Clear();
            accountTextBox.DataBindings.Clear();
            displayNameTextBox.DataBindings.Clear();
            phoneNumTextBox.DataBindings.Clear();
            AddAccountBinding();
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow == -1)
            {
                return;
            }
            DataGridViewRow selectedRow = dtgvAccount.Rows[e.RowIndex];
            string accType = selectedRow.Cells["Type"].Value?.ToString();
            if (Convert.ToInt32(accType) == 0)
            {
                accTypeTextBox.Text = "Quản lý";
            } else
            {
                accTypeTextBox.Text = "Nhân Viên";
            }

            suaAccBtn.Visible = true;
            xoaAccBtn.Visible = true;
        }

        private void addAccBtn_Click(object sender, EventArgs e)
        {
            fAddAccount f = new fAddAccount();
            f.ShowDialog();
            LoadAccountData();
            RefreshAccountBinding();
        }

        private void suaAccBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(displayNameTextBox.Text))
            {
                MessageBox.Show("Tên hiển thị trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = accountDAO.EditAccount(idAccTextBox.Text, displayNameTextBox.Text, phoneNumTextBox.Text);

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
                    LoadAccountData();
                    RefreshAccountBinding();
                    break;
                default:
                    break;
            }
        }

        private void xoaAccBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
               "Bạn có chắc chắn muốn xoá tài khoản này?",
               "Xác nhận xoá",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (confirmResult == DialogResult.Yes)
            {
                var rs = accountDAO.DeleteAccount(idAccTextBox.Text);

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
                        LoadAccountData();
                        RefreshAccountBinding();
                        break;
                    default:
                        break;
                }
            }
        }

        private void resetPassBtn_Click(object sender, EventArgs e)
        {

            int selectedRowIndex = dtgvAccount.CurrentCell.RowIndex;
            string id = dtgvAccount.Rows[selectedRowIndex].Cells["AccountID"].Value.ToString();
            string userName = dtgvAccount.Rows[selectedRowIndex].Cells["UserName"].Value.ToString();
            var rs = accountDAO.ResetPassword(id, "0" );

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
            //fResetPassword f = new fResetPassword(id,userName);
            //f.ShowDialog();
            LoadAccountData();
            RefreshAccountBinding();
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timBillBtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var billsResult = doanhThuDAO.GetBill(fromDate, toDate);

                if (billsResult.Data == null || billsResult.Data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cho khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtgvBill.DataSource = billsResult.Data;

                dtgvBill.Columns["BillID"].HeaderText = "Bill ID";
                dtgvBill.Columns["TableFoodID"].HeaderText = "Tên bàn";
                dtgvBill.Columns["DateCheckOut"].HeaderText = "Ngày Checkout";
                dtgvBill.Columns["TotalPrice"].HeaderText = "Thành tiền";
                dtgvBill.Columns["Discount"].HeaderText = "Giảm giá(%)";
                dtgvBill.Columns["DateCheckIn"].Visible = false;
                dtgvBill.Columns["Status"].Visible = false;
                dtgvBill.Columns["TableFood"].Visible = false;

                float TongTien = doanhThuDAO.GetTongTien(fromDate, toDate);

                lbl_TongTien.Text = string.Format("Tổng doanh thu: {0:N0} VND", TongTien);
                dtgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tpTable_Click(object sender, EventArgs e)
        {

        }


        #endregion
        //MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        #region Bàn ăn 

 


        
        private void RefreshBanAnBinding()
        {
            textBox8.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            AddBananBinding();
        }
        // Tải danh sách bàn ăn

        public void LoadListBanAn()
        {
            var rs = tableDAO.LoadTableList1();
            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Suceess:
                    dataGridView3.DataSource = rs.Data;
                    dataGridView3.Columns["TableFoodId"].Visible = false;
                    dataGridView3.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                default:
                    break;
            }
        }


        // Liên kết dữ liệu cho các ô nhập liệu
        public void AddBananBinding()
        {
            textBox8.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "TableFoodId"));
            textBox7.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "Name"));
            textBox5.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "status"));
        }
        private void xemBanBtn_Click(object sender, EventArgs e)
        {
            LoadListBanAn();

        }

        private void themBanBtn_Click_1(object sender, EventArgs e)
        {
            fThemBanAn f = new fThemBanAn();
            f.ShowDialog();
            LoadListBanAn();
            RefreshBanAnBinding();

        }

        private void suaBanBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn ăn cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = tableDAO.EditTable(textBox8.Text, textBox7.Text, textBox5.Text);
            switch (rs.ErrCode)
            {
                case DTO.EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DTO.EnumErrCode.Suceess:
                    MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListBanAn();
                    RefreshBanAnBinding() ;
                    break;
                default:
                    break;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            // Kiểm tra nếu người dùng nhấn vào header (indexRow == -1) thì không làm gì
            if (indexRow == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }


            // Lấy dòng đã chọn trong DataGridView
            DataGridViewRow selectedRow = dataGridView3.Rows[e.RowIndex];

            // Lấy giá trị từ các ô trong dòng đã chọn (ID bàn ăn, Tên bàn ăn, Trạng thái)
            string tableFoodId = selectedRow.Cells["TableFoodId"].Value?.ToString();
            string tableName = selectedRow.Cells["Name"].Value?.ToString();
            string tableStatus = selectedRow.Cells["Status"].Value?.ToString();

            // Điền dữ liệu vào các ô nhập liệu
            textBox8.Text = tableFoodId;
            textBox7.Text = tableName;
            textBox5.Text = tableStatus;
            textBox8.ReadOnly = true;
            suaBanBtn.Visible = true;
            xoaBanBtn.Visible = true;

        }

        private void xoaBanBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn ăn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy thông tin bàn ăn từ database
            var table = tableDAO.GetTableByIdAndStatus(textBox8.Text, textBox7.Text, textBox5.Text);

            if (table == null)
            {
                MessageBox.Show("Bàn ăn không tồn tại trong hệ thống hoặc không khớp với tên và trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu bàn ăn tồn tại và khớp với điều kiện, tiếp tục xử lý...

            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bàn ăn này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                var rs = tableDAO.DeleteTable(textBox8.Text);
                switch (rs.ErrCode)
                {
                    case DTO.EnumErrCode.Error:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case DTO.EnumErrCode.Suceess:
                        MessageBox.Show(rs.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListBanAn();
                        RefreshBanAnBinding();
                        break;
                    default:
                        break;
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tpBill_Click(object sender, EventArgs e)
        {

        }
        private PrintDocument printDoc = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtgvBill.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printDoc.PrintPage += printDocument_PrintPage;
            printPreviewDialog.Document = printDoc;
            printPreviewDialog.ShowDialog();

            PrintDialog printDialog = new PrintDialog { Document = printDoc };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hoá Đơn Thanh Toán", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new PointF(300, 50));

            int yPosition = 100;
            int startX = 100;
            int pageWidth = e.PageBounds.Width;

            // Đặt độ rộng cột cho các cột cần thiết (không có Giảm Giá nữa)
            int[] columnWidths = new int[3]; // Cần 3 cột: FoodName, Count, Price
            columnWidths[0] = 150; // FoodName
            columnWidths[1] = 100; // Count
            columnWidths[2] = 100; // Price

            // In tiêu đề cột (không còn Giảm Giá)
            e.Graphics.DrawString("Tên Món", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(startX, yPosition));
            e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[0], 20);

            startX += columnWidths[0];
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(startX, yPosition));
            e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[1], 20);

            startX += columnWidths[1];
            e.Graphics.DrawString("Đơn Giá", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(startX, yPosition));
            e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[2], 20);

            yPosition += 20;

            // Lấy thông tin chi tiết từ BillInfo và hiển thị
            startX = 100;
            DBModelDataContext _context = new DBModelDataContext();

            foreach (DataGridViewRow row in dtgvBill.Rows)
            {
                if (row.IsNewRow) continue;

                // Lấy BillID từ DataGridView
                string billID = row.Cells["BillID"].Value.ToString();

                // Truy vấn dữ liệu từ BillInfo dựa trên BillID
                var billInfoQuery = from billInfo in _context.BillInfos
                                    join food in _context.Foods on billInfo.FoodID equals food.FoodID
                                    where billInfo.BillID == billID
                                    select new
                                    {
                                        FoodName = food.Name,
                                        Count = billInfo.Count,
                                        Price = billInfo.Price,
                                    };

                // In các dữ liệu trong BillInfo
                foreach (var billInfo in billInfoQuery)
                {
                    string foodName = billInfo.FoodName;
                    string count = billInfo.Count.ToString();
                    string price = billInfo.Price.ToString();

                    // Cắt giá trị nếu quá dài
                    if (foodName.Length > 40) foodName = foodName.Substring(0, 40) + "...";
                    if (count.Length > 40) count = count.Substring(0, 40) + "...";
                    if (price.Length > 40) price = price.Substring(0, 40) + "...";

                    // In thông tin vào các cột
                    e.Graphics.DrawString(foodName, new Font("Arial", 10), Brushes.Black, new PointF(startX + 5, yPosition));
                    e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[0], 20);
                    startX += columnWidths[0];

                    e.Graphics.DrawString(count, new Font("Arial", 10), Brushes.Black, new PointF(startX + 5, yPosition));
                    e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[1], 20);
                    startX += columnWidths[1];

                    e.Graphics.DrawString(price, new Font("Arial", 10), Brushes.Black, new PointF(startX + 5, yPosition));
                    e.Graphics.DrawRectangle(Pens.Black, startX, yPosition, columnWidths[2], 20);
                    startX += columnWidths[2];

                    yPosition += 20;
                    startX = 100;
                }
            }

            // Lấy giảm giá từ DataGridView
            decimal discount = 0;
            if (dtgvBill.Rows.Count > 0 && dtgvBill.Rows[0].Cells["Discount"].Value != null)
            {
                discount = Convert.ToDecimal(dtgvBill.Rows[0].Cells["Discount"].Value);
            }

            // Tính tổng tiền và hiển thị
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dtgvBill.Rows)
            {
                if (row.IsNewRow) continue;
                totalPrice += Convert.ToDecimal(row.Cells["TotalPrice"].Value);
            }
            decimal finalPrice = totalPrice - discount;

            // In thông tin Tổng Tiền và Giảm Giá
            e.Graphics.DrawString("Giảm Giá: " + discount.ToString()+"%", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, yPosition + 10));
            yPosition += 20;
            e.Graphics.DrawString("Tổng Tiền: " + finalPrice.ToString()+" Đồng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, yPosition + 10));
        }

        private void xemThucDonBtn_Click_1(object sender, EventArgs e)
        {
            LoadListDanhMuc();
            RefreshDanhMucBinding();
        }

        private void tpFood_Click(object sender, EventArgs e)
        {

        }

        private void billDetailsBtn_Click(object sender, EventArgs e)
        {
            if (dtgvBill.SelectedRows.Count > 0)
            {
                // Lấy BillID từ cột đầu tiên
                string billID = dtgvBill.SelectedRows[0].Cells[0].Value.ToString();
                //Debug.WriteLine(billID);

                fBillDetails billDetailsForm = new fBillDetails(billID);
                billDetailsForm.ShowDialog();
            }
        }

        private void dtgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            billDetailsBtn.Visible = true;
        }
    }


    #endregion
}

