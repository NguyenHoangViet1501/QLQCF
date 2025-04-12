namespace QuanLyCafe
{
    partial class fThemDanhMuc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.danhMucTextBox = new System.Windows.Forms.TextBox();
            this.themDanhMucBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM DANH MỤC";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Danh Mục:";
            // 
            // danhMucTextBox
            // 
            this.danhMucTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.danhMucTextBox.Location = new System.Drawing.Point(214, 99);
            this.danhMucTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.danhMucTextBox.Name = "danhMucTextBox";
            this.danhMucTextBox.Size = new System.Drawing.Size(252, 23);
            this.danhMucTextBox.TabIndex = 2;
            // 
            // themDanhMucBtn
            // 
            this.themDanhMucBtn.Location = new System.Drawing.Point(612, 465);
            this.themDanhMucBtn.Margin = new System.Windows.Forms.Padding(2);
            this.themDanhMucBtn.Name = "themDanhMucBtn";
            this.themDanhMucBtn.Size = new System.Drawing.Size(78, 33);
            this.themDanhMucBtn.TabIndex = 3;
            this.themDanhMucBtn.Text = "Thêm";
            this.themDanhMucBtn.UseVisualStyleBackColor = true;
            this.themDanhMucBtn.Click += new System.EventHandler(this.themDanhMucBtn_Click);
            // 
            // fThemDanhMuc
            // 
            this.AcceptButton = this.themDanhMucBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 509);
            this.Controls.Add(this.themDanhMucBtn);
            this.Controls.Add(this.danhMucTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fThemDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm danh mục";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox danhMucTextBox;
        private System.Windows.Forms.Button themDanhMucBtn;
    }
}