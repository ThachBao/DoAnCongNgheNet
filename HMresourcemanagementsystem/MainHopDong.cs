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
    public partial class MainHopDong : Form
    {
        public MainHopDong()
        {
            InitializeComponent();
        }

        private void menu_hopdong_Click(object sender, EventArgs e)
        {
            menu_hopdong.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_hopdong.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyHopDong pc = new QuanLyHopDong();
            pc.TopLevel = false;
            pc.Dock = DockStyle.Fill;
            panel.Controls.Add(pc);
            pc.Show();
        }

        private void menu_baohiem_Click(object sender, EventArgs e)
        {
            menu_baohiem.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_baohiem.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyBaoHiem pc = new QuanLyBaoHiem();
            pc.TopLevel = false;
            pc.Dock = DockStyle.Fill;
            panel.Controls.Add(pc);
            pc.Show();
        }
    }
}
