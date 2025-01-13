namespace QLDaily
{
    partial class Khachhang
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
            txtTenKH = new TextBox();
            txtSDT = new TextBox();
            label3 = new Label();
            txtDiachi = new TextBox();
            label4 = new Label();
            dGVdsKhachhang = new DataGridView();
            button1 = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dGVdsKhachhang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(369, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(24, 74);
            label2.Name = "label2";
            label2.Size = new Size(155, 28);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng: ";
            // 
            // txtTenKH
            // 
            txtTenKH.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenKH.Location = new Point(185, 68);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(294, 34);
            txtTenKH.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtSDT.Location = new Point(755, 68);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(265, 34);
            txtSDT.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(607, 71);
            label3.Name = "label3";
            label3.Size = new Size(132, 28);
            label3.TabIndex = 3;
            label3.Text = "Số điện thoại:";
            // 
            // txtDiachi
            // 
            txtDiachi.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiachi.Location = new Point(301, 125);
            txtDiachi.Name = "txtDiachi";
            txtDiachi.Size = new Size(599, 34);
            txtDiachi.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(220, 128);
            label4.Name = "label4";
            label4.Size = new Size(75, 28);
            label4.TabIndex = 5;
            label4.Text = "Địa chỉ:";
            // 
            // dGVdsKhachhang
            // 
            dGVdsKhachhang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVdsKhachhang.Location = new Point(12, 262);
            dGVdsKhachhang.Name = "dGVdsKhachhang";
            dGVdsKhachhang.RowTemplate.Height = 25;
            dGVdsKhachhang.Size = new Size(1038, 349);
            dGVdsKhachhang.TabIndex = 7;
            dGVdsKhachhang.CellContentClick += dGVdsKhachhang_CellContentClick;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(38, 204);
            button1.Name = "button1";
            button1.Size = new Size(141, 52);
            button1.TabIndex = 8;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnSua.Location = new Point(258, 204);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(149, 52);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnXoa.Location = new Point(548, 204);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(146, 52);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(805, 204);
            button4.Name = "button4";
            button4.Size = new Size(232, 52);
            button4.TabIndex = 11;
            button4.Text = "Tìm kiếm";
            button4.UseVisualStyleBackColor = true;
            // 
            // Khachhang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 633);
            Controls.Add(button4);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(button1);
            Controls.Add(dGVdsKhachhang);
            Controls.Add(txtDiachi);
            Controls.Add(label4);
            Controls.Add(txtSDT);
            Controls.Add(label3);
            Controls.Add(txtTenKH);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Khachhang";
            Text = "Khachhang";
            Load += Khachhang_Load;
            ((System.ComponentModel.ISupportInitialize)dGVdsKhachhang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private Label label3;
        private TextBox txtDiachi;
        private Label label4;
        private DataGridView dGVdsKhachhang;
        private Button button1;
        private Button btnSua;
        private Button btnXoa;
        private Button button4;
    }
}