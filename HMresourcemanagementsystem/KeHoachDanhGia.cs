using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMresourcemanagementsystem;
namespace HMresourcemanagementsystem
{
    public partial class KeHoachDanhGia : Form
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
        public KeHoachDanhGia()
        {
            InitializeComponent();
            connect = kn.con;
        }

        private void load_nguoilap()
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
                cbo_nguoilap.DataSource = dt;
                //cb_nv.DisplayMember = "MaNV";
                cbo_nguoilap.ValueMember = "NguoiLap";
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

        private void load_xeploai()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT XepLoai FROM KeHoachDanhGia";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_xeploai.DataSource = dt;
                //cb_nv.DisplayMember = "MaNV";
                cbo_xeploai.ValueMember = "XepLoai";
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

                string sql1 = "SELECT * FROM KeHoachDanhGia";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_khdg.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    dgv_khdg.Rows[0].Cells["MaKeHoachDanhGia"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["TenKeHoach"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["Nguoilap"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["SoNguoiDanhGia"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["SoDoiTuong"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["SoTieuChi"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["ThangDiem"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["XepLoai"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["ThoiGianBatDau"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["ThoiGianKetThuc"].Value.ToString();
                    dgv_khdg.Rows[0].Cells["TrangThai"].Value.ToString();
                }
                else
                {
                    txt_makh.Clear();
                    txt_thangdiem.Clear();
                    txt_sodoituong.Clear();
                    cbo_xeploai.SelectedValue = -1;
                    cbo_nguoilap.SelectedIndex = -1;
                    txt_songuoidg.Clear();
                    txt_sotieuchi.Clear();
                    txt_makh.Clear();
                    txt_trangthai.Clear();
                    mask_tgbatdau.Clear();
                    mask_tgketthuc.Clear();
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


        private void dgv_khdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_khdg.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_stt.Text= dgv_khdg.Rows[index].Cells["STT"].Value.ToString();
                txt_makh.Text= dgv_khdg.Rows[index].Cells["MaKeHoachDanhGia"].Value.ToString();
                txt_tenkh.Text= dgv_khdg.Rows[index].Cells["TenKeHoach"].Value.ToString();
                cbo_nguoilap.SelectedValue= dgv_khdg.Rows[index].Cells["Nguoilap"].Value.ToString();
                txt_songuoidg.Text= dgv_khdg.Rows[index].Cells["SoNguoiDanhGia"].Value.ToString();
                txt_sodoituong.Text= dgv_khdg.Rows[index].Cells["SoDoiTuong"].Value.ToString();
                txt_sotieuchi.Text= dgv_khdg.Rows[index].Cells["SoTieuChi"].Value.ToString();
                txt_thangdiem.Text= dgv_khdg.Rows[index].Cells["ThangDiem"].Value.ToString();
                cbo_xeploai.SelectedValue= dgv_khdg.Rows[index].Cells["XepLoai"].Value.ToString();
                mask_tgbatdau.Text= dgv_khdg.Rows[index].Cells["ThoiGianBatDau"].Value.ToString();
                mask_tgketthuc.Text= dgv_khdg.Rows[index].Cells["ThoiGianKetThuc"].Value.ToString();
                txt_trangthai.Text= dgv_khdg.Rows[index].Cells["TrangThai"].Value.ToString();

            }
            
            txt_sodoituong.Enabled = txt_songuoidg.Enabled = txt_sotieuchi.Enabled = txt_stt.Enabled =txt_makh.Enabled=txt_trangthai.Enabled=cbo_nguoilap.Enabled=mask_tgbatdau.Enabled=mask_tgketthuc.Enabled= false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;

            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_luu.Enabled = btn_them.Enabled = false;
        }



        private void KeHoachDanhGia_Load(object sender, EventArgs e)
        {
            txt_thangdiem.Enabled=cbo_xeploai.Enabled= txt_makh.Enabled= txt_sodoituong.Enabled = txt_songuoidg.Enabled = txt_sotieuchi.Enabled = txt_stt.Enabled = txt_makh.Enabled = txt_trangthai.Enabled = cbo_nguoilap.Enabled=mask_tgbatdau.Enabled=mask_tgketthuc.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_khdg.ReadOnly = true;
            dgv_khdg.AllowUserToAddRows = false;
            loadform();
            load_nguoilap();
            load_xeploai();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_thangdiem.Text) || string.IsNullOrEmpty(txt_tenkh.Text) || string.IsNullOrEmpty(txt_makh.Text) || string.IsNullOrEmpty(cbo_xeploai.Text) || string.IsNullOrEmpty(txt_sodoituong.Text) || string.IsNullOrEmpty(txt_songuoidg.Text) 
                    || string.IsNullOrEmpty(txt_sotieuchi.Text)|| string.IsNullOrEmpty(txt_trangthai.Text) || string.IsNullOrEmpty(cbo_nguoilap.Text) || string.IsNullOrEmpty(mask_tgbatdau.Text) || string.IsNullOrEmpty(mask_tgketthuc.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Kiểm tra xem Số hợp đồng đã tồn tại hay chưa
                string checkSql1 = "SELECT COUNT(*) FROM KeHoachDanhGia WHERE MaKeHoachDanhGia=@makh";
                cmd = new SqlCommand(checkSql1, connect);
                cmd.Parameters.AddWithValue("@makh", txt_makh.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã kế hoạch này đã tồn tại. Vui lòng chọn mã kế hoạch khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                // Chuyển đổi ngày từ MaskedTextBox sang DateTime
                DateTime tgbatdau;
                if (!DateTime.TryParseExact(mask_tgbatdau.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out tgbatdau))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime tgketthuc;
                if (!DateTime.TryParseExact(mask_tgketthuc.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out tgketthuc))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tgbatdau>tgketthuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
                }
                else
                {
                    // Thực hiện câu lệnh insert
                    string sqlInsert = "INSERT INTO KeHoachDanhGia (MaKeHoachDanhGia, TenKeHoach, NguoiLap, SoNguoiDanhGia, SoDoiTuong, SoTieuChi,ThangDiem,XepLoai, ThoiGianBatDau, ThoiGianKetThuc, TrangThai) VALUES (@makh,@tenkehoach,@nguoilap,@songuoidanhgia,@sodoituong,@sotieuchi,@thangdiem,@xeploai,@thoigianbatdau,@thoigianketthuc,@trangthai)";
                    cmd = new SqlCommand(sqlInsert, connect);
                    cmd.Parameters.AddWithValue("@makh", txt_makh.Text);
                    cmd.Parameters.AddWithValue("@tenkehoach", txt_tenkh.Text);
                    cmd.Parameters.AddWithValue("@nguoilap", cbo_nguoilap.SelectedValue);
                    cmd.Parameters.AddWithValue("@songuoidanhgia", txt_songuoidg.Text);
                    cmd.Parameters.AddWithValue("@sodoituong", txt_sodoituong.Text);
                    cmd.Parameters.AddWithValue("@sotieuchi", txt_sotieuchi.Text);
                    cmd.Parameters.AddWithValue("@thangdiem", txt_thangdiem.Text);
                    cmd.Parameters.AddWithValue("@xeploai", cbo_xeploai.SelectedValue);
                    cmd.Parameters.AddWithValue("@thoigianbatdau", tgbatdau);
                    cmd.Parameters.AddWithValue("@thoigianketthuc", tgketthuc);
                    cmd.Parameters.AddWithValue("@trangthai", txt_trangthai.Text);


                    cmd.ExecuteNonQuery();

                    loadform();
                    load_nguoilap();
                    load_xeploai();
                    bindingSource.ResetBindings(false);
                    btn_sua.Enabled = btn_xoa.Enabled = false;
                    txt_sodoituong.Clear();
                    txt_thangdiem.Clear();
                    txt_makh.Clear();
                    txt_songuoidg.Clear();
                    txt_sotieuchi.Clear();
                    txt_makh.Clear();
                    txt_trangthai.Clear();
                    mask_tgbatdau.Clear();
                    mask_tgketthuc.Clear();
                    txt_stt.Focus();
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
            ////TieuChi();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_khdg.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa kế hoạch đánh giá này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_khdg.SelectedRows)
                        {
                            string makh = r.Cells["MaKeHoachDanhGia"].Value.ToString();
                            string sql = "DELETE FROM KeHoachDanhGia WHERE MaKeHoachDanhGia=@makh";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@makh", makh);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        load_nguoilap();
                        load_xeploai();
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Đã hủy kế hoạch đánh giá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi hủy kế hoạch đánh giá: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kế hoạch đánh giá mà bạn muốn hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled =  false;
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
                string makh = txt_makh.Text;
                DateTime tgbatdau;
                if (!DateTime.TryParseExact(mask_tgbatdau.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out tgbatdau))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime tgketthuc;
                if (!DateTime.TryParseExact(mask_tgketthuc.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out tgketthuc))
                {
                    MessageBox.Show("Ngày tháng năm không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tgbatdau > tgketthuc)
                {
                    MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc","Thông báo");
                }
                else
                {
                    string sqlUpdate = "UPDATE KeHoachDanhGia SET MaKeHoachDanhGia=@makh, TenKeHoach= @tenkehoach, NguoiLap= @nguoilap, SoNguoiDanhGia= @songuoidanhgia, SoDoiTuong= @sodoituong, SoTieuChi= @sotieuchi, ThangDiem=@thangdiem, XepLoai=@xeploai, ThoiGianBatDau=@thoigianbatdau, ThoiGianKetThuc=@thoigianketthuc, TrangThai=@trangthai Where MaKeHoachDanhGia=@makh";
                    cmd = new SqlCommand(sqlUpdate, connect);
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@tenkehoach", txt_makh.Text);
                    cmd.Parameters.AddWithValue("@nguoilap", cbo_nguoilap.SelectedValue);
                    cmd.Parameters.AddWithValue("@songuoidanhgia", txt_songuoidg.Text);
                    cmd.Parameters.AddWithValue("@sodoituong", txt_sodoituong.Text);
                    cmd.Parameters.AddWithValue("@sotieuchi", txt_sotieuchi.Text);
                    cmd.Parameters.AddWithValue("@thangdiem", txt_thangdiem.Text);
                    cmd.Parameters.AddWithValue("@xeploai", cbo_xeploai.SelectedValue);
                    cmd.Parameters.AddWithValue("@thoigianbatdau", tgbatdau);
                    cmd.Parameters.AddWithValue("@thoigianketthuc", tgketthuc);
                    cmd.Parameters.AddWithValue("@trangthai", txt_trangthai.Text);

                    cmd.ExecuteNonQuery();

                    // Tải lại dữ liệu
                    loadform();
                    load_nguoilap();

                    load_xeploai();
                    bindingSource.ResetBindings(false);
                    btn_sua.Enabled = btn_xoa.Enabled = false;
                    txt_sodoituong.Clear();
                    txt_makh.Clear();
                    txt_thangdiem.Clear();
                    txt_songuoidg.Clear();
                    txt_sotieuchi.Clear();
                    txt_stt.Clear();
                    txt_makh.Clear();
                    txt_trangthai.Clear();
                    mask_tgbatdau.Clear();
                    mask_tgketthuc.Clear();
                    btn_luu.Enabled = false;
                    cbo_nguoilap.Enabled = txt_thangdiem.Enabled = cbo_xeploai.Enabled = txt_makh.Enabled = false;
                    txt_sodoituong.Enabled = txt_songuoidg.Enabled = txt_sotieuchi.Enabled = txt_stt.Enabled = txt_makh.Enabled = txt_trangthai.Enabled = mask_tgbatdau.Enabled = mask_tgketthuc.Enabled = false;
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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_sodoituong.Enabled = true;
            txt_makh.Enabled = true;
            txt_thangdiem.Enabled = true;
            cbo_xeploai.Enabled = true;
            txt_songuoidg.Enabled = true;
            txt_sotieuchi.Enabled = true;
            txt_stt.Enabled = false;
            txt_makh.Enabled = true;
            txt_trangthai.Enabled = true;
            cbo_nguoilap.Enabled = true;
            mask_tgbatdau.Enabled = true;
            mask_tgketthuc.Enabled = true;


            btn_them.Enabled = true;
            btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            txt_sodoituong.Clear();
            txt_makh.Clear();
            txt_thangdiem.Clear();
            txt_songuoidg.Clear();
            txt_sotieuchi.Clear();
            txt_stt.Clear();
            txt_makh.Clear();
            txt_trangthai.Clear();
            mask_tgbatdau.Clear();
            mask_tgketthuc.Clear();
            txt_stt.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_khdg.ReadOnly = false;
            for (int i = 0; i < dgv_khdg.Rows.Count - 1; i++)
            {
                dgv_khdg.Rows[i].ReadOnly = true;
            }
            //    dgv_hd.FirstDisplayedScrollingRowIndex = dgv_hd.Rows.Count - 1;
            dgv_khdg.AllowUserToAddRows = true;
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

                    sqlQuery = "SELECT * FROM KeHoachDanhGia WHERE TenKeHoach=@tenkh";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@tenkh", txt_tenkh.Text);
                }

                // Thực hiện truy vấn và đổ dữ liệu vào DataGridView
                adap = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adap.Fill(resultTable);

                dgv_khdg.DataSource = resultTable; // Hiển thị kết quả tìm kiếm trên DataGridView

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
            load_nguoilap();
            load_xeploai();
            txt_search.Clear();
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            txt_stt.Enabled = false;
            txt_makh.Enabled = false;
            cbo_nguoilap.Enabled = true;
            txt_songuoidg.Enabled = true;
            txt_sodoituong.Enabled = true;
            txt_sotieuchi.Enabled = true;
            txt_thangdiem.Enabled = true;
            cbo_xeploai.Enabled = true;
            mask_tgbatdau.Enabled = true;
            mask_tgketthuc.Enabled = true;
            txt_trangthai.Enabled = true;
            btn_them.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }


    }
}

