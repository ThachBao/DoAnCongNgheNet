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
using System.Text.RegularExpressions;
using System.Xml.Linq;
namespace HMresourcemanagementsystem.duAn
{
    public partial class BangThongKeDuAn : Form
    {
        connection kn = new connection();
        SqlConnection connec;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //Khởi tạo idDuAn Để Lưu trữ mã dự án Từ bảng quản lý dự án
        public string idDuAn { get; set; }

        public BangThongKeDuAn()
        {
            InitializeComponent();
            connec = kn.con;
            cb_dauViec.SelectedIndexChanged += new EventHandler(cb_dauViec_SelectedIndexChanged);
            this.FormClosed += new FormClosedEventHandler(BangThongKeDuAn_FormClosed);
            DGV_DAUVIEC.CellClick += DGV_DAUVIEC_CellClick;
        }

        private void BangThongKeDuAn_Load(object sender, EventArgs e)
        {
            txt_maDuAn.Enabled = false;
            txt_maPhong.Enabled = false;
            txt_moTa.Enabled = false;
            txt_maNhanVien.Enabled= false;
            txt_maDauViec.Enabled = false;
            txt_tenDauViec.Enabled = false;
            load_dataGridView_Start(idDuAn);
            LoadData();
            load_combobox(txt_maDuAn.Text);

        }
        private void load_combobox(string maDuAn)
        {
            connec.Close();
            try
            {
                connec.Open();
                string sql = @"SELECT DVDA.MADAUVIEC, DVDA.TenDauViec FROM DAUVIECDUAN DVDA WHERE DVDA.MaDuAn = @maDuAn";
                using (cmd = new SqlCommand(sql, connec))
                {
                    cmd.Parameters.AddWithValue("@maDuAn", maDuAn);
                    DataTable dt = new DataTable();
                    using (da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        cb_dauViec.DataSource = dt;
                        cb_dauViec.DisplayMember = "TenDauViec";
                        cb_dauViec.ValueMember = "MADAUVIEC";
                    }
                    connec.Close();
                }
            }
            catch (Exception ex)
            {
                connec.Close();
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connec.Close();
            }
        }

        private void load_dataGridView_Start(string maDuAn)
        {
            connec.Close();
            DGV_DAUVIEC.DataSource = null;

            // Xây dựng câu truy vấn SQL dựa trên điều kiện mã dự án
            string sql = @"
                    SELECT DVDA.MaDauViec, DVDA.TenDauViec ,NV.MANV, NV.HoTen
                    FROM DAUVIECDUAN DVDA
                    JOIN NHANVIEN NV ON NV.MaNV = DVDA.MaNV
                    WHERE DVDA.MaDuAn = @maDuAn
                ";

            try
            {
                connec.Open();

                using (cmd = new SqlCommand(sql, connec))
                {
                    // Chỉ thêm tham số khi có mã dự án
                    if (!string.IsNullOrEmpty(maDuAn))
                    {
                        cmd.Parameters.AddWithValue("@maDuAn", maDuAn);
                    }

                    using (da = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                        DGV_DAUVIEC.DataSource = dt;
                    }
                    connec.Close();
                }
            }
            catch (Exception ex)
            {
                connec.Close();
                MessageBox.Show("Lỗi " + ex.Message);
            }
            finally
            {
                connec.Close();
            }
        }
        private void LoadData()
        {

            // sử dụng dữ liệu id DU AN
            txt_maDuAn.Text = idDuAn.ToString();
            string maduan = txt_maDuAn.Text;
            connec.Open();
            string sql = @"SELECT DA.MOTA,DA.MAPHONG
                            FROM DUAN DA
                            WHERE DA.MADUAN =@maduan
                        ";
            try
            {
                using (cmd = new SqlCommand(sql, connec))
                {
                    cmd.Parameters.AddWithValue("@maduan", maduan);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_moTa.Text = dr["MoTa"].ToString();
                        txt_maPhong.Text = dr["MaPhong"].ToString();
                    }


                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                connec.Close();
                throw ex;
            }
            finally
            {
                connec.Close();
            }
        }
        private void load_dataGridView(string MaDuAn, string maDauViec)
        {
            connec.Close();
            DGV_DAUVIEC.DataSource = null; // Đặt lại DataSource về null thay vì false

            string sql = @"
                    SELECT DVDA.MaDauViec AS N'Mã Đầu Việc Dự Án', 
                           DVDA.TenDauViec AS N'Tên Đầu Việc', 
                           NV.HoTen AS N'Tên Nhân Viên',
                           NV.MANV AS N'Mã Nhân Viên'
                    FROM DAUVIECDUAN DVDA
                    JOIN NHANVIEN NV ON NV.MaNV = DVDA.MaNV
                    WHERE DVDA.MaDuAn = @MaDuAn AND DVDA.MaDauViec=@maDauViec
                  ";

            // Kiểm tra nếu MaDuAn là null hoặc rỗng
            if (string.IsNullOrEmpty(MaDuAn))
            {
                MessageBox.Show("Mã dự án không hợp lệ.");
                return;
            }
            txt_maDauViec.Clear();
            txt_maDauViec.Text = maDauViec;
            try
            {
                // Sử dụng using để đảm bảo đóng kết nối
                connec.Open();

                using (SqlCommand cmd = new SqlCommand(sql, connec))
                {
                    cmd.Parameters.AddWithValue("@MaDuAn", MaDuAn);
                    cmd.Parameters.AddWithValue("@maDauViec", maDauViec);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DGV_DAUVIEC.DataSource = dt;
                    }

                }
                connec.Close();
            }
            catch (Exception ex)
            {
                connec.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void cb_dauViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_dauViec.SelectedValue != null)
            {
                string maDauViec = cb_dauViec.SelectedValue.ToString();
                
                load_dataGridView(txt_maDuAn.Text, maDauViec); 
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đầu việc hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void bt_exit_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Quay Lại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                QuanLyDuAn qa = new QuanLyDuAn();
                qa.ShowDialog();
                this.Close();
            }
        }

