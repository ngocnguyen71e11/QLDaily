using Microsoft.Reporting.WinForms;
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
    public partial class F_Report : Form
    {
        public F_Report()
        {
            InitializeComponent();
        }
        private string maHoaDon;

        public F_Report(string maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }
        private void F_Report_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM v_Hoadonbanhang WHERE MaHoaDon = @MaHoaDon GROUP BY TenKhachHang, SDT, Diachi, MaHoaDon, NgayLapHoaDon, Tongtien, MaSanPham, SoLuongMua, Chietkhau, Thanhtien, TenSanPham, DVT, Dongia ", cnn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataset.Tables[0]));
                    }
                }
            }
            reportViewer1.LocalReport.ReportEmbeddedResource = "QLDaily.Report1.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
