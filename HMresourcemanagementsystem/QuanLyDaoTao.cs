using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMresourcemanagementsystem
{
    public partial class QuanLyDaoTao : Form
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
        public QuanLyDaoTao()
        {
            InitializeComponent();
            connect = kn.con;
            btn_excel.Click += btn_excel_Click;
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

        void loadmanv()
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

        void loadformDT()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM DaoTao";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_dt.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_madt.Text = dgv_dt.Rows[0].Cells["MaDaoTao"].Value.ToString();
                    txt_tenkh.Text = dgv_dt.Rows[0].Cells["TenKhoaHoc"].Value.ToString();
                    cbo_manv.SelectedValue = dgv_dt.Rows[0].Cells["MaNV"].Value.ToString();
                    mask_ngbd.Text = dgv_dt.Rows[0].Cells["ThoiGianBatDau"].Value.ToString();
                    mask_ngkt.Text = dgv_dt.Rows[0].Cells["ThoiGianKetThuc"].Value.ToString();
                    txt_noidung.Text = dgv_dt.Rows[0].Cells["NoiDung"].Value.ToString();
                }
                else
                {
                    txt_madt.Clear();
                    txt_tenkh.Clear();
                    txt_noidung.Clear();
                    cbo_manv.SelectedIndex = -1;
                    mask_ngbd.Clear();
                    mask_ngkt.Clear();
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

        private void QuanLyDaoTao_Load(object sender, EventArgs e)
        {
            txt_madt.Enabled = txt_tenkh.Enabled = txt_noidung.Enabled = false;
            cbo_manv.Enabled = false;
            mask_ngbd.Enabled = mask_ngkt.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_dt.ReadOnly = true;
            dgv_dt.AllowUserToAddRows = false;
            loadmanv();
            loadformDT();
        }

        private void dgv_dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_dt.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_madt.Text = dgv_dt.Rows[index].Cells["MaDaoTao"].Value.ToString();
                txt_tenkh.Text = dgv_dt.Rows[index].Cells["TenKhoaHoc"].Value.ToString();
                cbo_manv.SelectedValue = dgv_dt.Rows[index].Cells["MaNV"].Value.ToString();
                mask_ngbd.Text = dgv_dt.Rows[index].Cells["ThoiGianBatDau"].Value.ToString();
                mask_ngkt.Text = dgv_dt.Rows[index].Cells["ThoiGianKetThuc"].Value.ToString();
                txt_noidung.Text = dgv_dt.Rows[index].Cells["NoiDung"].Value.ToString();
            }
            txt_madt.Enabled = txt_tenkh.Enabled = txt_noidung.Enabled = false;
            cbo_manv.Enabled = false;
            mask_ngbd.Enabled = mask_ngkt.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_madt.Enabled = true;
            txt_tenkh.Enabled = true;
            txt_noidung.Enabled = true;
            mask_ngbd.Enabled = true;
            mask_ngkt.Enabled = true;
            cbo_manv.Enabled = true;
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            mask_ngbd.Clear();
            mask_ngkt.Clear();
            txt_madt.Clear();
            txt_tenkh.Clear();
            txt_noidung.Clear();
            cbo_manv.SelectedValue = -1;
            txt_madt.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_dt.ReadOnly = false;
            for (int i = 0; i < dgv_dt.Rows.Count - 1; i++)
            {
                dgv_dt.Rows[i].ReadOnly = true;
            }
            dgv_dt.FirstDisplayedScrollingRowIndex = dgv_dt.Rows.Count - 1;
            dgv_dt.AllowUserToAddRows = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_madt.Text) || string.IsNullOrEmpty(txt_tenkh.Text) || cbo_manv.SelectedValue == null
                    || string.IsNullOrEmpty(txt_noidung.Text) || string.IsNullOrEmpty(mask_ngbd.Text)
                    || string.IsNullOrEmpty(mask_ngkt.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem MANV đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM DaoTao WHERE MaDaoTao = @madt";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@madt", txt_madt.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã đào tạo này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi ngày sinh từ MaskedTextBox sang DateTime
                DateTime ngaybd;
                if (!DateTime.TryParseExact(mask_ngbd.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaybd))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime ngaykt;
                if (!DateTime.TryParseExact(mask_ngkt.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaykt))
                {
                    MessageBox.Show("Ngày kết thúc không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra ngày bắt đầu phải < ngày kết thúc
                if (ngaybd >= ngaykt)
                {
                    MessageBox.Show("Ngày bắt đầu phải xảy ra trước ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO DaoTao (MaDaoTao, TenKhoaHoc, ThoiGianBatDau, ThoiGianKetThuc, NoiDung, MaNV) " +
                                   "VALUES (@madt, @tenkh, @ngaybd, @ngaykt, @noidung, @manv)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@madt", txt_madt.Text);
                cmd.Parameters.AddWithValue("@tenkh", txt_tenkh.Text);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaybd", ngaybd);
                cmd.Parameters.AddWithValue("@ngaykt", ngaykt);
                cmd.Parameters.AddWithValue("@noidung", txt_noidung.Text);
                cmd.ExecuteNonQuery();

                loadformDT();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_madt.Clear();
                txt_tenkh.Clear();
                txt_noidung.Clear();
                cbo_manv.SelectedValue = -1;
                mask_ngbd.Clear();
                mask_ngkt.Clear();
                txt_madt.Focus();
                MessageBox.Show("Bạn Đã Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_dt.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_dt.SelectedRows)
                        {
                            string madt = r.Cells["MaDaoTao"].Value.ToString();
                            string sql = "DELETE FROM DaoTao WHERE MaDaoTao=@madt";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@madt", madt);
                            cmd.ExecuteNonQuery();
                        }
                        loadformDT();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Bạn Đã Xóa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mask_ngbd.Clear();
                        mask_ngkt.Clear();
                        txt_madt.Clear();
                        txt_tenkh.Clear();
                        txt_noidung.Clear();
                        cbo_manv.SelectedValue = -1;
                        txt_madt.Enabled = txt_tenkh.Enabled = txt_noidung.Enabled = false;
                        cbo_manv.Enabled = false;
                        mask_ngbd.Enabled = mask_ngkt.Enabled = false ;
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

        private void txt_tenkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập ký tự chữ cái, dấu cách và phím Backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập ký tự chữ trong tên khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_noidung.Enabled = true;
            txt_tenkh.Enabled = true;
            txt_tenkh.Focus();
            mask_ngbd.Enabled = true;
            mask_ngkt.Enabled = true;
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
                string madt = txt_madt.Text;
                DateTime ngaybd;
                if (!DateTime.TryParseExact(mask_ngbd.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaybd))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime ngaykt;
                if (!DateTime.TryParseExact(mask_ngkt.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaykt))
                {
                    MessageBox.Show("Ngày kết thúc không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaybd >= ngaykt)
                {
                    MessageBox.Show("Ngày bắt đầu phải xảy ra trước ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sqlUpdate = "UPDATE DaoTao SET TenKhoaHoc=@tenkh, ThoiGianBatDau=@ngaybd, ThoiGianKetThuc=@ngaykt, NoiDung=@nd Where MaDaoTao=@madt";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@madt", madt);
                cmd.Parameters.AddWithValue("@tenkh", txt_tenkh.Text);
                cmd.Parameters.AddWithValue("@ngaybd", ngaybd); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@ngaykt", ngaykt); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@nd", txt_noidung.Text);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadformDT();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                mask_ngbd.Clear();
                mask_ngkt.Clear();
                txt_madt.Clear();
                txt_tenkh.Clear();
                txt_noidung.Clear();
                cbo_manv.SelectedValue = -1;
                btn_luu.Enabled = false;
                txt_madt.Enabled = txt_tenkh.Enabled = txt_noidung.Enabled = false;
                cbo_manv.Enabled = mask_ngkt.Enabled = false;
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

        private void ExportToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Thêm tiêu đề cột
            foreach (DataGridViewColumn column in dgv_dt.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_dt.Rows)
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
                for (int i = 0; i < dgv_dt.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_dt.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_dt.Columns.Count; j++)
                    {
                        if (dgv_dt.Columns[j].Name == "ThoiGianBatDau"|| dgv_dt.Columns[j].Name == "ThoiGianKetThuc") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_dt.Rows[i].Cells[j].Value != null && dgv_dt.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_dt.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_dt.Rows[i].Cells[j].Value.ToString();
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
                            workSheet.Cells[i + 2, j + 1].Value = dgv_dt.Rows[i].Cells[j].Value;
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
