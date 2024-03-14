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
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtDVT = new TextBox();
            txtSoluong = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtDongia = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            btnThemSP = new Button();
            btnSuaSP = new Button();
            btnXoaSP = new Button();
            btnTiemkiemSP = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 68);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 111);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 1;
            label2.Text = "Đơn vị tính: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(303, 68);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 3;
            label4.Text = "Tên sản phẩm: ";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(97, 60);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(186, 23);
            txtMaSP.TabIndex = 4;
            txtMaSP.TextChanged += textBox1_TextChanged;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(395, 60);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(186, 23);
            txtTenSP.TabIndex = 5;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(97, 103);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(186, 23);
            txtDVT.TabIndex = 6;
            // 
            // txtSoluong
            // 
            txtSoluong.Location = new Point(661, 75);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(127, 23);
            txtSoluong.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(601, 83);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Số lượng: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 111);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 8;
            label5.Text = "Đơn giá:";
            // 
            // txtDongia
            // 
            txtDongia.Location = new Point(395, 103);
            txtDongia.Name = "txtDongia";
            txtDongia.Size = new Size(186, 23);
            txtDongia.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(259, 9);
            label6.Name = "label6";
            label6.Size = new Size(266, 37);
            label6.TabIndex = 10;
            label6.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 253);
            dataGridView1.TabIndex = 11;
            // 
            // btnThemSP
            // 
            btnThemSP.Location = new Point(25, 415);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(100, 23);
            btnThemSP.TabIndex = 12;
            btnThemSP.Text = "Thêm";
            btnThemSP.UseVisualStyleBackColor = true;
            // 
            // btnSuaSP
            // 
            btnSuaSP.Location = new Point(259, 415);
            btnSuaSP.Name = "btnSuaSP";
            btnSuaSP.Size = new Size(95, 23);
            btnSuaSP.TabIndex = 13;
            btnSuaSP.Text = "Sửa";
            btnSuaSP.UseVisualStyleBackColor = true;
            // 
            // btnXoaSP
            // 
            btnXoaSP.Location = new Point(504, 415);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(96, 23);
            btnXoaSP.TabIndex = 14;
            btnXoaSP.Text = "Xóa";
            btnXoaSP.UseVisualStyleBackColor = true;
            // 
            // btnTiemkiemSP
            // 
            btnTiemkiemSP.Location = new Point(688, 415);
            btnTiemkiemSP.Name = "btnTiemkiemSP";
            btnTiemkiemSP.Size = new Size(88, 23);
            btnTiemkiemSP.TabIndex = 15;
            btnTiemkiemSP.Text = "Tìm kiếm";
            btnTiemkiemSP.UseVisualStyleBackColor = true;
            // 
            // F_Sanpham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTiemkiemSP);
            Controls.Add(btnXoaSP);
            Controls.Add(btnSuaSP);
            Controls.Add(btnThemSP);
            Controls.Add(dataGridView1);
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
            Name = "F_Sanpham";
            Text = "F_Sanpham";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtDVT;
        private TextBox txtSoluong;
        private Label label3;
        private Label label5;
        private TextBox txtDongia;
        private Label label6;
        private DataGridView dataGridView1;
        private Button btnThemSP;
        private Button btnSuaSP;
        private Button btnXoaSP;
        private Button btnTiemkiemSP;
    }
}