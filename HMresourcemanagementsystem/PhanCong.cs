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
    public partial class PhanCong : Form
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
        public PhanCong()
        {
            InitializeComponent();
            connect = kn.con;
            btn_excel.Click += btn_excel_Click;
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
        void loadDA()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT * FROM DuAn";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_maduan.DataSource = dt;
                cbo_maduan.DisplayMember = "MaDuAn";
                cbo_maduan.ValueMember = "MaDuAn";
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
        void xoathongtin()
        {
            txt_mapc.Clear();
            cbo_manv.SelectedValue = -1;
            cbo_maduan.SelectedValue = -1;
            mask_ngbd.Clear();
            mask_ngkt.Clear();
            txt_vaitro.Clear();
        }
        void anthongtin()
        {
            txt_mapc.Enabled = cbo_manv.Enabled =  cbo_maduan.Enabled =  mask_ngbd.Enabled =  mask_ngkt.Enabled = txt_vaitro.Enabled = false;
        }
        void hienthongtin()
        {
            txt_mapc.Enabled = cbo_manv.Enabled = cbo_maduan.Enabled = mask_ngbd.Enabled = mask_ngkt.Enabled = txt_vaitro.Enabled = true;
        }

        void loadformPC()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM PhanCong";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_PC.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_mapc.Text = dgv_PC.Rows[0].Cells["MaPhanCong"].Value.ToString();
                    cbo_manv.SelectedValue = dgv_PC.Rows[0].Cells["MaNV"].Value.ToString();
                    cbo_maduan.SelectedValue = dgv_PC.Rows[0].Cells["MaDuAn"].Value.ToString();
                    mask_ngbd.Text = dgv_PC.Rows[0].Cells["NgayThamGia"].Value.ToString();
                    mask_ngkt.Text = dgv_PC.Rows[0].Cells["NgayKetThuc"].Value.ToString();
                    txt_vaitro.Text = dgv_PC.Rows[0].Cells["VaiTro"].Value.ToString();
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

        private void PhanCong_Load(object sender, EventArgs e)
        {
            anthongtin();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_PC.ReadOnly = true;
            dgv_PC.AllowUserToAddRows = false;
            loadDA();
            loadmanv();
            loadformPC();
        }

        private void dgv_PC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_PC.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_mapc.Text = dgv_PC.Rows[index].Cells["MaPhanCong"].Value.ToString();
                cbo_manv.SelectedValue = dgv_PC.Rows[index].Cells["MaNV"].Value.ToString();
                cbo_maduan.SelectedValue = dgv_PC.Rows[index].Cells["MaDuAn"].Value.ToString();
                mask_ngbd.Text = dgv_PC.Rows[index].Cells["NgayThamGia"].Value.ToString();
                mask_ngkt.Text = dgv_PC.Rows[index].Cells["NgayKetThuc"].Value.ToString();
                txt_vaitro.Text = dgv_PC.Rows[index].Cells["VaiTro"].Value.ToString();
            }
            anthongtin();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            hienthongtin();
            xoathongtin();
            btn_them.Enabled = true ;
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false ;
            txt_mapc.Focus();
            dgv_PC.ReadOnly = false;
            for (int i = 0; i < dgv_PC.Rows.Count - 1; i++)
            {
                dgv_PC.Rows[i].ReadOnly = true;
            }
            dgv_PC.FirstDisplayedScrollingRowIndex = dgv_PC.Rows.Count - 1;
            dgv_PC.AllowUserToAddRows = true;
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_mapc.Text) || cbo_maduan.SelectedValue == null || cbo_manv.SelectedValue == null
                    || string.IsNullOrEmpty(txt_vaitro.Text) || string.IsNullOrEmpty(mask_ngbd.Text)
                    || string.IsNullOrEmpty(mask_ngkt.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // kiểm tra mã phân công tồn tại chưa
                string checkSql = "SELECT COUNT(*) FROM PhanCong WHERE MaPhanCong = @mapc";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@mapc", txt_mapc.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã phân công này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Ngày bắt đầu phải diễn ra trước ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO PhanCong (MaPhanCong, NgayThamGia, NgayKetThuc, MaNV, MaDuAn, VaiTro)" +
                                   "VALUES (@mapc, @ngaybd, @ngaykt, @manv, @mada, @vaitro)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@mapc", txt_mapc.Text);
                cmd.Parameters.AddWithValue("@ngaybd", ngaybd);
                cmd.Parameters.AddWithValue("@ngaykt", ngaykt);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
                cmd.Parameters.AddWithValue("@mada", cbo_maduan.SelectedValue);
                cmd.Parameters.AddWithValue("@vaitro", txt_vaitro.Text);
                cmd.ExecuteNonQuery();

                loadformPC();
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
            if (dgv_PC.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_PC.SelectedRows)
                        {
                            string mapc = r.Cells["MaPhanCong"].Value.ToString();
                            string sql = "DELETE FROM PhanCong WHERE MaPhanCong=@mapc";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@mapc", mapc);
                            cmd.ExecuteNonQuery();
                        }
                        loadformPC();
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
            txt_mapc.Enabled = btn_xoa.Enabled = cbo_maduan.Enabled = false ;
            btn_luu.Enabled = true ;
            
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
                if (txt_search.Text != null) 
                {
                    if (string.IsNullOrEmpty(txt_search.Text))
                    {
                        MessageBox.Show("Vui lòng mã dự án để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM PhanCong WHERE MaDuAn = @mada";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@mada", txt_search.Text);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_PC.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

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
            loadformPC();
            txt_search.Clear();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string mapc = txt_mapc.Text;
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

                string sqlUpdate = "UPDATE PhanCong SET NgayThamGia=@ngaybd, NgayKetThuc=@ngaykt, MaNV=@manv, VaiTro=@vaitro Where MaPhanCong=@mapc";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@mapc", mapc);
                cmd.Parameters.AddWithValue("@vaitro", txt_vaitro.Text);
                cmd.Parameters.AddWithValue("@ngaybd", ngaybd); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@ngaykt", ngaykt); // Thêm ngày sinh đã được chuyển đổi
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadformPC();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
                anthongtin();
                btn_luu.Enabled = false;
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
            foreach (DataGridViewColumn column in dgv_PC.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_PC.Rows)
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
                for (int i = 0; i < dgv_PC.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_PC.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_PC.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_PC.Columns.Count; j++)
                    {
                        if (dgv_PC.Columns[j].Name == "NgayThamGia"|| dgv_PC.Columns[j].Name == "NgayKetThuc") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_PC.Rows[i].Cells[j].Value != null && dgv_PC.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_PC.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_PC.Rows[i].Cells[j].Value.ToString();
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
                            workSheet.Cells[i + 2, j + 1].Value = dgv_PC.Rows[i].Cells[j].Value;
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
