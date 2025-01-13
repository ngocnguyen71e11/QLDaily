using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDaily
{
    public partial class Khachhang : Form
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString);
        public Khachhang()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            hienthi();
            GetSizeColumn();
        }
        public void hienthi()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                string sql = "SELECT * FROM tblKhachhang";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dGVdsKhachhang.DataSource = dt;
                        dGVdsKhachhang.Columns[0].HeaderText = "Tên khách hàng";
                        dGVdsKhachhang.Columns[2].HeaderText = "Số điện thoại";
                        dGVdsKhachhang.Columns[1].HeaderText = "Địa chỉ";
                        cnn.Close();
                    }
                }
            }
        }
        private void GetSizeColumn()
        {
            dGVdsKhachhang.Columns[0].Width = 250;
            dGVdsKhachhang.Columns[1].Width = 550;
            dGVdsKhachhang.Columns[2].Width = 220;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("sTenkhachhang", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("sDienthoai", txtSDT.Text);
                    cmd.Parameters.AddWithValue("sDiachi", txtDiachi.Text);
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
                using (SqlCommand cmd = new SqlCommand("spKhachhang_CheckID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("sDienthoai", txtSDT.Text);
                    var i = cmd.ExecuteScalar();
                    cnn.Close();
                    if (i != null)
                    {
                        MessageBox.Show("Số điện thoại này đã tồn tại");
                        return 0;
                    }
                    else
                        return 1;
                }

            }
        }

        private void dGVdsKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenKH.Text = dGVdsKhachhang.CurrentRow.Cells["sTenkhachhang"].Value.ToString();
            txtDiachi.Text = dGVdsKhachhang.CurrentRow.Cells["sDiachi"].Value.ToString();
            txtSDT.Text = dGVdsKhachhang.CurrentRow.Cells["sDienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("sTenkhachhang", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("sDiachi", txtDiachi.Text);
                    cmd.Parameters.AddWithValue("sDienthoai", txtSDT.Text);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("spKhachhang_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sDienthoai", txtSDT.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa Khách hàng " + txtTenKH.Text + " thành công!");
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Không có khách hàng nào được xóa!");
                        }
                    }
                }
            }
        }
    }
}
