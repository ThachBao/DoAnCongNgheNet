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
using OfficeOpenXml;


namespace HMresourcemanagementsystem
{
    public partial class PhieuDanhGia : Form
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
        public PhieuDanhGia()
        {
            InitializeComponent();
            connect = kn.con;
            btt_xuatban.Click += btt_xuatban_Click;
        }


        private void load_nguoidanhgia()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT NguoiLap FROM KeHoachDanhGia";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_nguoidg.DataSource = dt;
                //cb_nv.DisplayMember = "MaNV";
                cbo_nguoidg.ValueMember = "NguoiLap";
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

        private void load_tenkh()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT TenKeHoach FROM KeHoachDanhGia";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_tenkh.DataSource = dt;
                //cb_nv.DisplayMember = "MaNV";
                cbo_tenkh.ValueMember = "TenKeHoach";
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

        private void load_manv()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT MaNV FROM NhanVien";
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


        private void loadform()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM PhieuDanhGia";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_phieudg.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    dgv_phieudg.Rows[0].Cells["MaPhieuDanhGia"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["MaKeHoachDanhGia"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["TenKeHoachDanhGia"].Value.ToString();                
                    dgv_phieudg.Rows[0].Cells["SoDoiTuong"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["NguoiDanhGia"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["NgayDanhGia"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["TienDo"].Value.ToString();
                    dgv_phieudg.Rows[0].Cells["MaNV"].Value.ToString();

                }
                else
                {
                    txt_makh.Clear();
                    cbo_nguoidg.SelectedIndex = -1;
                    txt_maphieudg.Clear();
                    txt_stt.Clear();
                    txt_sodt.Clear();
                    cbo_tenkh.SelectedValue = -1;
                    txt_tiendo.Clear();
                    mask_ngaydg.Clear();
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


        

        private void dgv_phieudg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_phieudg.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_stt.Text= dgv_phieudg.Rows[index].Cells["STT"].Value.ToString();
                txt_maphieudg.Text= dgv_phieudg.Rows[index].Cells["MaPhieuDanhGia"].Value.ToString();
                txt_makh.Text= dgv_phieudg.Rows[index].Cells["MaKeHoachDanhGia"].Value.ToString();
                cbo_tenkh.SelectedValue= dgv_phieudg.Rows[index].Cells["TenKeHoachDanhGia"].Value.ToString();
                txt_sodt.Text= dgv_phieudg.Rows[index].Cells["SoDoiTuong"].Value.ToString();
                cbo_nguoidg.SelectedValue= dgv_phieudg.Rows[index].Cells["NguoiDanhGia"].Value.ToString();
                mask_ngaydg.Text= dgv_phieudg.Rows[index].Cells["NgayDanhGia"].Value.ToString();
                txt_tiendo.Text= dgv_phieudg.Rows[index].Cells["TienDo"].Value.ToString();
                cbo_manv.SelectedValue= dgv_phieudg.Rows[index].Cells["MaNV"].Value.ToString();

            }
            txt_maphieudg.Enabled = txt_makh.Enabled = cbo_manv.Enabled = txt_stt.Enabled = cbo_tenkh.Enabled = txt_sodt.Enabled = txt_tiendo.Enabled = cbo_nguoidg.Enabled = mask_ngaydg.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_luu.Enabled = btn_them.Enabled = false;
        }

        private void PhieuDanhGia_Load(object sender, EventArgs e)
        {
            txt_maphieudg.Enabled = txt_makh.Enabled = cbo_manv.Enabled = txt_stt.Enabled = cbo_tenkh.Enabled = txt_sodt.Enabled = txt_tiendo.Enabled = cbo_nguoidg.Enabled = mask_ngaydg.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_phieudg.ReadOnly = true;
            dgv_phieudg.AllowUserToAddRows = false;
            loadform();
            load_manv();
            load_tenkh();
            load_nguoidanhgia();
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_stt.Enabled = false;
            txt_maphieudg.Enabled = true;
            txt_makh.Enabled = true;
            cbo_manv.Enabled = true;
            cbo_tenkh.Enabled = true;
            txt_sodt.Enabled = true;
            cbo_nguoidg.Enabled = true;
            mask_ngaydg.Enabled = true;
            txt_tiendo.Enabled = true;


            btn_them.Enabled = true;
            btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            txt_stt.Clear();
            txt_maphieudg.Clear();
            txt_makh.Clear();
            txt_sodt.Clear();
            mask_ngaydg.Clear();
            txt_tiendo.Clear();
            txt_maphieudg.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_phieudg.ReadOnly = false;
            for (int i = 0; i < dgv_phieudg.Rows.Count - 1; i++)
            {
                dgv_phieudg.Rows[i].ReadOnly = true;
            }
            //    dgv_hd.FirstDisplayedScrollingRowIndex = dgv_hd.Rows.Count - 1;
            dgv_phieudg.AllowUserToAddRows = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_makh.Text) || string.IsNullOrEmpty(cbo_manv.Text) || txt_maphieudg.Text == null
                    || string.IsNullOrEmpty(cbo_tenkh.Text) || string.IsNullOrEmpty(txt_sodt.Text)
                    || string.IsNullOrEmpty(txt_tiendo.Text) || string.IsNullOrEmpty(mask_ngaydg.Text) || string.IsNullOrEmpty(cbo_nguoidg.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Kiểm tra xem Số hợp đồng đã tồn tại hay chưa
                string checkSql1 = "SELECT COUNT(*) FROM PhieuDanhGia WHERE MaPhieuDanhGia=@maphieudanhgia";
                cmd = new SqlCommand(checkSql1, connect);
                cmd.Parameters.AddWithValue("@maphieudanhgia", txt_maphieudg.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã phiếu đánh giá này đã tồn tại. Vui lòng chọn mã phiếu đánh giá khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Chuyển đổi ngày từ MaskedTextBox sang DateTime
                DateTime ngaydg;
                if (!DateTime.TryParseExact(mask_ngaydg.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaydg))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO PhieuDanhGia (MaPhieuDanhGia, MaKeHoachDanhGia, TenKeHoachDanhGia, SoDoiTuong, NguoiDanhGia, NgayDanhGia, TienDo, MaNV) VALUES (@maphieudg,@makehoachdg,@tenkh,@sodoituong,@nguoidanhgia,@ngaydanhgia,@tiendo,@manv)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@maphieudg", txt_maphieudg.Text);
                cmd.Parameters.AddWithValue("@makehoachdg", txt_makh.Text);
                cmd.Parameters.AddWithValue("@tenkh", cbo_tenkh.SelectedValue);
                cmd.Parameters.AddWithValue("@sodoituong", txt_sodt.Text);
                cmd.Parameters.AddWithValue("@nguoidanhgia", cbo_nguoidg.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaydanhgia", ngaydg);
                cmd.Parameters.AddWithValue("@tiendo", txt_tiendo.Text);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.SelectedValue);
         
                cmd.ExecuteNonQuery();

                loadform();
                load_manv();
                load_tenkh();
                load_nguoidanhgia();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_makh.Clear();
                txt_maphieudg.Clear();
                txt_sodt.Clear();
                txt_tiendo.Clear();
                mask_ngaydg.Clear();
                txt_maphieudg.Focus();
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
            if (dgv_phieudg.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu đánh giá này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_phieudg.SelectedRows)
                        {
                            string maphieu = r.Cells["MaPhieuDanhGia"].Value.ToString();
                            string sql = "DELETE FROM PhieuDanhGia WHERE MaPhieuDanhGia=@maphieu";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@maphieu", maphieu);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Đã hủy phiếu đánh giá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi hủy phiếu đánh giá: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu đánh giá mà bạn muốn hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_stt.Enabled = false;
            txt_maphieudg.Enabled = false;
            txt_makh.Enabled = true;
            cbo_nguoidg.Enabled = true;
            mask_ngaydg.Enabled = true;
            txt_tiendo.Enabled = true;
            cbo_tenkh.Enabled = true;
            txt_sodt.Enabled = true;
            cbo_manv.Enabled = true;
            cbo_nguoidg.Enabled = true;

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
                string maphieudg = txt_makh.Text;
                DateTime ngaydg;
                if (!DateTime.TryParseExact(mask_ngaydg.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaydg))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string sqlUpdate = "UPDATE PhieuDanhGia SET MaPhieuDanhGia=@maphieudg, MaKeHoachDanhGia=@makehoachdg, TenKeHoachDanhGia=@tenkh, SoDoiTuong=@sodoituong, NguoiDanhGia=@nguoidanhgia, NgayDanhGia=@ngaydanhgia, TienDo=@tiendo, MaNV=@manv where MaPhieuDanhGia=@maphieudg";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@maphieudg", maphieudg);
                cmd.Parameters.AddWithValue("@makehoachdg", txt_makh.Text);
                cmd.Parameters.AddWithValue("@tenkh", cbo_tenkh.SelectedValue);
                cmd.Parameters.AddWithValue("@sodoituong", txt_sodt.Text);
                cmd.Parameters.AddWithValue("@nguoidanhgia", cbo_nguoidg.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaydanhgia", ngaydg);
                cmd.Parameters.AddWithValue("@tiendo", txt_tiendo.Text);
                cmd.Parameters.AddWithValue("@manv", cbo_manv.Text);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadform();
                load_manv();
                load_nguoidanhgia();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_makh.Clear();
                txt_maphieudg.Clear();
                txt_sodt.Clear();
                txt_tiendo.Clear();
                mask_ngaydg.Clear();
                btn_luu.Enabled = false;
                txt_makh.Enabled = txt_maphieudg.Enabled = txt_sodt.Enabled = txt_stt.Enabled = false;
                cbo_tenkh.Enabled = txt_tiendo.Enabled = cbo_manv.Enabled = cbo_nguoidg.Enabled = mask_ngaydg.Enabled = false;
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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                this.Close();
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
                        MessageBox.Show("Vui lòng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM PhieuDanhGia WHERE TenKeHoachDanhGia=@tenkh";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@tenkh", cbo_tenkh.Text);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_phieudg.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

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
            load_manv();
            load_tenkh();
            load_nguoidanhgia();
            txt_search.Clear();
        }

        private void ExportToCSV(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Thêm tiêu đề cột
            foreach (DataGridViewColumn column in dgv_phieudg.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_phieudg.Rows)
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
                for (int i = 0; i < dgv_phieudg.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_phieudg.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_phieudg.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_phieudg.Columns.Count; j++)
                    {
                        if (dgv_phieudg.Columns[j].Name == "NgayDanhGia") // Kiểm tra nếu cột hiện tại là cột NgaySinh
                        {
                            // Kiểm tra và chuyển đổi giá trị ngày sinh thành chuỗi yyyy-MM-dd nếu có
                            if (dgv_phieudg.Rows[i].Cells[j].Value != null && dgv_phieudg.Rows[i].Cells[j].Value.ToString() != "")
                            {
                                if (DateTime.TryParse(dgv_phieudg.Rows[i].Cells[j].Value.ToString(), out DateTime dateValue))
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    workSheet.Cells[i + 2, j + 1].Value = dgv_phieudg.Rows[i].Cells[j].Value.ToString();
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
                            workSheet.Cells[i + 2, j + 1].Value = dgv_phieudg.Rows[i].Cells[j].Value;
                        }
                    }
                }

                // Lưu file Excel
                byte[] bin = excel.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
        }
        private bool daXuatBan = false;
        private void btt_xuatban_Click(object sender, EventArgs e)
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
