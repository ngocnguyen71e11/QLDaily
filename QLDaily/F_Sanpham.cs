using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLDaily
{
    public partial class F_Sanpham : Form
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString);

        public F_Sanpham()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                string sql = "SELECT * FROM v_Sanpham";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dtgSanPham.DataSource = dt;
                        dtgSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                        dtgSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                        dtgSanPham.Columns[2].HeaderText = "Đơn vị tính";
                        dtgSanPham.Columns[3].HeaderText = "Số lượng";
                        dtgSanPham.Columns[4].HeaderText = "Đơn giá";
                        cnn.Close();
                    }
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spSanpham_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PK_sSanphamID", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("sTensanpham", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("sDonvitinh", txtDVT.Text);
                    cmd.Parameters.AddWithValue("iSoluong", txtSoluong.Text);
                    cmd.Parameters.AddWithValue("fDongia", txtDongia.Text);

                    if (CheckmaSP() == 1)
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Thêm thành công !!!");
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công !!!");
                        }
                        cnn.Close();

                    }
                }
            }
        }

        private int CheckmaSP()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spSanpham_CheckID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PK_sSanphamID", txtMaSP.Text);
                    var i = cmd.ExecuteScalar();
                    cnn.Close();
                    if (i != null)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại");
                        return 0;
                    }
                    else
                        return 1;
                }

            }
        }


        private void dtgSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dtgSanPham.CurrentRow.Cells["Mã sản phẩm"].Value.ToString();
            txtTenSP.Text = dtgSanPham.CurrentRow.Cells["Tên sản phẩm"].Value.ToString();
            txtDVT.Text = dtgSanPham.CurrentRow.Cells["Đơn vị tính"].Value.ToString();
            txtSoluong.Text = dtgSanPham.CurrentRow.Cells["Số lượng"].Value.ToString();
            txtDongia.Text = dtgSanPham.CurrentRow.Cells["Đơn giá"].Value.ToString();
            btnSuaSP.Enabled = true;
            btnXoaSP.Enabled = true;
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spSanpham_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PK_sSanphamID", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("sTensanpham", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("sDonvitinh", txtDVT.Text);
                    cmd.Parameters.AddWithValue("iSoluong", txtSoluong.Text);
                    cmd.Parameters.AddWithValue("fDongia", txtDongia.Text);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Sửa thành công !!!");
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công !!!");
                    }
                }
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("spSanpham_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PK_sSanphamID", txtMaSP.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sản phẩm " + txtMaSP.Text + " thành công!");
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Không có sản phẩm nào được xóa!");
                        }
                    }
                }
            }
        }

        private void btnThoatSP_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                F_Trangchu f_trangchu = new F_Trangchu();
                f_trangchu.Show();
            }
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDVT.ResetText();
            txtSoluong.ResetText();
            txtDongia.ResetText();
            txtMaSP.Focus();
        }

        private void GetSizeColumn()
        {
            dtgSanPham.Columns[0].Width = 150;
            dtgSanPham.Columns[1].Width = 520;
            dtgSanPham.Columns[2].Width = 120;
            dtgSanPham.Columns[3].Width = 120;
            dtgSanPham.Columns[4].Width = 120;
        }

        private void F_Sanpham_Load(object sender, EventArgs e)
        {
            hienthi();
            GetSizeColumn();
        }

        private void btnInSP_Click(object sender, EventArgs e)
        {
            F_DanhsachSP formReport = new F_DanhsachSP();

            // Hiển thị form F_Report dưới dạng hộp thoại
            formReport.ShowDialog();
        }
    }
}
