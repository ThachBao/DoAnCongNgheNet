using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class QuanLyHopDong : Form
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
        public QuanLyHopDong()
        {
            InitializeComponent();
            connect = kn.con;
            btn_xuatban.Click += btn_xuatban_Click;
        }


        private void loadMaNhanVien()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                
                string sql = "SELECT MaNV FROM NhanVien";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cb_nv.DataSource = dt;
                //cb_nv.DisplayMember = "MaNV";
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

                string sql1 = "SELECT * FROM HopDong";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_hd.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_sohd.Text = dgv_hd.Rows[0].Cells["SoHopDong"].Value.ToString();
                    cb_nv.SelectedValue = dgv_hd.Rows[0].Cells["MaNV"].Value.ToString();
                    mask_ngbatdau.Text = dgv_hd.Rows[0].Cells["NgayBatDau"].Value.ToString();
                    mask_ngketthuc.Text = dgv_hd.Rows[0].Cells["NgayKetThuc"].Value.ToString();
                    txt_noidung.Text = dgv_hd.Rows[0].Cells["NoiDung"].Value.ToString();
                    txt_thoihan.Text = dgv_hd.Rows[0].Cells["ThoiHan"].Value.ToString();
                    txt_hesoluong.Text = dgv_hd.Rows[0].Cells["HeSoLuong"].Value.ToString();
                }
                else
                {
                    txt_sohd.Clear();
                    cb_nv.SelectedIndex = -1;
                    mask_ngbatdau.Clear();
                    mask_ngketthuc.Clear();
                    txt_noidung.Clear();
                    txt_thoihan.Clear();
                    txt_hesoluong.Clear();
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

        private void dgv_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_hd.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_sohd.Text = dgv_hd.Rows[index].Cells["SoHopDong"].Value.ToString();
                cb_nv.SelectedValue = dgv_hd.Rows[index].Cells["MANV"].Value.ToString();
                mask_ngbatdau.Text = dgv_hd.Rows[index].Cells["NgayBatDau"].Value.ToString();
                mask_ngketthuc.Text = dgv_hd.Rows[index].Cells["NgayKetThuc"].Value.ToString();
                txt_noidung.Text = dgv_hd.Rows[index].Cells["NoiDung"].Value.ToString();
                txt_thoihan.Text = dgv_hd.Rows[index].Cells["ThoiHan"].Value.ToString();
                txt_hesoluong.Text = dgv_hd.Rows[index].Cells["HeSoLuong"].Value.ToString();

            }
            txt_sohd.Enabled = txt_noidung.Enabled = txt_thoihan.Enabled = txt_hesoluong.Enabled = false;
            cb_nv.Enabled = false;
            mask_ngbatdau.Enabled = mask_ngketthuc.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_luu.Enabled = btn_them.Enabled = false;
        }
        private void QuanLyHopDong_Load(object sender, EventArgs e)
        {
            cb_nv.Enabled = txt_sohd.Enabled  = txt_noidung.Enabled = txt_thoihan.Enabled=txt_hesoluong.Enabled = mask_ngbatdau.Enabled = mask_ngketthuc.Enabled = false;
            cb_nv.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;        
            dgv_hd.ReadOnly = true;
            dgv_hd.AllowUserToAddRows = false;
            loadform();
            loadMaNhanVien();

        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_sohd.Enabled = true;
            cb_nv.Enabled = true;
            mask_ngbatdau.Enabled = true;
            mask_ngketthuc.Enabled = true;
            txt_noidung.Enabled = true;
            txt_thoihan.Enabled = true;
            txt_hesoluong.Enabled = true;


            btn_them.Enabled = true;
            btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            txt_sohd.Clear();
            mask_ngbatdau.Clear();
            mask_ngketthuc.Clear();
            txt_noidung.Clear();
            txt_thoihan.Clear();
            txt_hesoluong.Clear();
            txt_sohd.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_hd.ReadOnly = false;
            for (int i = 0; i < dgv_hd.Rows.Count - 1; i++)
            {
                dgv_hd.Rows[i].ReadOnly = true;
            }
        //    dgv_hd.FirstDisplayedScrollingRowIndex = dgv_hd.Rows.Count - 1;
            dgv_hd.AllowUserToAddRows = true;
        }



        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_sohd.Text) || string.IsNullOrEmpty(cb_nv.Text) || mask_ngbatdau.Text == null
                    || string.IsNullOrEmpty(mask_ngketthuc.Text) || string.IsNullOrEmpty(txt_noidung.Text) || string.IsNullOrEmpty(txt_thoihan.Text)
                    || string.IsNullOrEmpty(txt_hesoluong.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Kiểm tra xem Số hợp đồng đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM HopDong WHERE SoHopDong = @sohopdong";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@sohopdong", txt_sohd.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Số hợp đồng này đã tồn tại. Vui lòng chọn số hợp đồng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                // Chuyển đổi ngày từ MaskedTextBox sang DateTime
                DateTime ngaybatdau;
                if (!DateTime.TryParseExact(mask_ngbatdau.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaybatdau))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime ngayketthuc;
                if (!DateTime.TryParseExact(mask_ngketthuc.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayketthuc))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaybatdau > ngayketthuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc","Thông báo");
                }
                else
                {
                    // Thực hiện câu lệnh insert
                    string sqlInsert = "INSERT INTO HopDong (SoHopDong, NgayBatDau, NgayKetThuc, NoiDung, ThoiHan, HeSoLuong, MaNV) VALUES (@sohopdong, @ngaybatdau, @ngayketthuc, @noidung, @thoihan, @hesoluong, @manv)";
                    cmd = new SqlCommand(sqlInsert, connect);
                    cmd.Parameters.AddWithValue("@sohopdong", txt_sohd.Text);
                    cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                    cmd.Parameters.AddWithValue("@ngayketthuc", ngayketthuc);
                    cmd.Parameters.AddWithValue("@noidung", txt_noidung.Text);
                    cmd.Parameters.AddWithValue("@thoihan", txt_thoihan.Text);
                    cmd.Parameters.AddWithValue("@hesoluong", txt_hesoluong.Text);
                    cmd.Parameters.AddWithValue("@manv", cb_nv.SelectedValue);


                    cmd.ExecuteNonQuery();

                    loadform();
                    loadMaNhanVien();
                    bindingSource.ResetBindings(false);
                    btn_sua.Enabled = btn_xoa.Enabled = false;
                    txt_sohd.Clear();
                    mask_ngbatdau.Clear();
                    mask_ngketthuc.Clear();
                    txt_noidung.Clear();
                    txt_thoihan.Clear();
                    txt_hesoluong.Clear();
                    txt_sohd.Focus();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
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
            if (dgv_hd.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy hợp đồng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_hd.SelectedRows)
                        {
                            string sohopdong = r.Cells["SoHopDong"].Value.ToString();                        
                            string sql = "DELETE FROM HopDong WHERE SoHopDong=@sohopdong";                          
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@sohopdong", sohopdong);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        loadMaNhanVien();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Đã hủy hợp đồng với nhân viên mang mã: "+cb_nv.Text +"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_sohd.Clear();
                        mask_ngbatdau.Clear();
                        mask_ngketthuc.Clear();
                        txt_noidung.Clear();
                        txt_thoihan.Clear();
                        txt_hesoluong.Clear();
                        cb_nv.Enabled = false;
                        txt_sohd.Enabled = mask_ngbatdau.Enabled = mask_ngketthuc.Enabled = txt_noidung.Enabled = txt_thoihan.Enabled =txt_hesoluong.Enabled= false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi hủy hợp đồng: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên bạn muốn hủy hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            
            mask_ngbatdau.Enabled = true;
            mask_ngketthuc.Enabled = true;
            txt_noidung.Enabled = true;
            txt_thoihan.Enabled = true;
            txt_hesoluong.Enabled = true;
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
                string sohopdong = txt_sohd.Text;
                DateTime ngaybatdau;
                if (!DateTime.TryParseExact(mask_ngbatdau.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaybatdau))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime ngayketthuc;
                if (!DateTime.TryParseExact(mask_ngketthuc.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayketthuc))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaybatdau > ngayketthuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc", "Thông báo");
                }
                else
                {
                    string sqlUpdate = "UPDATE HopDong SET SoHopDong=@sohopdong, NgayBatDau=@ngaybatdau,  NgayKetThuc=@ngayketthuc, NoiDung=@noidung, ThoiHan=@thoihan, HeSoLuong=@hesoluong, MaNV=@manv Where SoHopDong=@sohopdong";
                    cmd = new SqlCommand(sqlUpdate, connect);
                    cmd.Parameters.AddWithValue("@sohopdong", sohopdong);
                    cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                    cmd.Parameters.AddWithValue("@ngayketthuc", ngayketthuc);
                    cmd.Parameters.AddWithValue("@noidung", txt_noidung.Text);
                    cmd.Parameters.AddWithValue("@thoihan", txt_thoihan.Text);
                    cmd.Parameters.AddWithValue("@hesoluong", txt_hesoluong.Text);
                    cmd.Parameters.AddWithValue("@manv", cb_nv.SelectedValue);

                    cmd.ExecuteNonQuery();

                    // Tải lại dữ liệu
                    loadform();
                    loadMaNhanVien();
                    bindingSource.ResetBindings(false);
                    btn_sua.Enabled = btn_xoa.Enabled = false;
                    txt_sohd.Clear();
                    mask_ngbatdau.Clear();
                    mask_ngketthuc.Clear();
                    txt_noidung.Clear();
                    txt_thoihan.Clear();
                    txt_hesoluong.Clear();
                    btn_luu.Enabled = false;
                    cb_nv.Enabled = false;
                    txt_sohd.Enabled = mask_ngbatdau.Enabled = mask_ngketthuc.Enabled = txt_noidung.Enabled = txt_thoihan.Enabled = txt_hesoluong.Enabled = false;
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
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
            foreach (DataGridViewColumn column in dgv_hd.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_hd.Rows)
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
                for (int i = 0; i < dgv_hd.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_hd.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_hd.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_hd.Columns.Count; j++)
                    {
                        if (dgv_hd.Columns[j].Name == "NgayBatDau"|| dgv_hd.Columns[j].Name == "NgayKetThuc") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_hd.Rows[i].Cells[j].Value != null && dgv_hd.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_hd.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_hd.Rows[i].Cells[j].Value.ToString();
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
                            workSheet.Cells[i + 2, j + 1].Value = dgv_hd.Rows[i].Cells[j].Value;
                        }
                    }
                }

                // Lưu file Excel
                byte[] bin = excel.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
        }
        private bool daXuatBan = false;
        private void btn_xuatban_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
