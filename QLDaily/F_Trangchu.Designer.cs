namespace QLDaily
{
    partial class F_Trangchu
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
            btn_FSanpham = new Button();
            btn_FHoadon = new Button();
            SuspendLayout();
            // 
            // btn_FSanpham
            // 
            btn_FSanpham.Location = new Point(294, 51);
            btn_FSanpham.Name = "btn_FSanpham";
            btn_FSanpham.Size = new Size(155, 70);
            btn_FSanpham.TabIndex = 0;
            btn_FSanpham.Text = "Quản lý sản phẩm";
            btn_FSanpham.UseVisualStyleBackColor = true;
            btn_FSanpham.Click += btn_FSanpham_Click;
            // 
            // btn_FHoadon
            // 
            btn_FHoadon.Location = new Point(523, 51);
            btn_FHoadon.Name = "btn_FHoadon";
            btn_FHoadon.Size = new Size(155, 70);
            btn_FHoadon.TabIndex = 1;
            btn_FHoadon.Text = "Quản lý bán hàng";
            btn_FHoadon.UseVisualStyleBackColor = true;
            btn_FHoadon.Click += btn_FHoadon_Click;
            // 
            // F_Trangchu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 561);
            Controls.Add(btn_FHoadon);
            Controls.Add(btn_FSanpham);
            Name = "F_Trangchu";
            Text = "F_Trangchu";
            Load += F_Trangchu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_FSanpham;
        private Button btn_FHoadon;
    }
}