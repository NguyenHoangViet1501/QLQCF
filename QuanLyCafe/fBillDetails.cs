using QuanLyCafe.DTO;
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
    public partial class fBillDetails : Form
    {
        public fBillDetails(string billID)
        {
            InitializeComponent();
            LoadBillDetails(billID);
        }

        private void fBillDetails_Load(object sender, EventArgs e)
        {

        }

        private void LoadBillDetails(string billID)
        {
            using (var context = new DBModelDataContext())
            {
                var bill = context.Bills.FirstOrDefault(b => b.BillID == billID);
                if (bill != null)
                {
                    txtDateCheckOut.Text = bill.DateCheckOut?.ToString("yyyy-MM-dd HH:mm:ss");
                    txtTotalPrice.Text = bill.TotalPrice.ToString();
                    txtDiscount.Text = bill.Discount.ToString();
                }

                var billDetails = context.BillInfos
                    .Where(bi => bi.BillID == billID)
                    .Join(
                        context.Foods,          
                        bi => bi.FoodID,       
                        f => f.FoodID,          
                        (bi, f) => new          
                        {
                            f.Name,             
                            bi.Count,           
                            bi.Price            
                        })
                    .ToList();

                dataGridViewBillDetails.DataSource = billDetails; 


            }
        }

    }
}
