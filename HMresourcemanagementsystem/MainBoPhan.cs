using HMresourcemanagementsystem.BoPhan;
using HMresourcemanagementsystem.duAn;
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
    public partial class MainBoPhan : Form
    {
        public MainBoPhan()
        {
            InitializeComponent();
        }

        private void menu_phongban_Click(object sender, EventArgs e)
        {
            menu_phongban.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_phongban.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyPhongBan qll = new QuanLyPhongBan();
            qll.TopLevel = false;
            qll.Dock = DockStyle.Fill;
            panel.Controls.Add(qll);
            qll.Show();
        }

        private void menu_bophan_Click(object sender, EventArgs e)
        {
            menu_bophan.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_bophan.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyBoPhan qll = new QuanLyBoPhan();
            qll.TopLevel = false;
            qll.Dock = DockStyle.Fill;
            panel.Controls.Add(qll);
            qll.Show();
        }
    }
}
