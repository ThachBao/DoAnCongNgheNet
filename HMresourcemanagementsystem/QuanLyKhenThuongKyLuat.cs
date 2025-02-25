using ClosedXML.Excel;
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
    public partial class QuanLyKhenThuongKyLuat : Form
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
        public QuanLyKhenThuongKyLuat()
        {
            InitializeComponent();
            connect = kn.con;
            Btn_excel.Click += Btn_excel_Click_1;
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

        void loadformKTKL()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM KhenThuongKyLuat";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_dt.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_maktkl.Text = dgv_dt.Rows[0].Cells["MaKTKL"].Value.ToString();
                    txt_tenktkl.Text = dgv_dt.Rows[0].Cells["TenKTKL"].Value.ToString();
                    mask_ngay.Text = dgv_dt.Rows[0].Cells["Ngay"].Value.ToString();
                    cbo_manv.SelectedValue = dgv_dt.Rows[0].Cells["MaNV"].Value.ToString();
                    txt_noidung.Text = dgv_dt.Rows[0].Cells["NoiDung"].Value.ToString();
                    txt_loai.Text = dgv_dt.Rows[0].Cells["Loai"].Value.ToString();
                }
                else
                {
                    txt_maktkl.Clear();
                    txt_tenktkl.Clear();
                    txt_noidung.Clear();
                    txt_loai.Clear();
                    cbo_manv.SelectedIndex = -1;
                    mask_ngay.Clear();
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
        void antimkiem()
        {
            txt_timMNV.Enabled = false;
            picker1.Enabled = false;
        }
        private void QuanLyKhenThuongKyLuat_Load(object sender, EventArgs e)
        {
            anthongtin();
            antimkiem();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_dt.ReadOnly = true;
            dgv_dt.AllowUserToAddRows = false;
            loadmanv();
            loadformKTKL();
        }

        private void dgv_dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_dt.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_maktkl.Text = dgv_dt.Rows[index].Cells["MaKTKL"].Value.ToString();
                txt_tenktkl.Text = dgv_dt.Rows[index].Cells["TenKTKL"].Value.ToString();
                cbo_manv.SelectedValue = dgv_dt.Rows[index].Cells["MaNV"].Value.ToString();
                mask_ngay.Text = dgv_dt.Rows[index].Cells["Ngay"].Value.ToString();
                txt_noidung.Text = dgv_dt.Rows[index].Cells["NoiDung"].Value.ToString();
                txt_loai.Text = dgv_dt.Rows[index].Cells["Loai"].Value.ToString();
            }
            anthongtin();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }
        void anthongtin()
        {
            txt_maktkl.Enabled = txt_tenktkl.Enabled = txt_noidung.Enabled = txt_loai.Enabled = false;
            cbo_manv.Enabled = false;
            mask_ngay.Enabled = false;
        }
        void hienthongtin()
        {
            txt_maktkl.Enabled = txt_tenktkl.Enabled = txt_noidung.Enabled = txt_loai.Enabled = true;
            cbo_manv.Enabled = true;
            mask_ngay.Enabled = true;
        }
        void xoathongtin()
        {
            mask_ngay.Clear();
            txt_maktkl.Clear();
            txt_tenktkl.Clear();
            txt_noidung.Clear();
            txt_loai.Clear();
            cbo_manv.SelectedValue = -1;
        }
        private void btn_moi_Click(object sender, EventArgs e)
        {
            hienthongtin();
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            xoathongtin();
            //Focus
            txt_maktkl.Focus();
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
                if (string.IsNullOrEmpty(txt_maktkl.Text) || string.IsNullOrEmpty(txt_tenktkl.Text) || cbo_manv.SelectedValue == null
                    || string.IsNullOrEmpty(txt_noidung.Text) || string.IsNullOrEmpty(mask_ngay.Text)
                    || string.IsNullOrEmpty(txt_loai.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem Mã KTKL đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM KhenThuongKyLuat WHERE MaKTKL = @maktkl";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@maktkl", txt_maktkl.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã đào tạo này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi ngày sinh từ MaskedTextBox sang DateTime
                DateTime ngay;
                if (!DateTime.TryParseExact(mask_ngay.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngay))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO KhenThuongKyLuat (MaKTKL, TenKTKL, NoiDung, Ngay, MaNV, Loai) " +
                                   "VALUES (@maktkl, @tenktkl, @noidung, @ngay, @manv, @loai)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@maktkl", txt_maktkl.Text);
                cmd.Parameters.AddWithValue("@tenktkl", txt_tenktkl.Text);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@noidung", txt_noidung.Text);
                cmd.Parameters.AddWithValue("@loai", txt_loai.Text);
                cmd.ExecuteNonQuery();

                loadformKTKL();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
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
                            string maktkl = r.Cells["MaKTKL"].Value.ToString();
                            string sql = "DELETE FROM KhenThuongKyLuat WHERE MaKTKL=@maktkl";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@maktkl", maktkl);
                            cmd.ExecuteNonQuery();
                        }
                        loadformKTKL();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Bạn Đã Xóa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txt_maktkl.Enabled = false;
            cbo_manv.Enabled = false;
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

                // Lấy mã ktkl từ ô hiện tại trong DataGridView
                string maktkl = txt_maktkl.Text;
                DateTime ngay;
                if (!DateTime.TryParseExact(mask_ngay.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngay))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sqlUpdate = "UPDATE KhenThuongKyLuat SET TenKTKL=@tenktkl, Ngay=@ngay, Loai=@loai, NoiDung=@noidung Where MaKTKL=@maktkl";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@maktkl", maktkl);
                cmd.Parameters.AddWithValue("@tenktkl", txt_tenktkl.Text);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@noidung", txt_noidung.Text);
                cmd.Parameters.AddWithValue("@loai", txt_loai.Text);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadformKTKL();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
                btn_luu.Enabled = false;
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

        private void rdbt_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbt_1.Checked)
            {
                txt_timMNV.Enabled = true;
                picker1.Enabled = false;
            }
        }

        private void rdbt_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbt_2.Checked)
            {
                txt_timMNV.Enabled = false;
                picker1.Enabled = true;
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sqlQuery = "";
                if (rdbt_1.Checked) // Tìm kiếm theo mã nhân viên
                {
                    if (string.IsNullOrEmpty(txt_timMNV.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM KhenThuongKyLuat WHERE MaNV = @manv";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@manv", txt_timMNV.Text);
                }
                else if (rdbt_2.Checked) // Tìm kiếm theo tháng và năm
                {
                    DateTime selectedDate;
                    if (!DateTime.TryParse(picker1.Text, out selectedDate))
                    {
                        MessageBox.Show("Vui lòng chọn tháng và năm hợp lệ để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int month = selectedDate.Month;
                    int year = selectedDate.Year;

                    sqlQuery = "SELECT * FROM KhenThuongKyLuat WHERE MONTH(Ngay) = @month AND YEAR(Ngay) = @year";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_dt.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

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

        private void btn_xoasearch_Click(object sender, EventArgs e)
        {
            loadformKTKL();
            rdbt_1.Checked = false;
            rdbt_2.Checked = false;
            txt_timMNV.Clear();

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
                        if (dgv_dt.Columns[j].Name == "Ngay") // Kiểm tra nếu cột hiện tại là cột NgaySinh
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
        private void Btn_excel_Click_1(object sender, EventArgs e)
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
