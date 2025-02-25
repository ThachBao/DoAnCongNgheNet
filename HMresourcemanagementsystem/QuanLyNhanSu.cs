using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMresourcemanagementsystem
{
    public partial class QuanLyNhanSu : Form
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

        
        public QuanLyNhanSu()
        {
            InitializeComponent();
            connect = kn.con;
            btn_excel.Click += btn_excel_Click;
        }
        
        void loadGender()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT GioiTinh FROM NhanVien";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_gioitinh.DataSource = dt;
                cbo_gioitinh.DisplayMember = "GioiTinh";
                cbo_gioitinh.ValueMember = "GioiTinh";
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



        void loadBoPhan()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string sql = "SELECT * FROM BoPhan WHERE MaPhong=@maphong";
                adap = new SqlDataAdapter(sql, connect);
                //adap.SelectCommand.Parameters.AddWithValue("@maphong", cbo_phongban.SelectedValue);
                adap.SelectCommand.Parameters.AddWithValue("@maphong", cbo_phongban.SelectedValue?.ToString());

                dt = new DataTable();
                adap.Fill(dt);
                cbo_bophan.DataSource = dt;
                cbo_bophan.DisplayMember = "TenBoPhan";
                cbo_bophan.ValueMember = "MaBoPhan";
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
        void loadPhongBan()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT * FROM PhongBan";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_phongban.DataSource = dt;
                cbo_phongban.DisplayMember = "TenPhong";
                cbo_phongban.ValueMember = "MaPhong";
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
        void loadChucVu()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT * FROM ChucVu";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_chucvu.DataSource = dt;
                cbo_chucvu.DisplayMember = "TenChucVu";
                cbo_chucvu.ValueMember = "MaChucVu";
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
        void loadTrinhDo()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT * FROM TrinhDoNangLuc";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_trinhdo.DataSource = dt;
                cbo_trinhdo.DisplayMember = "TenTrinhDo";
                cbo_trinhdo.ValueMember = "MaTrinhDo";
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
        private void loadform()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SET DATEFORMAT DMY SELECT * FROM NhanVien";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_ns.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_manv.Text = dgv_ns.Rows[0].Cells["MaNV"].Value.ToString();
                    txt_hoten.Text = dgv_ns.Rows[0].Cells["HoTen"].Value.ToString();
                    cbo_gioitinh.SelectedValue = dgv_ns.Rows[0].Cells["GioiTinh"].Value.ToString();
                    mask_ngsinh.Text = dgv_ns.Rows[0].Cells["NgaySinh"].Value.ToString();
                    txt_diachi.Text = dgv_ns.Rows[0].Cells["DiaChi"].Value.ToString();
                    txt_cancuoc.Text = dgv_ns.Rows[0].Cells["CCCD"].Value.ToString();
                    txt_hinhanh.Text = dgv_ns.Rows[0].Cells["Hinhanh"].Value.ToString();
                    cbo_chucvu.SelectedValue = dgv_ns.Rows[0].Cells["MaChucVu"].Value.ToString();
                    cbo_phongban.SelectedValue = dgv_ns.Rows[0].Cells["MAPHONG"].Value.ToString();
                    cbo_trinhdo.SelectedValue = dgv_ns.Rows[0].Cells["MATRINHDO"].Value.ToString();

                    // Gọi loadBoPhan() sau khi thiết lập SelectedValue của cbo_phongban
                    loadBoPhan();

                    // Sau đó thiết lập giá trị cho cbo_bophan
                    cbo_bophan.SelectedValue = dgv_ns.Rows[0].Cells["MABOPHAN"].Value?.ToString();
                    txt_trangthai.Text = dgv_ns.Rows[0].Cells["TRANGTHAI"].Value.ToString();
                }
                else
                {
                    txt_manv.Clear();
                    txt_hoten.Clear();
                    txt_cancuoc.Clear();
                    txt_diachi.Clear();
                    txt_trangthai.Clear();
                    cbo_gioitinh.SelectedIndex = -1;
                    cbo_bophan.SelectedIndex = -1;
                    cbo_phongban.SelectedIndex = -1;
                    cbo_chucvu.SelectedIndex = -1;
                    cbo_trinhdo.SelectedIndex = -1;
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

        private void QuanLyNhanSu_Load(object sender, EventArgs e)
        {
            txt_manv.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_cancuoc.Enabled = txt_trangthai.Enabled = txt_hinhanh.Enabled = false;
            cbo_bophan.Enabled = cbo_chucvu.Enabled = cbo_phongban.Enabled = cbo_gioitinh.Enabled = cbo_trinhdo.Enabled = false;
            mask_ngsinh.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            btn_file.Enabled = false;
            dgv_ns.ReadOnly = true;
            dgv_ns.AllowUserToAddRows = false;
            loadGender();
            //loadBoPhan();
            loadPhongBan();
            loadChucVu();
            loadTrinhDo();
            loadform();

            cbo_phongban.SelectedIndexChanged += cbo_phongban_SelectedIndexChanged;

        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_manv.Enabled = true;
            txt_hoten.Enabled = true;
            txt_diachi.Enabled = true;
            txt_cancuoc.Enabled = true;
            txt_hinhanh.Enabled = true;
            mask_ngsinh.Enabled = true;
            txt_trangthai.Enabled = true;
            cbo_gioitinh.Enabled = true;
            cbo_bophan.Enabled = true;
            cbo_chucvu.Enabled = true;
            cbo_phongban.Enabled = true;
            cbo_trinhdo.Enabled = true;
            btn_file.Enabled = true;
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            mask_ngsinh.Clear();
            txt_manv.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_cancuoc.Clear();
            txt_hinhanh.Clear();
            txt_trangthai.Clear();
            txt_manv.Focus();
            picture_1.Image = null;
            //    groupBox1.Enabled = true;

            //
            txt_manv.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_ns.ReadOnly = false;
            for (int i = 0; i < dgv_ns.Rows.Count - 1; i++)
            {
                dgv_ns.Rows[i].ReadOnly = true;
            }
            dgv_ns.FirstDisplayedScrollingRowIndex = dgv_ns.Rows.Count - 1;
            dgv_ns.AllowUserToAddRows = true;
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

        private void dgv_ns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_ns.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_manv.Text = dgv_ns.Rows[index].Cells["MANV"].Value.ToString();
                txt_hoten.Text = dgv_ns.Rows[index].Cells["HOTEN"].Value.ToString();
                cbo_gioitinh.SelectedValue = dgv_ns.Rows[index].Cells["GIOITINH"].Value.ToString();
                mask_ngsinh.Text = dgv_ns.Rows[index].Cells["NGAYSINH"].Value.ToString();
                //if (DateTime.TryParse(dgv_ns.Rows[index].Cells["NGAYSINH"].Value.ToString(), out DateTime ngaySinh))
                //{
                //    mask_ngsinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                //}
                //else
                //{
                //    mask_ngsinh.Text = string.Empty; // Hoặc hiển thị thông báo lỗi
                //}
                txt_diachi.Text = dgv_ns.Rows[index].Cells["DIACHI"].Value.ToString();
                txt_cancuoc.Text = dgv_ns.Rows[index].Cells["CCCD"].Value.ToString();
                txt_hinhanh.Text = dgv_ns.Rows[index].Cells["Hinhanh"].Value.ToString();
                cbo_chucvu.SelectedValue = dgv_ns.Rows[index].Cells["MACHUCVU"].Value.ToString();
                cbo_bophan.SelectedValue = dgv_ns.Rows[index].Cells["MABOPHAN"].Value.ToString();
                cbo_phongban.SelectedValue = dgv_ns.Rows[index].Cells["MAPHONG"].Value.ToString();
                txt_trangthai.Text = dgv_ns.Rows[index].Cells["TRANGTHAI"].Value.ToString();
                cbo_trinhdo.SelectedValue = dgv_ns.Rows[index].Cells["MATRINHDO"].Value.ToString();

                string imagePath = dgv_ns.Rows[index].Cells["Hinhanh"].Value.ToString();
                txt_hinhanh.Text = imagePath;

                // Kiểm tra nếu đường dẫn không rỗng và file tồn tại, thì hiển thị ảnh
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        // Giải phóng tài nguyên của PictureBox nếu đã có ảnh
                        if (picture_1.Image != null)
                        {
                            picture_1.Image.Dispose();
                        }

                        // Hiển thị ảnh trong PictureBox
                        picture_1.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Nếu đường dẫn không hợp lệ, thì xóa ảnh hiện tại trong PictureBox
                    picture_1.Image = null;
                }
            }
            txt_manv.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_cancuoc.Enabled = txt_trangthai.Enabled = txt_hinhanh.Enabled = false;
            cbo_bophan.Enabled = cbo_chucvu.Enabled = cbo_phongban.Enabled = cbo_gioitinh.Enabled = cbo_trinhdo.Enabled = false;
            mask_ngsinh.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            btn_file.Enabled = false;
            //groupBox1.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_hoten.Text) || cbo_gioitinh.SelectedValue == null
                    || string.IsNullOrEmpty(txt_diachi.Text) || string.IsNullOrEmpty(txt_cancuoc.Text) || string.IsNullOrEmpty(txt_trangthai.Text)
                    || string.IsNullOrEmpty(mask_ngsinh.Text) || string.IsNullOrEmpty(cbo_bophan.Text) || string.IsNullOrEmpty(cbo_phongban.Text)
                    || string.IsNullOrEmpty(cbo_chucvu.Text) || string.IsNullOrEmpty(cbo_trinhdo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem MANV đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM NhanVien WHERE MANV = @manv";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại. Vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi ngày sinh từ MaskedTextBox sang DateTime
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(mask_ngsinh.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, CCCD, Hinhanh, MaChucVu, MaBoPhan, MaPhong, TrangThai, MaTrinhDo) " +
                                   "VALUES (@manv, @hoten, @gioitinh, @ngaysinh, @diachi, @cancuoc, @hinhanh, @chucvu, @bophan, @phongban, @trangthai, @trinhdo)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@manv", txt_manv.Text);
                cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cbo_gioitinh.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaySinh); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@diachi", txt_diachi.Text);
                cmd.Parameters.AddWithValue("@cancuoc", txt_cancuoc.Text);
                cmd.Parameters.AddWithValue("@hinhanh", txt_hinhanh.Text);
                cmd.Parameters.AddWithValue("@chucvu", cbo_chucvu.SelectedValue);
                cmd.Parameters.AddWithValue("@bophan", cbo_bophan.SelectedValue);
                cmd.Parameters.AddWithValue("@phongban", cbo_phongban.SelectedValue);
                cmd.Parameters.AddWithValue("@trangthai", txt_trangthai.Text);
                cmd.Parameters.AddWithValue("@trinhdo", cbo_trinhdo.SelectedValue);

                string maNhanVien = txt_manv.Text;
              

                cmd.ExecuteNonQuery();

                loadform();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_manv.Clear();
                txt_hoten.Clear();
                txt_diachi.Clear();
                txt_cancuoc.Clear();
                txt_trangthai.Clear();
                txt_manv.Focus();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void txt_hoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập ký tự chữ cái, dấu cách và phím Backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập ký tự chữ trong họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_cancuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập số trong căn cước công dân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của tệp đã chọn
                    string filetext = opendialog.FileName;

                    // Giải phóng tài nguyên của PictureBox nếu đã có ảnh
                    if (picture_1.Image != null)
                    {
                        picture_1.Image.Dispose();
                    }

                    // Hiển thị đường dẫn trong textbox
                    txt_hinhanh.Text = filetext;

                    // Hiển thị ảnh trong PictureBox
                    picture_1.Image = Image.FromFile(filetext);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ảnh " + ex.Message);
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_hoten.Enabled = true;
            txt_hoten.Focus();
            txt_diachi.Enabled = true;
            txt_cancuoc.Enabled = true;
            txt_hinhanh.Enabled = true;
            mask_ngsinh.Enabled = true;
            txt_trangthai.Enabled = true;
            cbo_gioitinh.Enabled = true;
            cbo_bophan.Enabled = true;
            cbo_chucvu.Enabled = true;
            cbo_phongban.Enabled = true;
            cbo_trinhdo.Enabled = true;
            btn_file.Enabled = true;
            btn_them.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
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
                string manv = txt_manv.Text;
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(mask_ngsinh.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sqlUpdate = "UPDATE NhanVien SET Hoten=@hoten, GioiTinh=@gioitinh, NgaySinh=@ngaysinh, DiaChi=@diachi, CCCD=@cancuoc, Hinhanh=@hinhanh, MaChucVu=@chucvu, MaBoPhan=@bophan, MaPhong=@phongban, TrangThai=@trangthai, MaTrinhDo=@trinhdo Where MaNV=@manv";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@hoten", txt_hoten.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cbo_gioitinh.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaySinh); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@diachi", txt_diachi.Text);
                cmd.Parameters.AddWithValue("@cancuoc", txt_cancuoc.Text);
                cmd.Parameters.AddWithValue("@hinhanh", txt_hinhanh.Text);
                cmd.Parameters.AddWithValue("@chucvu", cbo_chucvu.SelectedValue);
                cmd.Parameters.AddWithValue("@bophan", cbo_bophan.SelectedValue);
                cmd.Parameters.AddWithValue("@phongban", cbo_phongban.SelectedValue);
                cmd.Parameters.AddWithValue("@trangthai", txt_trangthai.Text);
                cmd.Parameters.AddWithValue("@trinhdo", cbo_trinhdo.SelectedValue);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadform();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                mask_ngsinh.Clear();
                txt_manv.Clear();
                txt_hoten.Clear();
                txt_diachi.Clear();
                txt_cancuoc.Clear();
                txt_hinhanh.Clear();
                txt_trangthai.Clear();
                picture_1.Image = null;
                btn_luu.Enabled = false;
                txt_manv.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_cancuoc.Enabled = txt_trangthai.Enabled = txt_hinhanh.Enabled = false;
                cbo_bophan.Enabled = cbo_chucvu.Enabled = cbo_phongban.Enabled = cbo_gioitinh.Enabled = cbo_trinhdo.Enabled = false;
                mask_ngsinh.Enabled = false;
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_ns.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_ns.SelectedRows)
                        {
                            string manv = r.Cells["MaNV"].Value.ToString();
                            string sql = "DELETE FROM NhanVien WHERE MaNV=@manv";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@manv", manv);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mask_ngsinh.Clear();
                        txt_manv.Clear();
                        txt_hoten.Clear();
                        txt_diachi.Clear();
                        txt_cancuoc.Clear();
                        txt_hinhanh.Clear();
                        txt_trangthai.Clear();
                        picture_1.Image = null;
                        txt_manv.Enabled = txt_hoten.Enabled = txt_diachi.Enabled = txt_cancuoc.Enabled = txt_trangthai.Enabled = txt_hinhanh.Enabled = false;
                        cbo_bophan.Enabled = cbo_chucvu.Enabled = cbo_phongban.Enabled = cbo_gioitinh.Enabled = cbo_trinhdo.Enabled = false;
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

        private void cbo_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Chỉ gọi loadBoPhan khi cbo_phongban đã có giá trị SelectedValue hợp lệ
            //if (cbo_phongban.SelectedValue != null)
            //{
            //    loadBoPhan();
            //}
            loadBoPhan();
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
                        MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM Nhanvien WHERE MaNV = @manv";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@manv", txt_search.Text);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_ns.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

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
            loadform();
            txt_search.Clear();
        }

        private void ExportToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Thêm tiêu đề cột
            foreach (DataGridViewColumn column in dgv_ns.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_ns.Rows)
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
                ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cột
                for (int i = 0; i < dgv_ns.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_ns.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_ns.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_ns.Columns.Count; j++)
                    {
                        if (dgv_ns.Columns[j].Name == "NgaySinh") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_ns.Rows[i].Cells[j].Value != null && dgv_ns.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_ns.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_ns.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            else
                            {
                                workSheet.Cells[i + 2, j + 1].Value = string.Empty;
                            }
                        }
                        else
                        {
                            // Gán giá trị vào ô mà không cần định dạng
                            workSheet.Cells[i + 2, j + 1].Value = dgv_ns.Rows[i].Cells[j].Value;
                        }
                    }
                }

                // Lưu file Excel
                byte[] bin = excel.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
        }
        private bool daXuatBan = false;


        private void btn_excel_Click(object sender, EventArgs e)
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
