namespace QLDaily
{
    partial class F_Sanpham
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
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtTenSP = new TextBox();
            txtDVT = new TextBox();
            txtSoluong = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtDongia = new TextBox();
            label6 = new Label();
            dtgSanPham = new DataGridView();
            btnThemSP = new Button();
            btnSuaSP = new Button();
            btnXoaSP = new Button();
            btnInSP = new Button();
            btnThoatSP = new Button();
            btnHuySP = new Button();
            txtMaSP = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgSanPham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 93);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 168);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 1;
            label2.Text = "Đơn vị tính: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(613, 97);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 25);
            label4.TabIndex = 3;
            label4.Text = "Tên sản phẩm: ";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(838, 100);
            txtTenSP.Margin = new Padding(5, 5, 5, 5);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(290, 32);
            txtTenSP.TabIndex = 5;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(233, 168);
            txtDVT.Margin = new Padding(5, 5, 5, 5);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(290, 32);
            txtDVT.TabIndex = 6;
            // 
            // txtSoluong
            // 
            txtSoluong.Location = new Point(1383, 100);
            txtSoluong.Margin = new Padding(5, 5, 5, 5);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(284, 32);
            txtSoluong.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1223, 97);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 25);
            label3.TabIndex = 2;
            label3.Text = "Số lượng: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(646, 172);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 25);
            label5.TabIndex = 8;
            label5.Text = "Đơn giá:";
            // 
            // txtDongia
            // 
            txtDongia.Location = new Point(838, 172);
            txtDongia.Margin = new Padding(5, 5, 5, 5);
            txtDongia.Name = "txtDongia";
            txtDongia.Size = new Size(290, 32);
            txtDongia.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(646, 12);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(266, 37);
            label6.TabIndex = 10;
            label6.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // dtgSanPham
            // 
            dtgSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSanPham.Location = new Point(9, 242);
            dtgSanPham.Margin = new Padding(5, 5, 5, 5);
            dtgSanPham.Name = "dtgSanPham";
            dtgSanPham.RowTemplate.Height = 25;
            dtgSanPham.Size = new Size(1675, 557);
            dtgSanPham.TabIndex = 11;
            dtgSanPham.CellContentClick += dtgSanPham_CellContentClick;
            // 
            // btnThemSP
            // 
            btnThemSP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnThemSP.Location = new Point(19, 833);
            btnThemSP.Margin = new Padding(5, 5, 5, 5);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(192, 78);
            btnThemSP.TabIndex = 12;
            btnThemSP.Text = "Thêm";
            btnThemSP.UseVisualStyleBackColor = true;
            btnThemSP.Click += btnThemSP_Click;
            // 
            // btnSuaSP
            // 
            btnSuaSP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnSuaSP.Location = new Point(336, 833);
            btnSuaSP.Margin = new Padding(5, 5, 5, 5);
            btnSuaSP.Name = "btnSuaSP";
            btnSuaSP.Size = new Size(189, 78);
            btnSuaSP.TabIndex = 13;
            btnSuaSP.Text = "Sửa";
            btnSuaSP.UseVisualStyleBackColor = true;
            btnSuaSP.Click += btnSuaSP_Click;
            // 
            // btnXoaSP
            // 
            btnXoaSP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnXoaSP.Location = new Point(726, 837);
            btnXoaSP.Margin = new Padding(5, 5, 5, 5);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(190, 75);
            btnXoaSP.TabIndex = 14;
            btnXoaSP.Text = "Xóa";
            btnXoaSP.UseVisualStyleBackColor = true;
            btnXoaSP.Click += btnXoaSP_Click;
            // 
            // btnInSP
            // 
            btnInSP.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnInSP.Location = new Point(1260, 163);
            btnInSP.Margin = new Padding(5, 5, 5, 5);
            btnInSP.Name = "btnInSP";
            btnInSP.Size = new Size(409, 52);
            btnInSP.TabIndex = 16;
            btnInSP.Text = "In danh sách sản phẩm";
            btnInSP.UseVisualStyleBackColor = true;
            btnInSP.Click += btnInSP_Click;
            // 
            // btnThoatSP
            // 
            btnThoatSP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnThoatSP.Location = new Point(1119, 838);
            btnThoatSP.Margin = new Padding(5, 5, 5, 5);
            btnThoatSP.Name = "btnThoatSP";
            btnThoatSP.Size = new Size(189, 72);
            btnThoatSP.TabIndex = 17;
            btnThoatSP.Text = "Thoát";
            btnThoatSP.UseVisualStyleBackColor = true;
            btnThoatSP.Click += btnThoatSP_Click;
            // 
            // btnHuySP
            // 
            btnHuySP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnHuySP.Location = new Point(1496, 837);
            btnHuySP.Margin = new Padding(5, 5, 5, 5);
            btnHuySP.Name = "btnHuySP";
            btnHuySP.Size = new Size(189, 78);
            btnHuySP.TabIndex = 18;
            btnHuySP.Text = "Hủy";
            btnHuySP.UseVisualStyleBackColor = true;
            btnHuySP.Click += btnHuySP_Click;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(233, 97);
            txtMaSP.Margin = new Padding(5, 5, 5, 5);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(290, 32);
            txtMaSP.TabIndex = 4;
            // 
            // F_Sanpham
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1703, 935);
            Controls.Add(btnHuySP);
            Controls.Add(btnThoatSP);
            Controls.Add(btnInSP);
            Controls.Add(btnXoaSP);
            Controls.Add(btnSuaSP);
            Controls.Add(btnThemSP);
            Controls.Add(dtgSanPham);
            Controls.Add(label6);
            Controls.Add(txtDongia);
            Controls.Add(label5);
            Controls.Add(txtSoluong);
            Controls.Add(txtDVT);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 5, 5, 5);
            Name = "F_Sanpham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "F_Sanpham";
            Load += F_Sanpham_Load;
            ((System.ComponentModel.ISupportInitialize)dtgSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtTenSP;
        private TextBox txtDVT;
        private TextBox txtSoluong;
        private Label label3;
        private Label label5;
        private TextBox txtDongia;
        private Label label6;
        private DataGridView dtgSanPham;
        private Button btnThemSP;
        private Button btnSuaSP;
        private Button btnXoaSP;
        private Button btnInSP;
        private Button btnThoatSP;
        private Button btnHuySP;
        private TextBox txtMaSP;
    }
}