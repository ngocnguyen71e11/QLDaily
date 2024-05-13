using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDaily
{
    public partial class F_DanhsachSP : Form
    {
        public F_DanhsachSP()
        {
            InitializeComponent();
        }

        private void F_DanhsachSP_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSanpham", cnn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);

                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                    }
                }
            }
            reportViewer1.LocalReport.ReportEmbeddedResource = "QLDaily.rpDanhsachSP.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
