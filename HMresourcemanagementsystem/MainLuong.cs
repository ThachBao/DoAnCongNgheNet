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
    public partial class MainLuong : Form
    {
        public MainLuong()
        {
            InitializeComponent();
        }

        private void menu_luong_Click(object sender, EventArgs e)
        {
            menu_luong.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_ktkl.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyLuong qll = new QuanLyLuong();
            qll.TopLevel = false;
            qll.Dock = DockStyle.Fill;
            panel.Controls.Add(qll);
            qll.Show();
        }

        private void menu_ktkl_Click(object sender, EventArgs e)
        {
            menu_luong.ForeColor = System.Drawing.Color.Black;
            menu_ktkl.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel.Controls.Clear();
            QuanLyKhenThuongKyLuat ktkl = new QuanLyKhenThuongKyLuat();
            ktkl.TopLevel = false;
            ktkl.Dock = DockStyle.Fill;
            panel.Controls.Add(ktkl);
            ktkl.Show();
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            menu_luong.ForeColor = System.Drawing.Color.Black;
            menu_ktkl.ForeColor = System.Drawing.Color.Black;
            DialogResult dia;
            dia = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
