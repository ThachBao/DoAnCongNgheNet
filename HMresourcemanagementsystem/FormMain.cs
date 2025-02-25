using HMresourcemanagementsystem.ChamCong;
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
    public partial class FormMain : Form
    {
        private string role;
        private string tendangnhap;

        public FormMain(string PHANQUYEN, string ten)
        {
            InitializeComponent();
            role = PHANQUYEN;
            tendangnhap = ten;
            if (PHANQUYEN == "ADMIN")
            {
                btn_chamcong.Enabled = false;
                btn_luong.Enabled = false;
            }
            else if(PHANQUYEN == "QLCHAMCONG")
            {
                btn_qltaikhoan.Enabled = false;
                btn_nhanvien.Enabled = false;
                btn_bophan.Enabled = false;
                btn_hopdong.Enabled = false;
                btn_duan.Enabled = false;
                btn_luong.Enabled = false;
                btn_bc.Enabled = false;
                btn_danhgia.Enabled = false;
                btn_daotao.Enabled = false;

            }
            else
            {
                btn_qltaikhoan.Enabled = false;
                btn_nhanvien.Enabled = false;
                btn_bophan.Enabled = false;
                btn_hopdong.Enabled = false;
                btn_duan.Enabled = false;
                btn_chamcong.Enabled = false;
                btn_bc.Enabled = false;
                btn_danhgia.Enabled = false;
                btn_daotao.Enabled = false;

            }
        }
        public bool checkMdiChildren(string formName)
        {
            if(this.MdiChildren.Length > 0)
            {
                Form[] frm = this.MdiChildren;
                for(int i=0; i < this.MdiChildren.Length; i++)
                {
                    if (frm[i].Name == formName)
                        return false;
                }    
            }    
            return true;
        }

        private void mn_changepass_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.ShowDialog();
        }



        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Đăng Xuất Khỏi Phần Mềm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }

        }



        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Phần Mềm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dia == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btn_qltaikhoan_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            Quanly mana = new Quanly();
            mana.TopLevel = false;
            mana.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(mana);
            mana.Show();
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            ShowInfoAdmin userInfoForm = new ShowInfoAdmin(tendangnhap);
            userInfoForm.TopLevel = false;
            userInfoForm.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(userInfoForm);
            userInfoForm.Show();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            QuanLyNhanSu qlns = new QuanLyNhanSu();
            qlns.TopLevel = false;
            qlns.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(qlns);
            qlns.Show();
        }




        private void btn_ktkl_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            QuanLyKhenThuongKyLuat qlktkl = new QuanLyKhenThuongKyLuat();
            qlktkl.TopLevel = false;
            qlktkl.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(qlktkl);
            qlktkl.Show();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainCong lstcc = new MainCong();
            lstcc.TopLevel = false;
            lstcc.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(lstcc);
            lstcc.Show();
        }

        private void btn_luong_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainLuong ml = new MainLuong();
            ml.TopLevel = false;
            ml.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(ml);
            ml.Show();
        }

        private void btn_duan_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainDuAn duan = new MainDuAn();
            duan.TopLevel = false;
            duan.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(duan);
            duan.Show();
        }

        private void btn_bophan_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainBoPhan bophan = new MainBoPhan();
            bophan.TopLevel = false;
            bophan.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(bophan);
            bophan.Show();
        }

        private void btn_daotao_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            QuanLyDaoTao qldt = new QuanLyDaoTao();
            qldt.TopLevel = false;
            qldt.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(qldt);
            qldt.Show();
        }

        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainHopDong qldt = new MainHopDong();
            qldt.TopLevel = false;
            qldt.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(qldt);
            qldt.Show();
        }

        private void btn_baocao_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            Report rp = new Report();
            rp.TopLevel = false;
            rp.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(rp);
            rp.Show();
        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            MainDanhGia dg = new MainDanhGia();
            dg.TopLevel = false;
            dg.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(dg);
            dg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pnl_formchild.Controls.Clear();
            FormLienHe lh = new FormLienHe();
            lh.TopLevel = false;
            lh.Dock = DockStyle.Fill;
            pnl_formchild.Controls.Add(lh);
            lh.Show();
        }
    }
}
