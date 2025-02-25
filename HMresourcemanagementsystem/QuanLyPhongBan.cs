using HMresourcemanagementsystem.BoPhan;
using HMresourcemanagementsystem.duAn;
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
    public partial class QuanLyPhongBan : Form
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
        public QuanLyPhongBan()
        {
            InitializeComponent();
            connect = kn.con;
        }
        void loadformPB()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                string sql1 = "SELECT * FROM PhongBan";
                adap1 = new SqlDataAdapter(sql1, connect);
                dt1 = new DataTable();
                adap1.Fill(dt1);
                bindingSource.DataSource = dt1;
                dgv_dt.DataSource = bindingSource;

                if (dt1.Rows.Count > 0)
                {
                    txt_mapb.Text = dgv_dt.Rows[0].Cells["MaPhong"].Value.ToString();
                    txt_tenpb.Text = dgv_dt.Rows[0].Cells["TenPhong"].Value.ToString();
                }
                else
                {
                    txt_mapb.Clear();
                    txt_tenpb.Clear();
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
        void xoathongtin()
        {
            txt_mapb.Clear();
            txt_tenpb.Clear();
        }
        void anthongtin()
        {
            txt_mapb.Enabled = false;
            txt_tenpb.Enabled = false;
        }
        void hienthongtin()
        {
            txt_mapb.Enabled = true;
            txt_tenpb.Enabled = true;
        }
        private void QuanLyPhongBan_Load(object sender, EventArgs e)
        {
            anthongtin();
            btn_them.Enabled = btn_sua.Enabled = btn_xoa.Enabled = btn_luu.Enabled =false;
            loadformPB();
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
            txt_mapb.Focus();
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

        private void dgv_dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgv_dt.Rows.Count - 1)
            {
                int index = e.RowIndex;
                txt_mapb.Text = dgv_dt.Rows[index].Cells["MaPhong"].Value.ToString();
                txt_tenpb.Text = dgv_dt.Rows[index].Cells["TenPhong"].Value.ToString();
            }
            anthongtin();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_mapb.Text) || string.IsNullOrEmpty(txt_tenpb.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkSql = "SELECT COUNT(*) FROM PhongBan WHERE MaPhong = @mapb";
                cmd = new SqlCommand(checkSql, connect);
                cmd.Parameters.AddWithValue("@mapb", txt_mapb.Text);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã phòng ban này đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện câu lệnh insert
                string sqlInsert = "INSERT INTO PhongBan (MaPhong, TenPhong) " +
                                   "VALUES (@mapb, @tenpc)";
                cmd = new SqlCommand(sqlInsert, connect);
                cmd.Parameters.AddWithValue("@mapb", txt_mapb.Text);
                cmd.Parameters.AddWithValue("@tenpc", txt_tenpb.Text);
                cmd.ExecuteNonQuery();

                loadformPB();
                bindingSource.ResetBindings(false);
                btn_sua.Enabled = btn_xoa.Enabled = false;
                xoathongtin();
                txt_mapb.Focus();
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
                            string mapb = r.Cells["MaPhong"].Value.ToString();
                            string sql = "DELETE FROM PhongBan WHERE MaPhong=@mapb";
                            cmd = new SqlCommand(sql, connect);
                            cmd.Parameters.AddWithValue("@mapb", mapb);
                            cmd.ExecuteNonQuery();
                        }
                        loadformPB();
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
            txt_tenpb.Enabled = true;
            btn_them.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }

        private void txt_tenpb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
                MessageBox.Show("Chỉ được phép nhập ký tự chữ trong tên khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string mapb = txt_mapb.Text;
                string sqlUpdate = "UPDATE PhongBan SET TenPhong=@tenpb Where MaPhong=@mapb";
                cmd = new SqlCommand(sqlUpdate, connect);
                cmd.Parameters.AddWithValue("@mapb", mapb);
                cmd.Parameters.AddWithValue("@tenpb", txt_tenpb.Text);
                cmd.ExecuteNonQuery();

                // Tải lại dữ liệu
                loadformPB();
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
    }
}

