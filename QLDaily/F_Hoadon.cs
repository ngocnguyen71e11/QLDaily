
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QLDaily
{
    public partial class F_Hoadon : Form
    {
        public F_Hoadon()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString);

        private void F_Hoadon_Load(object sender, EventArgs e)
        {
            if (btnThemDH != null)
            {
                btnThemDH.Enabled = true;
            }
            btnLuu.Enabled = false;
            btnSuaHD.Enabled = false;
            btnIn.Enabled = false;
            txtThanhtien.ReadOnly = true;
            if (txtMaHD.Text != "")
            {
                LoadInfoHoaDon();
                btnSuaHD.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();
            txtMahang.TextChanged += new EventHandler(txtMahang_TextChanged);
            GetSizeColumn();

        }
        private void LoadInfoHoaDon()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();

                string strNgayBanQuery = "SELECT dNgaytaoHD FROM tblHoadon WHERE PK_sHoadonID = @sPK_sHoadonID";
                using (SqlCommand commandNgayBan = new SqlCommand(strNgayBanQuery, cnn))
                {
                    commandNgayBan.Parameters.AddWithValue("@@sPK_sHoadonID", txtMaHD.Text);
                    object ngayBanObj = commandNgayBan.ExecuteScalar();
                    if (ngayBanObj != null)
                    {
                        dTPNgayban.Text = ngayBanObj.ToString();
                    }
                }

                string strTongTienQuery = "SELECT fTongtien FROM tblHoadon WHERE PK_sHoadonID = @sPK_sHoadonID";
                using (SqlCommand commandTongTien = new SqlCommand(strTongTienQuery, cnn))
                {
                    commandTongTien.Parameters.AddWithValue("@sPK_sHoadonID", txtMaHD.Text);
                    object tongTienObj = commandTongTien.ExecuteScalar();
                    if (tongTienObj != null)
                    {
                        txtTongtien.Text = tongTienObj.ToString();
                        lbBangchu.Text = "Bằng chữ: " + ChuyenSoSangChu(tongTienObj.ToString());
                    }
                }

                cnn.Close();
            }
        }


        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            // Xóa các dấu ","
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1;

            int count = 0; // Đếm số lần đã thêm "tỷ", "triệu", "nghìn"
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                {
                    // Xét phần dư của độ dài chuỗi số để xác định đơn vị đang xét là tỷ, triệu, hay nghìn
                    switch ((mLen - i) % 9)
                    {
                        case 0:
                            mTemp = mTemp + " nghìn";
                            count++;
                            break;
                        case 6:
                            mTemp = mTemp + " triệu";
                            count++;
                            break;
                        case 3:
                            mTemp = mTemp + " tỷ";
                            count++;
                            break;
                        default:
                            switch ((mLen - i) % 3)
                            {
                                case 2:
                                    mTemp = mTemp + " trăm";
                                    break;
                                case 1:
                                    mTemp = mTemp + " mươi";
                                    break;
                            }
                            break;
                    }
                }
                else if ((mLen - i) % 3 == 0 && count < 3) // Xét mỗi 3 chữ số để thêm "tỷ", "triệu", "nghìn"
                {
                    mTemp += " " + ((mLen - i) / 3 == 1 ? "nghìn" : ((mLen - i) / 3 == 2 ? "triệu" : "tỷ"));
                    count++;
                }
            }

            // Thay thế và chuẩn hóa kết quả
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            mTemp = mTemp.Replace("không mươi ", "linh ");
            mTemp = mTemp.Replace("mươi không", "mươi");
            mTemp = mTemp.Replace("một mươi", "mười");
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            mTemp = mTemp.Trim();
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }

        private void LoadDataGridView()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                string sql = "SELECT cthd.FK_sSanphamID, sp.sTensanpham, cthd.iSoluongmua, sp.sDonvitinh, sp.fDongia, cthd.fTongHD " +
                         "FROM tbl_CTHoadon AS cthd INNER JOIN tblSanpham AS sp ON cthd.FK_sSanphamID = sp.PK_sSanphamID " +
                         "WHERE cthd.FK_sHoadonID = N'" + txtMaHD.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dgCTHD.DataSource = dt;
                        dgCTHD.Columns[0].HeaderText = "Mã hàng";
                        dgCTHD.Columns[1].HeaderText = "Tên hàng";
                        dgCTHD.Columns[2].HeaderText = "Số lượng";
                        dgCTHD.Columns[3].HeaderText = "Đơn vị tính";
                        dgCTHD.Columns[4].HeaderText = "Đơn giá";
                        dgCTHD.Columns[5].HeaderText = "Thành tiền";
                        GetSizeColumn();
                        dgCTHD.AllowUserToAddRows = false;
                        dgCTHD.EditMode = DataGridViewEditMode.EditProgrammatically;

                        cnn.Close();
                    }
                }
            }

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSuaHD.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            txtThanhtien.Text = "0";
            ResetValues();
            txtMaHD.Text = CreateKey("HDB");
            txtMahang.Focus();
            LoadDataGridView();
        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        private void ResetValues()
        {
            txtMaHD.Text = "";
            dTPNgayban.Text = DateTime.Now.ToShortDateString();
            txtTongtien.Text = "0";
            lbBangchu.Text = "Bằng chữ: ";
            txtMahang.Text = "";
            txtSoluong.Text = "";
        }
        private void txtMahang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                // Thực hiện lưu dữ liệu và hiển thị
                LuuVaHienThiDuLieu();
            }
        }
        private void txtMahang_TextChanged(object sender, EventArgs e)
        {

            if (txtMahang.Text.Length == 13)
            {
                // Khi chuỗi mã đủ 13 ký tự, kích hoạt sự kiện thêm số lượng
                txtSoluong.Enabled = true;
                txtSoluong.Focus();
                if (!string.IsNullOrEmpty(txtMahang.Text))
                {
                    txtSoluong.Text = "1";
                }
                else
                {
                    txtSoluong.Text = "";
                }
            }
            else
            {
                // Nếu chuỗi mã không đủ 13 ký tự, vô hiệu hóa việc nhập số lượng
                txtSoluong.Text = "";
            }
            if (!string.IsNullOrEmpty(txtMahang.Text) && !string.IsNullOrEmpty(txtSoluong.Text) && !string.IsNullOrEmpty(txtSoluong.Text.Trim()) && txtSoluong.Text != "0")
            {
                if (!isSavingData)
                {
                    LuuVaHienThiDuLieu();
                }
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMahang.Text) && !string.IsNullOrEmpty(txtSoluong.Text) && !string.IsNullOrEmpty(txtSoluong.Text.Trim()) && txtSoluong.Text != "0")
            {
                if (!isSavingData)
                {
                    LuuVaHienThiDuLieu();
                }
            }
        }
        bool isSavingData = false;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            allowSave = true;
            LuuVaHienThiDuLieu();
        }
        private void LuuVaHienThiDuLieu()
        {
            if (!allowSave)
                return;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                isSavingData = true;
                cnn.Open();
                double sl = 0;
                string sql = "SELECT iSoluong FROM tblSanpham WHERE PK_sSanphamID = @PK_sSanphamID";
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@PK_sSanphamID", txtMahang.Text);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sl = Convert.ToDouble(result);
                    }
                }

                if (Convert.ToDouble(txtSoluong.Text) > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoluong.Text = "";
                    txtSoluong.Focus();
                    return;
                }
                // Kiểm tra xem có bản ghi nào trong tblHoadon có PK_sHoadonID là giá trị của txtMaHD.Text không
                sql = "SELECT COUNT(*) FROM tblHoadon WHERE PK_sHoadonID = @MaHoaDon";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Thay thế tham số @MaHoaDon bằng giá trị của txtMaHD.Text
                        command.Parameters.AddWithValue("@MaHoaDon", txtMaHD.Text);

                        int count = (int)command.ExecuteScalar();

                        // Nếu không có bản ghi nào tồn tại, thêm một bản ghi mới vào tblHoadon
                        if (count == 0)
                        {
                            dTPNgayban.Format = DateTimePickerFormat.Custom;
                            dTPNgayban.CustomFormat = "yyyy-MM-dd";

                            // Tạo câu lệnh SQL để thêm bản ghi mới vào tblHoadon
                            sql = "INSERT INTO tblHoadon (PK_sHoadonID, dNgaytaoHD, fTongtien) VALUES (@MaHoaDon, @NgayTaoHD, @TongTien)";

                            // Thực thi câu lệnh SQL
                            using (SqlCommand insertCommand = new SqlCommand(sql, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@MaHoaDon", txtMaHD.Text.Trim());
                                insertCommand.Parameters.AddWithValue("@NgayTaoHD", dTPNgayban.Value);
                                insertCommand.Parameters.AddWithValue("@TongTien", txtTongtien.Text);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Insert a new record into tbl_CTHoadon
                if (txtMahang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMahang.Focus();
                    return;
                }
                if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoluong.Text = "";
                    txtSoluong.Focus();
                    return;
                }
                sql = "SELECT FK_sSanphamID FROM tbl_CTHoadon WHERE FK_sSanphamID=N'" + txtMahang + "' AND FK_sHoadonID = N'" + txtMaHD.Text.Trim() + "'";
                if (CheckKey(sql))
                {
                    MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValuesHang();
                    txtMahang.Focus();
                    return;
                }
                sl = 0;
                sql = "SELECT iSoluong FROM tblSanpham WHERE PK_sSanphamID = @PK_sSanphamID";
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@PK_sSanphamID", txtMahang.Text);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sl = Convert.ToDouble(result);
                    }
                }

                if (Convert.ToDouble(txtSoluong.Text) > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoluong.Text = "";
                    txtSoluong.Focus();
                    return;
                }
                double donGia = 0;
                string sqlSelectDonGia = "SELECT fDongia FROM tblSanpham WHERE PK_sSanphamID = @PK_sSanphamID";

                // Thực hiện truy vấn để lấy giá đơn vị từ bảng tblSanpham
                using (SqlCommand commandSelectDonGia = new SqlCommand(sqlSelectDonGia, cnn))
                {
                    commandSelectDonGia.Parameters.AddWithValue("@PK_sSanphamID", txtMahang.Text.Trim());
                    object result = commandSelectDonGia.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        donGia = Convert.ToDouble(result);
                    }
                }

                // Tính giá trị của txtThanhtien
                double thanhTien = Convert.ToDouble(txtSoluong.Text) * donGia;
                sql = "INSERT INTO tbl_CTHoadon(FK_sSanphamID,FK_sHoadonID,iSoluongmua,fTongHD) VALUES(@FK_sSanphamID, @FK_sHoadonID, @iSoluongmua, @fTongHD)";
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@FK_sSanphamID", txtMahang.Text.Trim());
                    command.Parameters.AddWithValue("@FK_sHoadonID", txtMaHD.Text.Trim());
                    command.Parameters.AddWithValue("@iSoluongmua", Convert.ToDouble(txtSoluong.Text));
                    command.Parameters.AddWithValue("@fTongHD", thanhTien);
                    command.ExecuteNonQuery();
                }
                LoadDataGridView();
                // Calculate the new quantity in stock
                double SLcon = sl - Convert.ToDouble(txtSoluong.Text);

                // Update the quantity in stock in tblHang
                string sqlUpdate = "UPDATE tblSanpham SET iSoluong = @SoLuong WHERE PK_sSanphamID = @MaHang";
                using (SqlCommand command = new SqlCommand(sqlUpdate, cnn))
                {
                    command.Parameters.AddWithValue("@SoLuong", SLcon);
                    command.Parameters.AddWithValue("@MaHang", txtMahang.Text); // Sử dụng .Text để lấy giá trị từ TextBox
                    command.ExecuteNonQuery();
                }


                // Get the current total price from tblHDBan
                double tong = 0;
                double Tongmoi = 0;
                using (SqlCommand command = new SqlCommand("SELECT fTongtien FROM tblHoadon WHERE PK_sHoadonID = @MaHDBan", cnn))
                {
                    command.Parameters.AddWithValue("@MaHDBan", txtMaHD.Text);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        tong = Convert.ToDouble(result);
                    }
                }

                Tongmoi = tong + thanhTien;
                sqlUpdate = "UPDATE tblHoadon SET fTongtien = @TongTien WHERE PK_sHoadonID = @MaHDBan";
                using (SqlCommand command = new SqlCommand(sqlUpdate, cnn))
                {
                    command.Parameters.AddWithValue("@TongTien", Tongmoi);
                    command.Parameters.AddWithValue("@MaHDBan", txtTongtien.Text.Trim());
                    command.ExecuteNonQuery();
                }

                txtTongtien.Text = Tongmoi.ToString();
                lbBangchu.Text = "Bằng chữ: " + ChuyenSoSangChu(Tongmoi.ToString());

                // Update the total price in tblHDBan
                sql = "UPDATE tblHoadon SET fTongtien = @TongTien WHERE PK_sHoadonID = @MaHDBan";
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@TongTien", Tongmoi);
                    command.Parameters.AddWithValue("@MaHDBan", txtMaHD.Text);
                    command.ExecuteNonQuery();
                }
                // Update UI elements and enable buttons
                txtTongtien.Text = Tongmoi.ToString();
                lbBangchu.Text = "Bằng chữ: " + ChuyenSoSangChu(Tongmoi.ToString());
                ResetValuesHang();
                btnSuaHD.Enabled = true;
                btnThem.Enabled = true;
                btnIn.Enabled = true;
                isSavingData = false;
                txtMahang.Focus();
            }
        }

        public static bool CheckKey(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                DataTable table = new DataTable();
                dap.Fill(table);
                if (table.Rows.Count > 0)
                    return true;
                else return false;
            }
        }
        private void ResetValuesHang()
        {
            txtMahang.Text = "";
            txtSoluong.Text = "";
            txtTongtien.Text = "0";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
            F_Trangchu formTrangchu = new F_Trangchu();
            formTrangchu.Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHD.Text; // Đây là mã hóa đơn đang hiển thị, bạn cần thay đổi cho phù hợp

            // Tạo một thể hiện mới của form F_Report và truyền mã hóa đơn
            F_Report formReport = new F_Report(maHoaDon);

            // Hiển thị form F_Report dưới dạng hộp thoại
            formReport.ShowDialog();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spCTHoadon_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_sSanphamID", txtMahang.Text);
                    cmd.Parameters.AddWithValue("@FK_sHoadonID", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@iSoluongmua", txtSoluong.Text);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Sửa thành công !!!");
                        UpdateCTHoadonAndHoadon(txtMahang.Text, txtMaHD.Text);
                        LoadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công !!!");
                    }
                }
            }
        }

        private void UpdateCTHoadonAndHoadon(string FK_sSanphamID, string FK_sHoadonID)
        {
            double donGia = 0;
            double sl = 0;
            double thanhTien = 0;
            double Tongmoi = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyDaily"].ConnectionString))
            {
                cnn.Open();
                string sqlSelectSoLuong = "SELECT iSoluong FROM tblSanpham WHERE PK_sSanphamID = @PK_sSanphamID";
                using (SqlCommand commandSelectSoLuong = new SqlCommand(sqlSelectSoLuong, cnn))
                {
                    commandSelectSoLuong.Parameters.AddWithValue("@PK_sSanphamID", FK_sSanphamID);
                    object result = commandSelectSoLuong.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sl = Convert.ToDouble(result);
                    }
                }

                // Kiểm tra số lượng mới mua có lớn hơn số lượng trong kho không
                if (Convert.ToDouble(txtSoluong.Text) > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoluong.Text = "";
                    txtSoluong.Focus();
                    return;
                }

                // Lấy giá đơn vị của sản phẩm từ tblSanpham
                string sqlSelectDonGia = "SELECT fDongia FROM tblSanpham WHERE PK_sSanphamID = @PK_sSanphamID";
                using (SqlCommand commandSelectDonGia = new SqlCommand(sqlSelectDonGia, cnn))
                {
                    commandSelectDonGia.Parameters.AddWithValue("@PK_sSanphamID", FK_sSanphamID);
                    object result = commandSelectDonGia.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        donGia = Convert.ToDouble(result);
                    }
                }

                // Tính toán thành tiền mới
                thanhTien = Convert.ToDouble(txtSoluong.Text) * donGia;

                // Cập nhật thành tiền trong tbl_CTHoadon
                string sqlUpdateCTHoadon = "UPDATE tbl_CTHoadon SET iSoluongmua = @iSoluongmua, fTongHD = @fTongHD WHERE FK_sSanphamID = @FK_sSanphamID AND FK_sHoadonID = @FK_sHoadonID";
                using (SqlCommand commandUpdateCTHoadon = new SqlCommand(sqlUpdateCTHoadon, cnn))
                {
                    commandUpdateCTHoadon.Parameters.AddWithValue("@iSoluongmua", Convert.ToDouble(txtSoluong.Text));
                    commandUpdateCTHoadon.Parameters.AddWithValue("@fTongHD", thanhTien);
                    commandUpdateCTHoadon.Parameters.AddWithValue("@FK_sSanphamID", FK_sSanphamID);
                    commandUpdateCTHoadon.Parameters.AddWithValue("@FK_sHoadonID", FK_sHoadonID);
                    commandUpdateCTHoadon.ExecuteNonQuery();
                }

                // Tính toán tổng mới của hóa đơn
                double tong = 0;
                using (SqlCommand commandSelectTongTien = new SqlCommand("SELECT fTongtien FROM tblHoadon WHERE PK_sHoadonID = @MaHDBan", cnn))
                {
                    commandSelectTongTien.Parameters.AddWithValue("@MaHDBan", FK_sHoadonID);
                    object result = commandSelectTongTien.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        tong = Convert.ToDouble(result);
                    }
                }
                Tongmoi = tong + thanhTien;

                // Cập nhật tổng tiền trong tblHoadon
                string sqlUpdateTongTien = "UPDATE tblHoadon SET fTongtien = @TongTien WHERE PK_sHoadonID = @MaHDBan";
                using (SqlCommand commandUpdateTongTien = new SqlCommand(sqlUpdateTongTien, cnn))
                {
                    commandUpdateTongTien.Parameters.AddWithValue("@TongTien", Tongmoi);
                    commandUpdateTongTien.Parameters.AddWithValue("@MaHDBan", FK_sHoadonID);
                    commandUpdateTongTien.ExecuteNonQuery();
                }

                // Cập nhật số lượng còn lại trong tblSanpham
                double SLcon = sl - Convert.ToDouble(txtSoluong.Text);
                string sqlUpdateSoLuong = "UPDATE tblSanpham SET iSoluong = @SoLuong WHERE PK_sSanphamID = @MaHang";
                using (SqlCommand commandUpdateSoLuong = new SqlCommand(sqlUpdateSoLuong, cnn))
                {
                    commandUpdateSoLuong.Parameters.AddWithValue("@SoLuong", SLcon);
                    commandUpdateSoLuong.Parameters.AddWithValue("@MaHang", FK_sSanphamID);
                    commandUpdateSoLuong.ExecuteNonQuery();
                }
                cnn.Close();
                // Cập nhật lại các UI elements và các giá trị
                txtTongtien.Text = Tongmoi.ToString();
                lbBangchu.Text = "Bằng chữ: " + ChuyenSoSangChu(Tongmoi.ToString());
                ResetValuesHang();
            }
                // Lấy số lượng còn lại của sản phẩm từ tblSanpham
                
        }

        private void GetSizeColumn()
        {
            dgCTHD.Columns[0].Width = 240;
            dgCTHD.Columns[1].Width = 540;
            dgCTHD.Columns[2].Width = 190;
            dgCTHD.Columns[3].Width = 190;
            dgCTHD.Columns[4].Width = 190;
            dgCTHD.Columns[5].Width = 190;
        }

        private void dgCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            allowSave = false;
            if (e.RowIndex >= 0 && e.RowIndex < dgCTHD.Rows.Count)
            {
                DataGridViewRow row = dgCTHD.Rows[e.RowIndex];
                string maHang = row.Cells[0].Value.ToString(); // Mã hàng
                string soLuong = row.Cells[2].Value.ToString(); // Số lượng
                                                                // Hiển thị thông tin lên các điều khiển tương ứng
                txtMahang.Text = maHang;
                txtSoluong.Text = soLuong;

                // Cho phép chỉnh sửa dữ liệu
                txtMahang.Enabled = true;
                txtSoluong.Enabled = true;

                // Vô hiệu hóa việc lưu tự động
                btnLuu.Enabled = false;
            }
        }
        private bool allowSave = true;
    }
}
