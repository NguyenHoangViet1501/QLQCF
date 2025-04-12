using QuanLyCafe.DTO;
using QuanLyCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace QuanLyCafe
{

    public partial class fTableManager : Form
    {
        public Account logined;
        DBModelDataContext _db = new DBModelDataContext();
        TableDAO tableDAO = new TableDAO();
        MenuDAO menuDAO = new MenuDAO();
        DanhMucDAO danhMucDAO = new DanhMucDAO();
        ThucDonDAO thucDonDAO = new ThucDonDAO();
        BillDAO billDAO = new BillDAO();
        BillInfoDAO billInfoDAO = new BillInfoDAO();
        public fTableManager(Account user)
        { 

            logined = user;
            InitializeComponent();
            
        }

        #region Method
        public void LoadTable()
        {


            tablePanel.Controls.Clear();

            var rsTable = tableDAO.LoadTableList();

            switch (rsTable.ErrCode)
            {
                case EnumErrCode.Error:
                case EnumErrCode.Empty:
                    MessageBox.Show(rsTable.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case EnumErrCode.Suceess:
                    foreach (TableFood item in rsTable.Data)
                    {
                        Button btn = new Button()
                        {
                            Width = TableDAO.tableWidth,
                            Height = TableDAO.tableHeight,
                            Text = item.Name + Environment.NewLine + item.Status,
                            Tag = item
                            
                        };

                        btn.Click += btn_Click;

                        if (item.Status != "Trống")
                        {
                            btn.BackColor = Color.LightPink; 
                        }
                        else
                        {
                            btn.BackColor = Color.LightGreen; 
                        }
                        //Debug.WriteLine(item.Name+"/"+item.Status);
                        tablePanel.Controls.Add(btn);
                    }
                    break;

                default:
                    break;
            }
        }
        void LoadCategory()
        {
            var list = danhMucDAO.getListFoodCategories();
            cbCategory.DataSource = list;
            cbCategory.DisplayMember = "Name";
        }
        void LoadCbTable()
        {
            cbTableList.DataSource = tableDAO.getTableList();
            cbTableList.DisplayMember = "Name";
        }
        void LoadFoodByID(string id)
        {
            var list = thucDonDAO.GetFoodListByCategoryID(id);
            cbFoodList.DataSource = list;
            cbFoodList.DisplayMember = "Name";
        }

        FunctionResult<Bill> CreateNewBillForTable(string tableID)
        {
            var rs = billDAO.CreateBill(tableID);

            if (rs.ErrCode == EnumErrCode.Suceess)
            {
                LoadTable(); 
            }

            return rs; // Trả về kết quả để sử dụng tiếp
        }

        void CreateNewBillInfo(string idBill, string foodID, int count)
        {
            var rs = billInfoDAO.InsertBillInfo(idBill, foodID, count);

            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.Desc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.Desc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case EnumErrCode.Suceess:
                    Debug.Write(rs.Desc);
                    LoadTable();
                    break;
                default:
                    break;
            }
        }
        void ShowBill(string tableFoodID)
        {
            lsvBill.Items.Clear();

            var result = menuDAO.GetListMenuByTable(tableFoodID);

            switch (result.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(result.Desc);
                    break;
                case EnumErrCode.Empty:
                    txbTotalPrice.Text = "";

                    break;
                case EnumErrCode.Suceess:
                    List<QuanLyCafe.DTO.Menu> listBillInfo = result.Data;
                    float totalPrice = 0;

                    foreach (QuanLyCafe.DTO.Menu item in listBillInfo)
                    {
                        ListViewItem lsvItem = new ListViewItem(item.FoodName);
                        lsvItem.SubItems.Add(item.Count.ToString());
                        lsvItem.SubItems.Add(item.Price.ToString("N0", new CultureInfo("vi-VN")));
                        lsvItem.SubItems.Add(item.TotalPrice.ToString("N0", new CultureInfo("vi-VN")));

                        totalPrice += (float)item.TotalPrice;
                        lsvBill.Items.Add(lsvItem);

                        CultureInfo culture = new CultureInfo("vi-VN");
                        txbTotalPrice.Text = totalPrice.ToString("N0", culture);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion
        private void btn_Click(object sender, EventArgs e)
        {
            string tableId = ((sender as Button).Tag as TableFood).TableFoodId;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableId);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCácNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile(logined);
            fAccountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            if(logined.Type == 0)
            {
                adminToolStripMenuItem.Visible = true;
            }
            LoadTable();
            LoadCategory();
            LoadCbTable();
        }

        private void themMonBtn_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;

            if (table == null)
            {
                MessageBox.Show("Chưa chọn bàn");
                return;
            }

            // Lấy BillID chưa thanh toán của bàn
            var getBillByTableResult = billDAO.GetUncheckBillIDByTableID(table.TableFoodId);
            string foodID = (cbFoodList.SelectedItem as Food).FoodID;
            int count = (int)numericCount.Value;

            switch (getBillByTableResult.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(getBillByTableResult.Desc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.Empty: // Nếu chưa có Bill, tạo mới
                    var createBillResult = CreateNewBillForTable(table.TableFoodId);
                    if (createBillResult.ErrCode == EnumErrCode.Suceess)
                    {
                        string newBillID = createBillResult.Data.BillID;
                        CreateNewBillInfo(newBillID, foodID, count); // Tạo BillInfo đầu tiên
                    }
                    break;

                case EnumErrCode.Suceess: // Nếu đã có Bill, thêm mới BillInfo
                    CreateNewBillInfo(getBillByTableResult.Data, foodID, count);
                    break;

                default:
                    break;
            }

            ShowBill(table.TableFoodId);
            LoadTable();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }

            FoodCategory selected = cb.SelectedItem as FoodCategory;

            LoadFoodByID(selected.CategoryID);
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;

            var result = billDAO.GetUncheckBillIDByTableID(table.TableFoodId);
            int discount = (int)discountNumeric.Value;

            if (result.ErrCode == EnumErrCode.Suceess)
            {
                string billID = result.Data;
                double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]) * 1000;
                double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    var checkoutResult = billDAO.CheckOut(billID, (float)finalTotalPrice,discount);
                    if (checkoutResult.ErrCode == EnumErrCode.Suceess)
                    {
                        ShowBill(table.TableFoodId);
                        MessageBox.Show("Thanh toán thành công!");
                        txbTotalPrice.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(checkoutResult.Desc);
                    }
                }
            }
            else
            {
                MessageBox.Show(result.Desc);
            }
            LoadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (logined.Type == 0)
            {
                adminToolStripMenuItem.Visible = true;
            }
            LoadTable();
            LoadCategory();
            LoadCbTable();
        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void swTableBtn_Click(object sender, EventArgs e)
        {
            var currentTable = lsvBill.Tag as TableFood;
            var targetTable = cbTableList.SelectedItem as TableFood;

            if (currentTable == null || targetTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}?", currentTable.Name, targetTable.Name),
                    "Thông báo",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var result = tableDAO.SwitchTable(currentTable.TableFoodId, targetTable.TableFoodId);

                if (result.ErrCode == EnumErrCode.Suceess)
                {
                    MessageBox.Show(result.Desc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTable();
                }
                else
                {
                    MessageBox.Show(result.Desc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
