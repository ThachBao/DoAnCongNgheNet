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
    public partial class QuanLyBaoHiem : Form
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
        public string Manv { get; set; }
        public QuanLyBaoHiem()
        {
            InitializeComponent();
            connect = kn.con;
            btn_excel.Click += btn_excel_Click;
        }
        
        private void loadMaNhanVien()
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
                cb_nv.DataSource = dt;
                cb_nv.DisplayMember = "MaNV";
                cb_nv.ValueMember = "MaNV";
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

                string sql1 = "SET DATEFORMAT DMY SELECT * FROM BaoHiem";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_bh.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_mabh.Text = dgv_bh.Rows[0].Cells["MaBaoHiem"].Value.ToString();
                    cb_nv.SelectedValue = dgv_bh.Rows[0].Cells["MaNV"].Value.ToString();
                    txt_sobh.Text = dgv_bh.Rows[0].Cells["SoBaoHiem"].Value.ToString();
                    mask_ngcap.Text = dgv_bh.Rows[0].Cells["NgayCap"].Value.ToString();
                    txt_noicap.Text = dgv_bh.Rows[0].Cells["NoiCap"].Value.ToString();
                    txt_noikhambenh.Text = dgv_bh.Rows[0].Cells["NoiKhamBenh"].Value.ToString();
                }
                else
                {
                    txt_mabh.Clear();                    
                    txt_sobh.Clear();
                    mask_ngcap.Clear();
                    txt_noicap.Clear();
                    txt_noikhambenh.Clear();
                    cb_nv.SelectedIndex = -1;
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


        private void QuanLyBaoHiem_Load(object sender, EventArgs e)
        {
            cb_nv.Enabled = false;
            mask_ngcap.Enabled = false;
            txt_mabh.Enabled = txt_sobh.Enabled = txt_noicap.Enabled = txt_noikhambenh.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_bh.ReadOnly = true;
            dgv_bh.AllowUserToAddRows = false;
            loadform();
            loadMaNhanVien();
        }






        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_mabh.Enabled = true;
            cb_nv.Enabled = true;
            txt_sobh.Enabled = true;
            mask_ngcap.Enabled = true;
            txt_noicap.Enabled = true;
            txt_noikhambenh.Enabled = true;

            btn_them.Enabled = true;
            btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            txt_mabh.Clear();
            txt_sobh.Clear();
            mask_ngcap.Clear();
            txt_noicap.Clear();
            txt_noikhambenh.Clear();
            txt_mabh.Focus();
            txt_sobh.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_bh.ReadOnly = false;
            for (int i = 0; i < dgv_bh.Rows.Count - 1; i++)
            {
                dgv_bh.Rows[i].ReadOnly = true;
            }
            dgv_bh.FirstDisplayedScrollingRowIndex = dgv_bh.Rows.Count - 1;
            dgv_bh.AllowUserToAddRows = true;
        }


        

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_mabh.Text) || string.IsNullOrEmpty(txt_sobh.Text) || cb_nv.Text == null
                    || string.IsNullOrEmpty(mask_ngcap.Text) || string.IsNullOrEmpty(txt_noicap.Text) || string.IsNullOrEmpty(txt_noikhambenh.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem Số hợp đồng đã tồn tại hay chưa

                string checkSql1 = "SELECT COUNT(*) FROM BaoHiem WHERE MaBaoHiem = @mabaohiem";
                cmd = new SqlCommand(checkSql1, connect);
                cmd.Parameters.AddWithValue("@mabaohiem", txt_mabh.Text);
                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã bảo hiểm này đã tồn tại. Vui lòng chọn mã bảo hiểm khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connect.Close();

                string checkSql2 = "SELECT COUNT(*) FROM BaoHiem WHERE SoBaoHiem=@sobaohiem";
                cmd = new SqlCommand(checkSql2, connect);
                cmd.Parameters.AddWithValue("@sobaohiem", txt_sobh.Text);
                connect.Open();
                int count3 = (int)cmd.ExecuteScalar();

                if (count3 > 0)
                {
                    MessageBox.Show("Số bảo hiểm này đã tồn tại. Vui lòng chọn số bảo hiểm khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
 
                // Chuyển đổi ngày từ MaskedTextBox sang DateTime
                DateTime ngaycap;
                if (!DateTime.TryParseExact(mask_ngcap.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaycap))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO BaoHiem (MaBaoHiem, SoBaoHiem, NgayCap, NoiCap, NoiKhamBenh, MaNV) VALUES (@mabaohiem, @sobaohiem, @ngaycap, @noicap, @noikhambenh, @manv)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@mabaohiem", txt_mabh.Text);
                cmd.Parameters.AddWithValue("@sobaohiem", txt_sobh.Text);
                cmd.Parameters.AddWithValue("@ngaycap", ngaycap);
                cmd.Parameters.AddWithValue("@noicap", txt_noicap.Text);
                cmd.Parameters.AddWithValue("@noikhambenh", txt_noikhambenh.Text);
                cmd.Parameters.AddWithValue("@manv", cb_nv.SelectedValue);


                cmd.ExecuteNonQuery();

                loadform();
                loadMaNhanVien();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_mabh.Clear();
                txt_sobh.Clear();
                mask_ngcap.Clear();
                txt_noicap.Clear();
                txt_noikhambenh.Clear();
                txt_mabh.Focus();
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



        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_bh.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bảo hiểm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_bh.SelectedRows)
                        {
                            string mabaohiem = r.Cells["MaBaoHiem"].Value.ToString();
                            string sql = "DELETE FROM BaoHiem WHERE MaBaoHiem=@mabaohiem";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@mabaohiem", mabaohiem);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        loadMaNhanVien();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Đã hủy bảo hiểm của nhân viên mang mã: " + cb_nv.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mabh.Clear();
                        txt_sobh.Clear();
                        mask_ngcap.Clear();
                        txt_noicap.Clear();
                        txt_noikhambenh.Clear();
                        cb_nv.Enabled = false;
                        txt_mabh.Enabled = txt_sobh.Enabled = cb_nv.Enabled = mask_ngcap.Enabled = txt_noicap.Enabled = txt_noikhambenh.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi hủy bảo hiểm: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên bạn muốn hủy bảo hiểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_noicap.Enabled = true;
            txt_noicap.Focus();
            txt_noikhambenh.Enabled = true;
            mask_ngcap.Enabled = true;

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
                string mabaohiem = txt_mabh.Text;
                DateTime ngaycap;
                if (!DateTime.TryParseExact(mask_ngcap.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaycap))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sqlUpdate = "UPDATE BaoHiem SET MaBaoHiem=@mabaohiem, SoBaoHiem=@sobaohiem, NgayCap=@ngaycap,NoiCap=@noiCap,NoiKhamBenh=@noikhambenh, MaNV=@manv Where MaBaoHiem=@mabaohiem";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@mabaohiem", mabaohiem);
                cmd.Parameters.AddWithValue("@sobaohiem", txt_sobh.Text);
                cmd.Parameters.AddWithValue("@ngaycap", ngaycap);
                cmd.Parameters.AddWithValue("@noiCap", txt_noicap.Text);
                cmd.Parameters.AddWithValue("@noikhambenh", txt_noikhambenh.Text);
                cmd.Parameters.AddWithValue("@manv", cb_nv.SelectedValue);

                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadform();
                loadMaNhanVien();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
              
                mask_ngcap.Clear();
                txt_noicap.Clear();
                txt_noikhambenh.Clear();
                btn_luu.Enabled = false;
                cb_nv.Enabled = false;
                txt_mabh.Enabled = txt_sobh.Enabled = mask_ngcap.Enabled = txt_noicap.Enabled = txt_noikhambenh.Enabled = cb_nv.Enabled = false;
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

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txt_mabh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập số trong mã bảo hiểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_sobh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập số trong số bảo hiểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_bh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_bh.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_mabh.Text = dgv_bh.Rows[index].Cells["MaBaoHiem"].Value.ToString();
                cb_nv.SelectedValue = dgv_bh.Rows[index].Cells["MaNV"].Value.ToString();
                txt_sobh.Text = dgv_bh.Rows[index].Cells["SoBaoHiem"].Value.ToString();
                mask_ngcap.Text = dgv_bh.Rows[index].Cells["NgayCap"].Value.ToString();
                txt_noicap.Text = dgv_bh.Rows[index].Cells["NoiCap"].Value.ToString();
                txt_noikhambenh.Text = dgv_bh.Rows[index].Cells["NoiKhamBenh"].Value.ToString();

            }
            cb_nv.Enabled = false;
            mask_ngcap.Enabled = false;
            txt_mabh.Enabled = txt_sobh.Enabled = txt_noicap.Enabled = txt_noikhambenh.Enabled = false;

            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }
        private void ExportToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Thêm tiêu đề cột
            foreach (DataGridViewColumn column in dgv_bh.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_bh.Rows)
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
                for (int i = 0; i < dgv_bh.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_bh.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_bh.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_bh.Columns.Count; j++)
                    {
                        if (dgv_bh.Columns[j].Name == "NgayCap") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_bh.Rows[i].Cells[j].Value != null && dgv_bh.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_bh.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_bh.Rows[i].Cells[j].Value.ToString();
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
                            workSheet.Cells[i + 2, j + 1].Value = dgv_bh.Rows[i].Cells[j].Value;
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
