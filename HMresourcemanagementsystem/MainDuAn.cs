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
    public partial class MainDuAn : Form
    {
        public MainDuAn()
        {
            InitializeComponent();
        }

        private void menu_list_Click(object sender, EventArgs e)
        {
            menu_list.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_list.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            QuanLyDuAn qll = new QuanLyDuAn();
            qll.TopLevel = false;
            qll.Dock = DockStyle.Fill;
            panel.Controls.Add(qll);
            qll.Show();
        }

        private void menu_phancong_Click(object sender, EventArgs e)
        {
            menu_phancong.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_phancong.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            PhanCong pc = new PhanCong();
            pc.TopLevel = false;
            pc.Dock = DockStyle.Fill;
            panel.Controls.Add(pc);
            pc.Show();
        }


    }
}
