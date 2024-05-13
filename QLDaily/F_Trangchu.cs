using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDaily
{
    public partial class F_Trangchu : Form
    {
        public F_Trangchu()
        {
            InitializeComponent();
        }

        private void F_Trangchu_Load(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Sanpham f_sanpham = new F_Sanpham();
            f_sanpham.Show();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Hoadon f_hoadon = new F_Hoadon();
            f_hoadon.Show();
        }
    }
}
