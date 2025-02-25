namespace HMresourcemanagementsystem
{
    partial class MainDanhGia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_tieuchi = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_kehoach = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_phieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ketqua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 47);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1264, 481);
            this.panel.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_tieuchi,
            this.menu_kehoach,
            this.menu_phieu,
            this.menu_ketqua});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 47);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_tieuchi
            // 
            this.menu_tieuchi.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_tieuchi.Name = "menu_tieuchi";
            this.menu_tieuchi.Size = new System.Drawing.Size(287, 43);
            this.menu_tieuchi.Text = "Tiêu Chí Đánh Giá";
            this.menu_tieuchi.Click += new System.EventHandler(this.menu_tieuchi_Click);
            // 
            // menu_kehoach
            // 
            this.menu_kehoach.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_kehoach.Name = "menu_kehoach";
            this.menu_kehoach.Size = new System.Drawing.Size(306, 43);
            this.menu_kehoach.Text = "Kế Hoạch Đánh Giá";
            this.menu_kehoach.Click += new System.EventHandler(this.menu_kehoach_Click);
            // 
            // menu_phieu
            // 
            this.menu_phieu.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_phieu.Name = "menu_phieu";
            this.menu_phieu.Size = new System.Drawing.Size(240, 43);
            this.menu_phieu.Text = "Phiếu Đánh Giá";
            this.menu_phieu.Click += new System.EventHandler(this.menu_phieu_Click);
            // 
            // menu_ketqua
            // 
            this.menu_ketqua.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_ketqua.Name = "menu_ketqua";
            this.menu_ketqua.Size = new System.Drawing.Size(276, 43);
            this.menu_ketqua.Text = "Kết Quả Đánh Giá";
            this.menu_ketqua.Click += new System.EventHandler(this.menu_ketqua_Click);
            // 
            // MainDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 528);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDanhGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDanhGia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_tieuchi;
        private System.Windows.Forms.ToolStripMenuItem menu_kehoach;
        private System.Windows.Forms.ToolStripMenuItem menu_phieu;
        private System.Windows.Forms.ToolStripMenuItem menu_ketqua;
    }
}