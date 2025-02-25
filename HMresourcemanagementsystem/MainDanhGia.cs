using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMresourcemanagementsystem
{
    public partial class MainDanhGia : Form
    {
        public MainDanhGia()
        {
            InitializeComponent();
        }

        private void menu_tieuchi_Click(object sender, EventArgs e)
        {
            menu_tieuchi.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_tieuchi.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            TieuChiDanhGia tc = new TieuChiDanhGia();
            tc.TopLevel = false;
            tc.Dock = DockStyle.Fill;
            panel.Controls.Add(tc);
            tc.Show();
        }

        private void menu_kehoach_Click(object sender, EventArgs e)
        {
            menu_kehoach.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_kehoach.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            KeHoachDanhGia kh = new KeHoachDanhGia();
            kh.TopLevel = false;
            kh.Dock = DockStyle.Fill;
            panel.Controls.Add(kh);
            kh.Show();
        }

        private void menu_phieu_Click(object sender, EventArgs e)
        {
            menu_phieu.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_phieu.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            PhieuDanhGia pdg = new PhieuDanhGia();
            pdg.TopLevel = false;
            pdg.Dock = DockStyle.Fill;
            panel.Controls.Add(pdg);
            pdg.Show();
        }

        private void menu_ketqua_Click(object sender, EventArgs e)
        {
            menu_ketqua.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_ketqua.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            KetQuaDanhGia kq = new KetQuaDanhGia();
            kq.TopLevel = false;
            kq.Dock = DockStyle.Fill;
            panel.Controls.Add(kq);
            kq.Show();
        }
    }
}
