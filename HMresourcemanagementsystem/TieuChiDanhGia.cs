using ClosedXML;
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

namespace HMresourcemanagementsystem
{
    public partial class TieuChiDanhGia : Form
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
        public TieuChiDanhGia()
        {
            InitializeComponent();
            connect = kn.con;
        }

        private void load_LoaiTieuChi()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT LoaiTieuChi FROM TieuChi";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cbo_loaitieuchi.DataSource = dt;
                //cbo_loaitieuchi.DisplayMember = "LoaiTieuChi";
                cbo_loaitieuchi.ValueMember = "LoaiTieuChi";

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

        private void load_nguoilap()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql = "SELECT DISTINCT Nguoilap FROM TieuChi";
                adap = new SqlDataAdapter(sql, connect);
                dt = new DataTable();
                adap.Fill(dt);
                cb_nguoilap.DataSource = dt;
                //cb_nguoilap.DisplayMember = "NguoiLap";
                cb_nguoilap.ValueMember = "NguoiLap";

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

                string sql1 = "SELECT * FROM TieuChi";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_tieuchi.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    cb_nguoilap.SelectedValue = dgv_tieuchi.Rows[0].Cells["NguoiLap"].Value.ToString();
                    txt_matc.Text = dgv_tieuchi.Rows[0].Cells["MaTieuChi"].Value.ToString();
                    txt_tentc.Text = dgv_tieuchi.Rows[0].Cells["TenTieuChi"].Value.ToString();
                    cbo_loaitieuchi.SelectedValue = dgv_tieuchi.Rows[0].Cells["LoaiTieuChi"].Value.ToString();
                    txt_tytrong.Text = dgv_tieuchi.Rows[0].Cells["TyTrong"].Value.ToString();
                }
                else
                {
                    cbo_loaitieuchi.SelectedIndex = -1;
                    cb_nguoilap.SelectedIndex = -1;
                    txt_stt.Clear();
                    txt_matc.Clear();
                    txt_tentc.Clear();
                    txt_tytrong.Clear();
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

        private void dgv_tieuchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_tieuchi.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_stt.Text = dgv_tieuchi.Rows[index].Cells["STT"].Value.ToString();
                cb_nguoilap.SelectedValue = dgv_tieuchi.Rows[index].Cells["NguoiLap"].Value.ToString();
                txt_matc.Text = dgv_tieuchi.Rows[index].Cells["MaTieuChi"].Value.ToString();
                txt_tentc.Text = dgv_tieuchi.Rows[index].Cells["TenTieuChi"].Value.ToString();
                cbo_loaitieuchi.SelectedValue = dgv_tieuchi.Rows[index].Cells["LoaiTieuChi"].Value.ToString();
                txt_tytrong.Text = dgv_tieuchi.Rows[index].Cells["TyTrong"].Value.ToString();
            }
            txt_stt.Enabled = cb_nguoilap.Enabled = txt_matc.Enabled = txt_tentc.Enabled = txt_tytrong.Enabled = cbo_loaitieuchi.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_luu.Enabled = btn_them.Enabled = false;
        }

        private void TieuChiDanhGia_Load(object sender, EventArgs e)
        {
            txt_stt.Enabled = cbo_loaitieuchi.Enabled = cb_nguoilap.Enabled = txt_matc.Enabled = txt_tentc.Enabled = txt_tytrong.Enabled = false;
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            dgv_tieuchi.ReadOnly = true;
            dgv_tieuchi.AllowUserToAddRows = false;
            loadform();
            load_LoaiTieuChi();
            load_nguoilap();
            
        }


        private void btn_moi_Click(object sender, EventArgs e)
        {
            txt_stt.Enabled = false;
            cb_nguoilap.Enabled = true;
            txt_matc.Enabled = true;
            txt_tentc.Enabled = true;
            cbo_loaitieuchi.Enabled = true;
            txt_tytrong.Enabled = true;


            btn_them.Enabled = true;
            btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            // Xoá các trường dữ liệu
            txt_matc.Clear();
            txt_tentc.Clear();
            txt_tytrong.Clear();
            txt_matc.Focus();

            // Đặt chế độ đọc cho datagirdview
            dgv_tieuchi.ReadOnly = false;
            for (int i = 0; i < dgv_tieuchi.Rows.Count - 1; i++)
            {
                dgv_tieuchi.Rows[i].ReadOnly = true;
            }
            //    dgv_hd.FirstDisplayedScrollingRowIndex = dgv_hd.Rows.Count - 1;
            dgv_tieuchi.AllowUserToAddRows = true;
            
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if ( string.IsNullOrEmpty(cb_nguoilap.Text) || string.IsNullOrEmpty(txt_matc.Text) || txt_tentc.Text == null
                    || string.IsNullOrEmpty(cbo_loaitieuchi.Text) || string.IsNullOrEmpty(txt_tytrong.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Kiểm tra xem Mã tiêu chí đã tồn tại hay chưa
                string checkSql = "SELECT COUNT(*) FROM TieuChi WHERE MaTieuChi=@matieuchi";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@matieuchi", txt_matc.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã tiêu chí này đã tồn tại. Vui lòng chọn mã tiêu chí khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO TieuChi (Nguoilap, MaTieuChi, TenTieuChi, LoaiTieuChi, TyTrong) VALUES ( @nguoilap, @matieuchi, @tentieuchi, @loaitieuchi, @tytrong)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@nguoilap", cb_nguoilap.Text);
                cmd.Parameters.AddWithValue("@matieuchi", txt_matc.Text);
                cmd.Parameters.AddWithValue("@tentieuchi", txt_tentc.Text);
                cmd.Parameters.AddWithValue("@loaitieuchi", cbo_loaitieuchi.Text);
                cmd.Parameters.AddWithValue("@tytrong", txt_tytrong.Text);


                cmd.ExecuteNonQuery();
                loadform();
                load_LoaiTieuChi();
                load_nguoilap();
               
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_stt.Clear();
                txt_matc.Clear();
                txt_stt.Clear();
                txt_tentc.Clear();
                txt_tytrong.Clear();
                txt_matc.Focus();
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
            if (dgv_tieuchi.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tiêu chí này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connect.Open();
                    try
                    {
                        foreach (DataGridViewRow r in dgv_tieuchi.SelectedRows)
                        {
                            string matc = r.Cells["MaTieuChi"].Value.ToString();
                            string sql = "DELETE FROM TieuChi WHERE MaTieuChi=@matieuchi";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@matieuchi", matc);
                            cmd.ExecuteNonQuery();
                        }
                        loadform();
                        load_LoaiTieuChi();
                        load_nguoilap();
                       
                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Đã xóa tiêu chí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_matc.Clear();
                        txt_stt.Clear();
                        txt_tentc.Clear();
                        txt_tytrong.Clear();
                        txt_matc.Enabled = txt_stt.Enabled = txt_tentc.Enabled = txt_tytrong.Enabled = cbo_loaitieuchi.Enabled = cb_nguoilap.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa tiêu chí: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tiêu chí bạn muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
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
                string matieuchi = txt_matc.Text;
                

                string sqlUpdate = "UPDATE TieuChi SET Nguoilap=@nguoilap, MaTieuChi=@matieuchi, TenTieuChi=@tentieuchi, LoaiTieuChi=@loaitieuchi, TyTrong=@tytrong Where MaTieuChi=@matieuchi";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@nguoilap", cb_nguoilap.Text);
                cmd.Parameters.AddWithValue("@matieuchi", matieuchi);
                cmd.Parameters.AddWithValue("@tentieuchi", txt_tentc.Text);
                cmd.Parameters.AddWithValue("@loaitieuchi", cbo_loaitieuchi.Text);
                cmd.Parameters.AddWithValue("@tytrong", txt_tytrong.Text);

                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadform();
                load_LoaiTieuChi();
                load_nguoilap();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                txt_matc.Clear();
                txt_stt.Clear();
                txt_tentc.Clear();
                txt_tytrong.Clear();
                btn_luu.Enabled = false;
                txt_matc.Enabled = txt_stt.Enabled = txt_tentc.Enabled = txt_tytrong.Enabled = cbo_loaitieuchi.Enabled = cb_nguoilap.Enabled = false;
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_matc.Enabled = true;
            txt_tentc.Enabled = true;
            txt_tytrong.Enabled = true;
            cbo_loaitieuchi.Enabled = true;
            cb_nguoilap.Enabled = true;

            btn_them.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }

       



    }
}
