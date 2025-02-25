using HMresourcemanagementsystem.ChamCong;
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
    public partial class MainCong : Form
    {
        public MainCong()
        {
            InitializeComponent();
        }

        private void menu_phongban_Click(object sender, EventArgs e)
        {
            menu_chamcong.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_chamcong.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            ListChamCong list = new ListChamCong();
            list.TopLevel = false;
            list.Dock = DockStyle.Fill;
            panel.Controls.Add(list);
            list.Show();
        }

        private void menu_bangcong_Click(object sender, EventArgs e)
        {
            menu_bangcong.ForeColor = System.Drawing.Color.CornflowerBlue;
            menu_bangcong.ForeColor = System.Drawing.Color.Black;
            this.panel.Controls.Clear();
            BangCong bc = new BangCong();
            bc.TopLevel = false;
            bc.Dock = DockStyle.Fill;
            panel.Controls.Add(bc);
            bc.Show();
        }
    }
}
