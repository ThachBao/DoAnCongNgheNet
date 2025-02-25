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
    public partial class KetQuaDanhGia : Form
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
        public KetQuaDanhGia()
        {
            InitializeComponent();
            connect = kn.con;
            btt_xuatban.Click += btt_xuatban_Click;
        }

        private void loadform()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT KQDG.STT, NV.MaNV, NV.HoTen, PB.TenPhong AS TenPhongNhanVien, CV.TenChucVu AS TenChucVuNhanVien, KQDG.MaKeHoachDanhGia, KQDG.TenKeHoach, KQDG.NguoiLap AS NguoiLapKeHoach, FORMAT(KQDG.ThangDiem, '0.0') AS ThangDiem, KQDG.XepLoai FROM KetQuaDanhGia KQ JOIN NhanVien NV ON KQ.MaNV = NV.MaNV JOIN KeHoachDanhGia KQDG ON KQ.MaKeHoachDanhGia = KQDG.MaKeHoachDanhGia JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_ketquadg.DataSource = bindingSource;

                if (dt1.Rows.Count > 0) 
                {
                    dgv_ketquadg.Rows[0].Cells["MaNV"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["HoTen"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["TenPhongNhanVien"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["TenChucVuNhanVien"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["MaKeHoachDanhGia"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["TenKeHoach"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["NguoiLapKeHoach"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["ThangDiem"].Value.ToString();
                    dgv_ketquadg.Rows[0].Cells["XepLoai"].Value.ToString();
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


        private void KetQuaDanhGia_Load(object sender, EventArgs e)
        {
            loadform();
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
            foreach (DataGridViewColumn column in dgv_ketquadg.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.AppendLine();

            // Thêm dữ liệu
            foreach (DataGridViewRow row in dgv_ketquadg.Rows)
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
                for (int i = 0; i < dgv_ketquadg.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dgv_ketquadg.Columns[i].HeaderText;
                }

                // Thêm dữ liệu
                for (int i = 0; i < dgv_ketquadg.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_ketquadg.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1].Value = dgv_ketquadg.Rows[i].Cells[j].Value;
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

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sqlQuery = "";
                if (!string.IsNullOrEmpty(txt_search.Text))
                {
                    // Sử dụng thêm '%' để tìm kiếm theo phần của tên, không yêu cầu trùng khớp hoàn toàn
                    sqlQuery = "SELECT KQDG.STT, NV.MaNV, NV.HoTen, PB.TenPhong AS TenPhongNhanVien, CV.TenChucVu AS TenChucVuNhanVien, KQDG.MaKeHoachDanhGia, KQDG.TenKeHoach, KQDG.NguoiLap AS NguoiLapKeHoach, KQDG.ThangDiem AS ThangDiem, KQDG.XepLoai FROM KetQuaDanhGia KQ JOIN NhanVien NV ON KQ.MaNV = NV.MaNV JOIN KeHoachDanhGia KQDG ON KQ.MaKeHoachDanhGia = KQDG.MaKeHoachDanhGia JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu WHERE NV.HoTen LIKE @hoten";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@hoten", "%" + txt_search.Text + "%");

                    adap = new SqlDataAdapter(cmd);
                    DataTable resultTable = new DataTable();
                    adap.Fill(resultTable);

                    dgv_ketquadg.DataSource = resultTable;
                    dgv_ketquadg.Refresh(); // Cập nhật hiển thị của DataGridView

                    if (resultTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btn_desearch_Click_1(object sender, EventArgs e)
        {
            loadform();
            txt_search.Clear();
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
    }
}
