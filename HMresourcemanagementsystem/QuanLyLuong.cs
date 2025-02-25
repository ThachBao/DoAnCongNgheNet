using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace HMresourcemanagementsystem
{
    public partial class QuanLyLuong : Form
    {
        connection kn = new connection();
        SqlConnection connect;
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataTable dt;
        SqlDataAdapter adap1;
        DataTable dt1;
        SqlCommandBuilder cmbd;
        BindingSource bindingSource = new BindingSource();
        public QuanLyLuong()
        {
            InitializeComponent();
            connect = kn.con;
            button1.Click += button1_Click;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                this.Close();
            }
        }

        void xoathongtin()
        {
            txt_maluong.Clear();
            cbo_manv.SelectedValue = -1;
            txt_chucvu.Clear();
            txt_phongban.Clear();
            txt_bophan.Clear();
            txt_luongcb.Clear();
            txt_hesopc.Clear();
            txt_pccd.Clear();
            txt_luong.Clear();
        }
        void anthongtin()
        {
            txt_maluong.Enabled = false;
            cbo_manv.Enabled = false;
            txt_chucvu.Enabled = false;
            txt_phongban.Enabled = false;
            txt_bophan.Enabled = false;
            txt_luongcb.Enabled = false;
            txt_hesopc.Enabled = false;
            txt_pccd.Enabled = false;
            txt_luong.Enabled = false;
        }
        void hienthongtin()
        {
            txt_maluong.Enabled = true;
            cbo_manv.Enabled = true;
            txt_luongcb.Enabled = true;
            txt_hesopc.Enabled = true;
            txt_pccd.Enabled = true;
        }
        void anthongtintien()
        {
            txt_tienkt.Enabled = false;
            txt_tienkl.Enabled = false;
            txt_tienda.Enabled = false;
            txt_tienpc.Enabled = false;
            txt_tienbhxh.Enabled = false;
            txt_tienbhyt.Enabled = false;
            txt_tienbhtn.Enabled = false;
            txt_tiencongdoan.Enabled = false;
        }
        void xoathongtintien()
        {
            txt_tienkt.Clear();
            txt_tienkl.Clear();
            txt_tienda.Clear();
            txt_tienpc.Clear();
            txt_tienbhxh.Clear();
            txt_tienbhyt.Clear();
            txt_tienbhtn.Clear();
            txt_tiencongdoan.Clear();
        }
        void loadNV()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT * FROM Nhanvien";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_manv.DataSource = dt;
                cbo_manv.DisplayMember = "MaNV";
                cbo_manv.ValueMember = "MaNV";
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }
        void LoadForm()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM Luong";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_luong.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_maluong.Text = dgv_luong.Rows[0].Cells["MaLuong"].Value.ToString();
                    cbo_manv.SelectedValue = dgv_luong.Rows[0].Cells["MaNV"].Value.ToString();
                    txt_chucvu.Text = dgv_luong.Rows[0].Cells["MaChucVu"].Value.ToString();
                    txt_phongban.Text = dgv_luong.Rows[0].Cells["MaPhong"].Value.ToString();
                    txt_bophan.Text = dgv_luong.Rows[0].Cells["MABOPHAN"].Value?.ToString();
                    txt_luongcb.Text = dgv_luong.Rows[0].Cells["LuongCoBan"].Value.ToString();
                    txt_hesopc.Text = dgv_luong.Rows[0].Cells["HeSoPhuCap"].Value.ToString();
                    txt_pccd.Text = dgv_luong.Rows[0].Cells["PhuCapCoDinh"].Value.ToString();
                    txt_luong.Text = dgv_luong.Rows[0].Cells["LuongThucNhan"].Value.ToString();
                }
                else
                {
                    xoathongtin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void QuanLyLuong_Load(object sender, EventArgs e)
        {
            anthongtin();
            anthongtintien();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_luong.ReadOnly = true;
            dgv_luong.AllowUserToAddRows = false;
            loadNV();
            LoadForm();
        }

        private void dgv_luong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_luong.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_maluong.Text = dgv_luong.Rows[index].Cells["MaLuong"].Value.ToString();
                cbo_manv.Text = dgv_luong.Rows[index].Cells["MaNV"].Value.ToString();
                txt_chucvu.Text = dgv_luong.Rows[index].Cells["MaChucVu"].Value.ToString();
                txt_phongban.Text = dgv_luong.Rows[index].Cells["MaPhong"].Value.ToString();
                txt_bophan.Text = dgv_luong.Rows[index].Cells["MaBoPhan"].Value.ToString();
                txt_luongcb.Text = dgv_luong.Rows[index].Cells["LuongCoBan"].Value.ToString();
                txt_hesopc.Text = dgv_luong.Rows[index].Cells["HeSoPhuCap"].Value.ToString();
                txt_pccd.Text = dgv_luong.Rows[index].Cells["PhuCapCoDinh"].Value.ToString();
                txt_luong.Text = dgv_luong.Rows[index].Cells["LuongThucNhan"].Value.ToString();

            }
            anthongtin();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            hienthongtin();
            xoathongtin();
            xoathongtintien();
            txt_maluong.Focus();
            btn_them.Enabled=true;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            dgv_luong.ReadOnly = false;
            for (int i = 0; i < dgv_luong.Rows.Count - 1; i++)
            {
                dgv_luong.Rows[i].ReadOnly = true;
            }
            dgv_luong.FirstDisplayedScrollingRowIndex = dgv_luong.Rows.Count - 1;
            dgv_luong.AllowUserToAddRows = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_maluong.Text) || string.IsNullOrEmpty(txt_luongcb.Text)
                    || string.IsNullOrEmpty(txt_pccd.Text) || string.IsNullOrEmpty(txt_hesopc.Text)
                    || string.IsNullOrEmpty(cbo_manv.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi các giá trị nhập từ chuỗi sang số thập phân
                decimal luongCoBan = decimal.Parse(txt_luongcb.Text.Replace(",", "").Replace(".", ""));
                decimal heSoPhuCap = decimal.Parse(txt_hesopc.Text.Replace(",", "."));
                decimal phuCapCoDinh = decimal.Parse(txt_pccd.Text.Replace(",", "").Replace(".", ""));

                // Kiểm tra xem MaLuong đã tồn tại hay chưa
                string checkMaLuongSql = "SELECT COUNT(*) FROM Luong WHERE MaLuong = @maluong";
                cmd = new SqlCommand(checkMaLuongSql, connect);
                cmd.Parameters.AddWithValue("@maluong", txt_maluong.Text);

                connect.Open();
                int countMaLuong = (int)cmd.ExecuteScalar();
                connect.Close(); // Đóng kết nối sau khi kiểm tra MaLuong

                if (countMaLuong > 0)
                {
                    MessageBox.Show("Mã lương này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem MANV đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM NhanVien WHERE MANV = @manv";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();
                connect.Close(); // Đóng kết nối sau khi kiểm tra MANV

                if (count == 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại. Vui lòng chọn mã hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert và đặt LuongThucNhan = 0
                string sqlInsert = "INSERT INTO Luong (MaLuong, MaNV, MaChucVu, MaPhong, MaBoPhan, LuongCoBan, HeSoPhuCap, PhuCapCoDinh, LuongThucNhan)" +
                                   "VALUES (@maluong, @manv, @chucvu, @phongban, @bophan, @luongcb, @hesopc, @pccd, @luongthucnhan)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@maluong", txt_maluong.Text);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
                cmd.Parameters.AddWithValue("@phongban", txt_phongban.Text);
                cmd.Parameters.AddWithValue("@bophan", txt_bophan.Text);
                cmd.Parameters.AddWithValue("@chucvu", txt_chucvu.Text);
                cmd.Parameters.AddWithValue("@luongcb", luongCoBan);
                cmd.Parameters.AddWithValue("@hesopc", heSoPhuCap);
                cmd.Parameters.AddWithValue("@pccd", phuCapCoDinh);
                cmd.Parameters.AddWithValue("@luongthucnhan", 0);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close(); // Đóng kết nối sau khi thêm dữ liệu

                LoadForm();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
                txt_maluong.Focus();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }





        private void cbo_manv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_manv.SelectedValue != null)
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    // Lấy mã nhân viên đã chọn
                    string maNV = cbo_manv.SelectedValue.ToString();

                    // Lấy thông tin phòng ban, bộ phận và chức vụ từ bảng NhanVien
                    string sql = "SELECT MaChucVu, MaPhong, MaBoPhan FROM Luong WHERE MaNV = @manv";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.Parameters.AddWithValue("@manv", maNV);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Gán giá trị cho các ComboBox chức vụ, phòng ban và bộ phận
                        txt_chucvu.Text = reader["MaChucVu"].ToString();
                        txt_phongban.Text = reader["MaPhong"].ToString();
                        txt_bophan.Text = reader["MaBoPhan"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_luong.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_luong.SelectedRows)
                        {
                            string manv = r.Cells["MaNV"].Value.ToString();
                            string sql = "DELETE FROM Luong WHERE MaNV=@manv";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@manv", manv);
                            cmd.ExecuteNonQuery();
                        }
                        LoadForm();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xoathongtin();
                        anthongtin(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            hienthongtin();
            txt_maluong.Enabled = false ;
            cbo_manv.Enabled = false ;
            btn_luu.Enabled = true;
            btn_them.Enabled = btn_xoa.Enabled = false;
            txt_luongcb.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Lấy tên đăng nhập từ ô hiện tại trong DataGridView
                string maaluong = txt_maluong.Text;

                string sqlUpdate = "UPDATE Luong SET LuongCoBan=@luongcb, HeSoPhuCap=@hesopc, PhuCapCoDinh=@pccd Where MaLuong=@maluong";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@maluong", maaluong);
                cmd.Parameters.AddWithValue("@luongcb", txt_luongcb.Text);
                cmd.Parameters.AddWithValue("@hesopc", txt_hesopc.Text);
                cmd.Parameters.AddWithValue("@pccd", txt_pccd.Text);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                LoadForm();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                btn_luu.Enabled = false;
                xoathongtin();
                anthongtin();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sqlQuery = "";
                if (txt_search.Text != null) // Tìm kiếm theo mã nhân viên
                {
                    if (string.IsNullOrEmpty(txt_search.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã phòng ban để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM Luong WHERE MaPhong = @maphong";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@maphong", txt_search.Text);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_luong.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void btn_desearch_Click(object sender, EventArgs e)
        {
            LoadForm();
            txt_search.Clear();
        }
        
        decimal tinhTienKhenThuong(string manv)
        {
            if (string.IsNullOrEmpty(txt_thang.Text) || string.IsNullOrEmpty(txt_nam.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int thang = Convert.ToInt32(txt_thang.Text);
            int nam = Convert.ToInt32(txt_nam.Text);
            decimal tienkhenthuong = 0;

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT COUNT(*) AS SoLanKhenThuong
                       FROM KhenThuongKyLuat AS ktkl
                       WHERE MaNV = @MaNV 
                             AND ktkl.Loai = N'Khen thưởng' 
                             AND MONTH(ktkl.Ngay) = @Thang 
                             AND YEAR(ktkl.Ngay) = @Nam";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    int soLanKhenThuong = Convert.ToInt32(cmd.ExecuteScalar());
                    tienkhenthuong = soLanKhenThuong * 200000; // Mỗi lần khen thưởng được 200,000
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienkhenthuong;
        }


        decimal tinhTienKyLuat(string manv)
        {
            if (string.IsNullOrEmpty(txt_thang.Text) || string.IsNullOrEmpty(txt_nam.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int thang = Convert.ToInt32(txt_thang.Text);
            int nam = Convert.ToInt32(txt_nam.Text);
            decimal tienkyluat = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT COUNT(*) AS SoLanKyLuat
                       FROM KhenThuongKyLuat AS ktkl
                       WHERE MaNV = @MaNV 
                             AND ktkl.Loai = N'Kỉ luật' 
                             AND MONTH(ktkl.Ngay) = @Thang 
                             AND YEAR(ktkl.Ngay) = @Nam";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    int soLanKyLuat = Convert.ToInt32(cmd.ExecuteScalar());
                    tienkyluat = soLanKyLuat * 100000; // Mỗi lần kỷ luật bị phạt 100,000
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienkyluat;
        }


        decimal tinhTienDuAn(string manv)
        {
            if (string.IsNullOrEmpty(txt_thang.Text) || string.IsNullOrEmpty(txt_nam.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int thang = Convert.ToInt32(txt_thang.Text);
            int nam = Convert.ToInt32(txt_nam.Text);
            decimal tienDuAn = 0;

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Đếm số lần tham gia với vai trò Trưởng nhóm
                string sql = @"SELECT COUNT(*) AS SoLanTruongNhom
                       FROM PhanCong AS PC
                       WHERE MaNV = @MaNV 
                             AND PC.VaiTro = N'Trưởng nhóm' 
                             AND (MONTH(PC.NgayThamGia) = @Thang OR MONTH(PC.NgayKetThuc) = @Thang)
                             AND (YEAR(PC.NgayThamGia) = @Nam OR YEAR(PC.NgayKetThuc) = @Nam)";

                // Đếm số lần tham gia với vai trò Nhân viên
                string sql1 = @"SELECT COUNT(*) AS SoLanNhanVien
                        FROM PhanCong AS PC
                        WHERE MaNV = @MaNV 
                              AND PC.VaiTro = N'Nhân viên' 
                              AND (MONTH(PC.NgayThamGia) = @Thang OR MONTH(PC.NgayKetThuc) = @Thang)
                              AND (YEAR(PC.NgayThamGia) = @Nam OR YEAR(PC.NgayKetThuc) = @Nam)";

                int soLanTruongNhom = 0;
                int soLanNhanVien = 0;

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    soLanTruongNhom = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd1 = new SqlCommand(sql1, connect))
                {
                    cmd1.Parameters.AddWithValue("@MaNV", manv);
                    cmd1.Parameters.AddWithValue("@Thang", thang);
                    cmd1.Parameters.AddWithValue("@Nam", nam);
                    soLanNhanVien = Convert.ToInt32(cmd1.ExecuteScalar());
                }

                // Tính tổng tiền dự án
                tienDuAn = (soLanTruongNhom * 1000000) + (soLanNhanVien * 500000);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }

            return tienDuAn;
        }


        decimal tinhTienPhuCap(string manv)
        {
            decimal tienphucap = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT (PhuCapCoDinh*HeSoPhuCap) AS TienPhuCap
                               FROM Luong
                               WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    tienphucap = Convert.ToDecimal(cmd.ExecuteScalar());
                    tienphucap = Math.Round(tienphucap,2);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienphucap;
        }

        decimal tinhTienBHXH(string manv)
        {
            decimal tienBHXH = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT (LuongCoBan*0.08) AS TienBHXH
                               FROM Luong
                               WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    tienBHXH = Convert.ToDecimal(cmd.ExecuteScalar());
                    tienBHXH = Math.Round(tienBHXH, 2);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienBHXH;
        }

        decimal tinhTienBHYT(string manv)
        {
            decimal tienBHYT = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT (LuongCoBan*0.015) AS TienBHYT
                               FROM Luong
                               WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    tienBHYT = Convert.ToDecimal(cmd.ExecuteScalar());
                    tienBHYT = Math.Round(tienBHYT, 2);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienBHYT;
        }

        decimal tinhTienBHTN(string manv)
        {
            decimal tienBHTN = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT (LuongCoBan*0.01) AS TienBHTN
                               FROM Luong
                               WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    tienBHTN = Convert.ToDecimal(cmd.ExecuteScalar());
                    tienBHTN = Math.Round(tienBHTN, 2);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienBHTN;
        }

        decimal tinhTienPhiCD(string manv)
        {
            decimal tienCD = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"SELECT (LuongCoBan*0.01) AS TienPhiCD
                               FROM Luong
                               WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    tienCD = Convert.ToDecimal(cmd.ExecuteScalar());
                    tienCD = Math.Round(tienCD, 2);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tienCD;
        }

        decimal tinhTongLuong(string manv)
        {
            if (string.IsNullOrEmpty(txt_thang.Text) || string.IsNullOrEmpty(txt_nam.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int thang = Convert.ToInt32(txt_thang.Text);
            int nam = Convert.ToInt32(txt_nam.Text);
            decimal tongluong = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = @"
                        SELECT (((L.LuongCoBan * L.HeSoPhuCap) + L.PhuCapCoDinh)/ BC.TongNgayCong) * BC.TongNgayCong AS TONGLUONG
                        FROM Luong AS L
                        JOIN BangCong AS BC ON L.MaNV = BC.MaNV
                        WHERE 
                             L.MaNV = @MaNV ";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@MaNV", manv);


                    tongluong = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return tongluong;
        }

        private void btn_salary_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_thang.Text) || string.IsNullOrEmpty(txt_nam.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int thang = Convert.ToInt32(txt_thang.Text);
            int nam = Convert.ToInt32(txt_nam.Text);

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Lấy mã nhân viên từ ComboBox
                if (cbo_manv.SelectedValue != null)
                {
                    string manv = cbo_manv.SelectedValue.ToString();

                    // Tính các khoản phụ cấp, thưởng, bảo hiểm...
                    decimal tienkhenthuong = tinhTienKhenThuong(manv);
                    txt_tienkt.Text = tienkhenthuong.ToString();

                    decimal tienkiluat = tinhTienKyLuat(manv);
                    txt_tienkl.Text = tienkiluat.ToString();

                    decimal tienDA = tinhTienDuAn(manv);
                    txt_tienda.Text = tienDA.ToString();

                    decimal tienPC = tinhTienPhuCap(manv);
                    txt_tienpc.Text = tienPC.ToString();

                    decimal tienBHXH = tinhTienBHXH(manv);
                    txt_tienbhxh.Text = tienBHXH.ToString();

                    decimal tienBHYT = tinhTienBHYT(manv);
                    txt_tienbhyt.Text = tienBHYT.ToString();

                    decimal tienBHTN = tinhTienBHTN(manv);
                    txt_tienbhtn.Text = tienBHTN.ToString();

                    decimal tienCD = tinhTienPhiCD(manv);
                    txt_tiencongdoan.Text = tienCD.ToString();

                    decimal tienluong = tinhTongLuong(manv);

                    // Tính lương thực lãnh
                    decimal luongthuclanh = tienluong + tienkhenthuong + tienDA + tienPC - (tienkiluat + tienBHXH + tienBHYT + tienBHTN + tienCD);
                    txt_luong.Text = luongthuclanh.ToString();
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open(); // Mở kết nối nếu chưa mở
                        }

                        // SQL: Cập nhật hoặc thêm mới
                        string sqlUpdate = @"
                                        IF EXISTS (SELECT * FROM Luong WHERE MaNV = @manv)
                                        BEGIN
                                            UPDATE Luong SET LuongThucNhan = @ltn WHERE MaNV = @manv;
                                        END
                                        ELSE
                                        BEGIN
                                            INSERT INTO Luong (MaNV, LuongThucNhan) VALUES (@manv, @ltn);
                                        END";

                        cmd = new SqlCommand(sqlUpdate, connect);
                        cmd.Parameters.AddWithValue("@manv", manv);
                        cmd.Parameters.AddWithValue("@ltn", luongthuclanh);
                        cmd.ExecuteNonQuery();

                        // Làm mới DataGridView
                        LoadForm();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Lỗi SQL: {sqlEx.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close(); // Đảm bảo kết nối được đóng
                        }
                    }

                    
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }

        }
        private void ExportToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Thêm tiêu đề cột
            foreach (DataGridViewColumn column in dgv_luong.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_luong.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    csvContent.Append(cell.Value?.ToString() + ",");
                }
                csvContent.AppendLine();
            }

            // Lưu file CSV
            File.WriteAllText(filePath, csvContent.ToString());
        }
        private void ExportToExcel(string filePath)
        {
            // Sử dụng Reflection để đặt LicenseContext trước khi tạo đối tượng ExcelPackage
            Type excelPackageType = typeof(OfficeOpenXml.ExcelPackage);
            PropertyInfo licenseContextProperty = excelPackageType.GetProperty("LicenseContext");

            // Đặt LicenseContext thành NonCommercial hoặc Commercial
            licenseContextProperty.SetValue(null, OfficeOpenXml.LicenseContext.NonCommercial);

            using (OfficeOpenXml.ExcelPackage excel = new OfficeOpenXml.ExcelPackage())
            {
                // Tiếp tục với code tạo Excel như bình thường
                ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cột
                for (int i = 0; i < dgv_luong.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_luong.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_luong.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_luong.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1].Value = dgv_luong.Rows[i].Cells[j].Value;
                    }
                }

                // Lưu file Excel
                byte[] bin = excel.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
        }
        private bool daXuatBan = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!daXuatBan)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save an Export File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (filePath.EndsWith(".csv"))
                    {
                        ExportToCSV(filePath);
                        MessageBox.Show("Xuất dữ liệu thành công ra file CSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (filePath.EndsWith(".xlsx"))
                    {
                        ExportToExcel(filePath);
                        MessageBox.Show("Xuất dữ liệu thành công ra file Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                daXuatBan = true;
            }
        }
    }
}