        //load lại datagridview ở phần trước 
        private void BangThongKeDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner is QuanLyDuAn ql)
            {
                ql.ReloadDataGridView();
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            txt_maDuAn.Enabled = false;
            txt_maPhong.Enabled = false;
            txt_moTa.Enabled = true;
            txt_maNhanVien.Enabled = true;
            txt_maDauViec.Enabled = true;
            txt_tenDauViec.Enabled = true;
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đầu việc và điền đủ thông tin hay chưa
            if (string.IsNullOrEmpty(txt_maDuAn.Text) || string.IsNullOrEmpty(cb_dauViec.Text) ||
                string.IsNullOrEmpty(txt_tenDauViec.Text) || string.IsNullOrEmpty(txt_maNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn một đầu việc và nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện cập nhật đầu việc trong cơ sở dữ liệu
            try
            {
                connec.Open();
                string sql = @"
                            UPDATE DAUVIECDUAN
                            SET TenDauViec = @TenDauViec, MaNV = @MaNV
                            WHERE MaDuAn = @MaDuAn AND MaDauViec = @MaDauViec
                        ";

                using (cmd = new SqlCommand(sql, connec))
                {
                    // Gán các giá trị vào tham số
                    cmd.Parameters.AddWithValue("@MaDuAn", txt_maDuAn.Text);
                    cmd.Parameters.AddWithValue("@MaDauViec", cb_dauViec.SelectedValue);
                    cmd.Parameters.AddWithValue("@TenDauViec", txt_tenDauViec.Text);
                    cmd.Parameters.AddWithValue("@MaNV", txt_maNhanVien.Text);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật đầu việc thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_dataGridView_Start(txt_maDuAn.Text); // Reload lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connec.Close();
            }
        }

        private void bt_luu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maDauViec.Text) || string.IsNullOrEmpty(txt_tenDauViec.Text) || string.IsNullOrEmpty(txt_maNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connec.Open();
                string sql = "INSERT INTO DAUVIECDUAN (MaDauViec,TenDauViec,MaDuAn, MaNV) VALUES (@MaDV, @TenDauViec,@MaDuAn, @MaNV)";
                using (cmd = new SqlCommand(sql, connec))
                {
                    cmd.Parameters.AddWithValue("@MaDV", txt_maDauViec.Text);
                    cmd.Parameters.AddWithValue("@TenDauViec", txt_tenDauViec.Text);
                    cmd.Parameters.AddWithValue("@MaDuAn", txt_maDuAn.Text);
                    cmd.Parameters.AddWithValue("@MaNV", txt_maNhanVien.Text);
                    //cmd.Parameters.AddWithValue("@MoTa", txt_moTa.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm đầu việc thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connec.Close();
                        load_dataGridView_Start(txt_maDuAn.Text); // Reload DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                connec.Close();
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connec.Close();
            }
        }

        private void bt_xoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đầu việc chưa
            if (string.IsNullOrEmpty(txt_maDuAn.Text) || string.IsNullOrEmpty(cb_dauViec.Text))
            {
                MessageBox.Show("Vui lòng chọn một đầu việc để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi người dùng có chắc chắn muốn xóa không
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa đầu việc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    connec.Open();
                    string sql = @"
                                DELETE FROM DAUVIECDUAN
                                WHERE MaDuAn = @MaDuAn AND MaDauViec = @MaDauViec
                            ";

                    using (cmd = new SqlCommand(sql, connec))
                    {
                        cmd.Parameters.AddWithValue("@MaDuAn", txt_maDuAn.Text);
                        cmd.Parameters.AddWithValue("@MaDauViec",txt_maDauViec.Text); // Lấy giá trị được chọn từ combobox

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa đầu việc thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_dataGridView_Start(txt_maDuAn.Text); // Reload lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công. Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connec.Close();
                }
            }
        }

        private void DGV_DAUVIEC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ các cột trong DataGridView
                DataGridViewRow row = DGV_DAUVIEC.Rows[e.RowIndex];
                // Cập nhật các thông tin trong các TextBox từ dữ liệu trong hàng được chọn
                txt_maDauViec.Text = row.Cells["Mã Đầu Việc Dự Án"].Value.ToString();
                txt_tenDauViec.Text = row.Cells["Tên Đầu Việc"].Value.ToString();
                txt_maNhanVien.Text = row.Cells["Mã Nhân Viên"].Value.ToString();

                // Tự động cập nhật combobox dựa trên mã đầu việc đã chọn
                cb_dauViec.SelectedValue = row.Cells["Mã Đầu Việc Dự Án"].Value.ToString();

                // Cập nhật các thông tin khác nếu cần thiết
                string maDauViec = row.Cells["Mã Đầu Việc Dự Án"].Value.ToString();
                string maDuAn = txt_maDuAn.Text; // lấy mã dự án từ TextBox (đã có trong form)

                // Gọi lại phương thức để load dữ liệu mới vào DataGridView nếu cần (có thể thêm các điều kiện lọc)
                load_dataGridView(maDuAn, maDauViec);
            }
        }
    
    }
 }

