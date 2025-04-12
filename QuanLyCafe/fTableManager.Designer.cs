namespace QuanLyCafe
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCácNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbTableList = new System.Windows.Forms.ComboBox();
            this.swTableBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.discountNumeric = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numericCount = new System.Windows.Forms.NumericUpDown();
            this.themMonBtn = new System.Windows.Forms.Button();
            this.cbFoodList = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tablePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumeric)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Visible = false;
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCácNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // thôngTinCácNhânToolStripMenuItem
            // 
            this.thôngTinCácNhânToolStripMenuItem.Name = "thôngTinCácNhânToolStripMenuItem";
            this.thôngTinCácNhânToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thôngTinCácNhânToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinCácNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCácNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(392, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 403);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBill.AutoArrange = false;
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(-2, 1);
            this.lsvBill.Margin = new System.Windows.Forms.Padding(1);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(311, 402);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            this.lsvBill.SelectedIndexChanged += new System.EventHandler(this.lsvBill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 83;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 128;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.cbTableList);
            this.panel3.Controls.Add(this.swTableBtn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.discountNumeric);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.checkoutBtn);
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Location = new System.Drawing.Point(708, 27);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(114, 462);
            this.panel3.TabIndex = 3;
            // 
            // cbTableList
            // 
            this.cbTableList.FormattingEnabled = true;
            this.cbTableList.Location = new System.Drawing.Point(16, 167);
            this.cbTableList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTableList.Name = "cbTableList";
            this.cbTableList.Size = new System.Drawing.Size(85, 21);
            this.cbTableList.TabIndex = 8;
            // 
            // swTableBtn
            // 
            this.swTableBtn.Location = new System.Drawing.Point(2, 119);
            this.swTableBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.swTableBtn.Name = "swTableBtn";
            this.swTableBtn.Size = new System.Drawing.Size(111, 44);
            this.swTableBtn.TabIndex = 7;
            this.swTableBtn.Text = "Chuyển bàn";
            this.swTableBtn.UseVisualStyleBackColor = true;
            this.swTableBtn.Click += new System.EventHandler(this.swTableBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 330);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng tiền:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Giảm giá";
            // 
            // discountNumeric
            // 
            this.discountNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.discountNumeric.Location = new System.Drawing.Point(16, 284);
            this.discountNumeric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.discountNumeric.Name = "discountNumeric";
            this.discountNumeric.Size = new System.Drawing.Size(84, 20);
            this.discountNumeric.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutBtn.Location = new System.Drawing.Point(4, 388);
            this.checkoutBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(108, 58);
            this.checkoutBtn.TabIndex = 0;
            this.checkoutBtn.Text = "Thanh Toán";
            this.checkoutBtn.UseVisualStyleBackColor = true;
            this.checkoutBtn.Click += new System.EventHandler(this.checkoutBtn_Click);
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.Location = new System.Drawing.Point(3, 352);
            this.txbTotalPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(110, 26);
            this.txbTotalPrice.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.numericCount);
            this.panel4.Controls.Add(this.themMonBtn);
            this.panel4.Controls.Add(this.cbFoodList);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(391, 24);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 54);
            this.panel4.TabIndex = 4;
            // 
            // numericCount
            // 
            this.numericCount.Location = new System.Drawing.Point(210, 27);
            this.numericCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericCount.Name = "numericCount";
            this.numericCount.Size = new System.Drawing.Size(42, 20);
            this.numericCount.TabIndex = 3;
            this.numericCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // themMonBtn
            // 
            this.themMonBtn.Location = new System.Drawing.Point(256, 2);
            this.themMonBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.themMonBtn.Name = "themMonBtn";
            this.themMonBtn.Size = new System.Drawing.Size(56, 44);
            this.themMonBtn.TabIndex = 2;
            this.themMonBtn.Text = "Thêm Món";
            this.themMonBtn.UseVisualStyleBackColor = true;
            this.themMonBtn.Click += new System.EventHandler(this.themMonBtn_Click);
            // 
            // cbFoodList
            // 
            this.cbFoodList.FormattingEnabled = true;
            this.cbFoodList.Location = new System.Drawing.Point(2, 27);
            this.cbFoodList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFoodList.Name = "cbFoodList";
            this.cbFoodList.Size = new System.Drawing.Size(204, 21);
            this.cbFoodList.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(2, 2);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(204, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // tablePanel
            // 
            this.tablePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tablePanel.AutoScroll = true;
            this.tablePanel.BackColor = System.Drawing.SystemColors.Control;
            this.tablePanel.Location = new System.Drawing.Point(9, 24);
            this.tablePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(379, 465);
            this.tablePanel.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 508);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumeric)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCácNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button themMonBtn;
        private System.Windows.Forms.ComboBox cbFoodList;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown numericCount;
        private System.Windows.Forms.Button checkoutBtn;
        private System.Windows.Forms.FlowLayoutPanel tablePanel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown discountNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTableList;
        private System.Windows.Forms.Button swTableBtn;
    }
}