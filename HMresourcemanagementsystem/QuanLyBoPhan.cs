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
using static HMresourcemanagementsystem.BoPhan.QuanLyBoPhan;

namespace HMresourcemanagementsystem.BoPhan
{
    public partial class QuanLyBoPhan : Form
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
        public QuanLyBoPhan()
        {
            InitializeComponent();
            connect = kn.con;
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
                cbo_mapb.DataSource = dt;
                cbo_mapb.DisplayMember = "MaPhong";
                cbo_mapb.ValueMember = "MaPhong";
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
            txt_mabp.Clear();
            txt_tenbp.Clear();
            cbo_mapb.SelectedValue = -1;
        }
        void anthongtin()
        {
            cbo_mapb.Enabled = txt_mabp.Enabled = txt_tenbp.Enabled = false;
            
        }
        void hienthongtin()
        {
            cbo_mapb.Enabled = txt_mabp.Enabled = txt_tenbp.Enabled = true;

        }
        void loadformBP()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM BoPhan";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_dt.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_mabp.Text = dgv_dt.Rows[0].Cells["MaBoPhan"].Value.ToString();
                    txt_tenbp.Text = dgv_dt.Rows[0].Cells["TenBoPhan"].Value.ToString();
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

        private void QuanLyBoPhan_Load(object sender, EventArgs e)
        {
            anthongtin();
            loadPhongBan();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            loadformBP();
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
            hienthongtin();
            xoathongtin();
            txt_mabp.Focus();
            btn_them.Enabled = true;
            btn_luu.Enabled = btn_sua.Enabled = btn_xoa.Enabled = false;
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
                if (string.IsNullOrEmpty(txt_mabp.Text) || string.IsNullOrEmpty(txt_tenbp.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkSql = "SELECT COUNT(*) FROM BoPhan WHERE MaBoPhan = @mabp";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@mabp", txt_mabp.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã bộ phận này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO BoPhan (MaBoPhan, TenBoPhan, MaPhong) " +
                                   "VALUES (@mabp, @tenbp, @mapb)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@mabp", txt_mabp.Text);
                cmd.Parameters.AddWithValue("@tenbp", txt_tenbp.Text);
                cmd.Parameters.AddWithValue("@mapb", cbo_mapb.SelectedValue);

                cmd.ExecuteNonQuery();

                loadformBP();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
                txt_mabp.Focus();
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

        private void dgv_dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_dt.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_mabp.Text = dgv_dt.Rows[index].Cells["MaBoPhan"].Value.ToString();
                txt_tenbp.Text = dgv_dt.Rows[index].Cells["TenBoPhan"].Value.ToString();
                cbo_mapb.SelectedValue = dgv_dt.Rows[index].Cells["MaPhong"].Value.ToString();
            }
            anthongtin();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
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
                            string mabp = r.Cells["MaBoPhan"].Value.ToString();
                            string sql = "DELETE FROM BoPhan WHERE MaBoPhan=@mabp";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@mabp", mabp);
                            cmd.ExecuteNonQuery();
                        }
                        loadformBP();
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
            txt_tenbp.Enabled = true;
            cbo_mapb.Enabled = true;
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
                string mabp = txt_mabp.Text;
                string sqlUpdate = "UPDATE BoPhan SET TenBoPhan=@tenbp,  MaPhong=@mapb Where MaBoPhan=@mabp";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@mabp", mabp);
                cmd.Parameters.AddWithValue("@tenbp", txt_tenbp.Text);
                cmd.Parameters.AddWithValue("@mapb", cbo_mapb.SelectedValue);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadformBP();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
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

        private void txt_tenbp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập ký tự chữ trong tên khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Vui lòng nhập mã phòng ban để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sqlQuery = "SELECT * FROM BoPhan WHERE MaPhong = @maphong";
                    cmd = new SqlCommand(sqlQuery, connect);
                    cmd.Parameters.AddWithValue("@maphong", txt_search.Text);
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

        private void btn_desearch_Click(object sender, EventArgs e)
        {
            loadformBP();
            txt_search.Clear();
            anthongtin();
        }
    }
}
