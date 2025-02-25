﻿namespace HMresourcemanagementsystem.duAn
{
    partial class BangThongKeDuAn
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.txt_maDuAn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_dauViec = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_moTa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DGV_DAUVIEC = new System.Windows.Forms.DataGridView();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tenDauViec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maNhanVien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_maPhong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_maDauViec = new System.Windows.Forms.TextBox();
            this.bt_luu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DAUVIEC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(517, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng Thống Kê Dự Án";
            // 
            // bt_exit
            // 
            this.bt_exit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_exit.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exit.Location = new System.Drawing.Point(976, 582);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(171, 63);
            this.bt_exit.TabIndex = 2;
            this.bt_exit.Text = "Thoát";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // txt_maDuAn
            // 
            this.txt_maDuAn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_maDuAn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maDuAn.Location = new System.Drawing.Point(326, 62);
            this.txt_maDuAn.Name = "txt_maDuAn";
            this.txt_maDuAn.Size = new System.Drawing.Size(177, 34);
            this.txt_maDuAn.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã Dự Án";
            // 
            // cb_dauViec
            // 
            this.cb_dauViec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cb_dauViec.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dauViec.FormattingEnabled = true;
            this.cb_dauViec.Location = new System.Drawing.Point(326, 223);
            this.cb_dauViec.Name = "cb_dauViec";
            this.cb_dauViec.Size = new System.Drawing.Size(177, 34);
            this.cb_dauViec.TabIndex = 10;
            this.cb_dauViec.SelectedIndexChanged += new System.EventHandler(this.cb_dauViec_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mục đầu việc";
            // 
            // txt_moTa
            // 
            this.txt_moTa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_moTa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_moTa.Location = new System.Drawing.Point(883, 185);
            this.txt_moTa.Multiline = true;
            this.txt_moTa.Name = "txt_moTa";
            this.txt_moTa.Size = new System.Drawing.Size(251, 54);
            this.txt_moTa.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mô Tả";
            // 
            // DGV_DAUVIEC
            // 
            this.DGV_DAUVIEC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DGV_DAUVIEC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_DAUVIEC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DAUVIEC.GridColor = System.Drawing.SystemColors.Control;
            this.DGV_DAUVIEC.Location = new System.Drawing.Point(208, 348);
            this.DGV_DAUVIEC.Name = "DGV_DAUVIEC";
            this.DGV_DAUVIEC.RowHeadersWidth = 51;
            this.DGV_DAUVIEC.RowTemplate.Height = 24;
            this.DGV_DAUVIEC.Size = new System.Drawing.Size(751, 269);
            this.DGV_DAUVIEC.TabIndex = 16;
            this.DGV_DAUVIEC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_DAUVIEC_CellClick);
            // 
            // bt_them
            // 
            this.bt_them.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_them.Location = new System.Drawing.Point(208, 272);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(135, 56);
            this.bt_them.TabIndex = 17;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_xoa.Location = new System.Drawing.Point(424, 272);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(135, 56);
            this.bt_xoa.TabIndex = 18;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click_1);
            // 
            // bt_sua
            // 
            this.bt_sua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_sua.Location = new System.Drawing.Point(634, 272);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(135, 56);
            this.bt_sua.TabIndex = 19;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tên Đầu Việc";
            // 
            // txt_tenDauViec
            // 
            this.txt_tenDauViec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_tenDauViec.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenDauViec.Location = new System.Drawing.Point(326, 165);
            this.txt_tenDauViec.Name = "txt_tenDauViec";
            this.txt_tenDauViec.Size = new System.Drawing.Size(177, 34);
            this.txt_tenDauViec.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(731, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 26);
            this.label7.TabIndex = 22;
            this.label7.Text = "Mã Nhân Viên";
            // 
            // txt_maNhanVien
            // 
            this.txt_maNhanVien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_maNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maNhanVien.Location = new System.Drawing.Point(883, 82);
            this.txt_maNhanVien.Name = "txt_maNhanVien";
            this.txt_maNhanVien.Size = new System.Drawing.Size(145, 34);
            this.txt_maNhanVien.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(750, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã Phòng";
            // 
            // txt_maPhong
            // 
            this.txt_maPhong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_maPhong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maPhong.Location = new System.Drawing.Point(883, 138);
            this.txt_maPhong.Name = "txt_maPhong";
            this.txt_maPhong.Size = new System.Drawing.Size(145, 34);
            this.txt_maPhong.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(171, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 26);
            this.label8.TabIndex = 24;
            this.label8.Text = "Mã Đầu Việc";
            // 
            // txt_maDauViec
            // 
            this.txt_maDauViec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_maDauViec.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maDauViec.Location = new System.Drawing.Point(326, 115);
            this.txt_maDauViec.Name = "txt_maDauViec";
            this.txt_maDauViec.Size = new System.Drawing.Size(177, 34);
            this.txt_maDauViec.TabIndex = 25;
            // 
            // bt_luu
            // 
            this.bt_luu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_luu.Location = new System.Drawing.Point(835, 272);
            this.bt_luu.Name = "bt_luu";
            this.bt_luu.Size = new System.Drawing.Size(112, 56);
            this.bt_luu.TabIndex = 26;
            this.bt_luu.Text = "Lưu";
            this.bt_luu.UseVisualStyleBackColor = true;
            this.bt_luu.Click += new System.EventHandler(this.bt_luu_Click_1);
            // 
            // BangThongKeDuAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 668);
            this.Controls.Add(this.bt_luu);
            this.Controls.Add(this.txt_maDauViec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_maNhanVien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_tenDauViec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_sua);
            this.Controls.Add(this.bt_xoa);
            this.Controls.Add(this.bt_them);
            this.Controls.Add(this.DGV_DAUVIEC);
            this.Controls.Add(this.txt_maPhong);
            this.Controls.Add(this.txt_moTa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_dauViec);
            this.Controls.Add(this.txt_maDuAn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BangThongKeDuAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BangThongKeDuAn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BangThongKeDuAn_FormClosed);
            this.Load += new System.EventHandler(this.BangThongKeDuAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DAUVIEC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.TextBox txt_maDuAn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_dauViec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_moTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGV_DAUVIEC;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tenDauViec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_maNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_maPhong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_maDauViec;
        private System.Windows.Forms.Button bt_luu;
    }
}