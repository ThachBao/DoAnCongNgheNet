namespace HMresourcemanagementsystem
{
    partial class QuanLyHopDong
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_nv = new System.Windows.Forms.ComboBox();
            this.txt_hesoluong = new System.Windows.Forms.TextBox();
            this.txt_thoihan = new System.Windows.Forms.TextBox();
            this.txt_sohd = new System.Windows.Forms.TextBox();
            this.mask_ngketthuc = new System.Windows.Forms.MaskedTextBox();
            this.mask_ngbatdau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.dgv_hd = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_xuatban = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_moi = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.cb_nv);
            this.groupBox1.Controls.Add(this.txt_hesoluong);
            this.groupBox1.Controls.Add(this.txt_thoihan);
            this.groupBox1.Controls.Add(this.txt_sohd);
            this.groupBox1.Controls.Add(this.mask_ngketthuc);
            this.groupBox1.Controls.Add(this.mask_ngbatdau);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_noidung);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(334, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1296, 304);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý hợp đồng";
            // 
            // cb_nv
            // 
            this.cb_nv.FormattingEnabled = true;
            this.cb_nv.Location = new System.Drawing.Point(164, 68);
            this.cb_nv.Name = "cb_nv";
            this.cb_nv.Size = new System.Drawing.Size(283, 33);
            this.cb_nv.TabIndex = 13;
            // 
            // txt_hesoluong
            // 
            this.txt_hesoluong.Location = new System.Drawing.Point(603, 175);
            this.txt_hesoluong.Name = "txt_hesoluong";
            this.txt_hesoluong.Size = new System.Drawing.Size(312, 32);
            this.txt_hesoluong.TabIndex = 12;
            // 
            // txt_thoihan
            // 
            this.txt_thoihan.Location = new System.Drawing.Point(603, 121);
            this.txt_thoihan.Name = "txt_thoihan";
            this.txt_thoihan.Size = new System.Drawing.Size(312, 32);
            this.txt_thoihan.TabIndex = 11;
            // 
            // txt_sohd
            // 
            this.txt_sohd.Location = new System.Drawing.Point(164, 121);
            this.txt_sohd.Name = "txt_sohd";
            this.txt_sohd.Size = new System.Drawing.Size(283, 32);
            this.txt_sohd.TabIndex = 10;
            // 
            // mask_ngketthuc
            // 
            this.mask_ngketthuc.Location = new System.Drawing.Point(164, 234);
            this.mask_ngketthuc.Mask = "00/00/0000";
            this.mask_ngketthuc.Name = "mask_ngketthuc";
            this.mask_ngketthuc.Size = new System.Drawing.Size(283, 32);
            this.mask_ngketthuc.TabIndex = 9;
            this.mask_ngketthuc.ValidatingType = typeof(System.DateTime);
            // 
            // mask_ngbatdau
            // 
            this.mask_ngbatdau.Location = new System.Drawing.Point(164, 175);
            this.mask_ngbatdau.Mask = "00/00/0000";
            this.mask_ngbatdau.Name = "mask_ngbatdau";
            this.mask_ngbatdau.Size = new System.Drawing.Size(283, 32);
            this.mask_ngbatdau.TabIndex = 4;
            this.mask_ngbatdau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hệ số lương";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(473, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thời hạn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nội dung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số hợp đồng";
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(603, 67);
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(312, 32);
            this.txt_noidung.TabIndex = 5;
            // 
            // dgv_hd
            // 
            this.dgv_hd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_hd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_hd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hd.Location = new System.Drawing.Point(334, 610);
            this.dgv_hd.Name = "dgv_hd";
            this.dgv_hd.RowHeadersWidth = 51;
            this.dgv_hd.RowTemplate.Height = 24;
            this.dgv_hd.Size = new System.Drawing.Size(1296, 273);
            this.dgv_hd.TabIndex = 20;
            this.dgv_hd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hd_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btn_xuatban);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_moi);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.btn_luu);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(334, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1296, 118);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các Chức Năng";
            // 
            // btn_xuatban
            // 
            this.btn_xuatban.Image = global::HMresourcemanagementsystem.Properties.Resources.excel;
            this.btn_xuatban.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xuatban.Location = new System.Drawing.Point(1144, 29);
            this.btn_xuatban.Name = "btn_xuatban";
            this.btn_xuatban.Size = new System.Drawing.Size(146, 63);
            this.btn_xuatban.TabIndex = 22;
            this.btn_xuatban.Text = "Xuất Excel";
            this.btn_xuatban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xuatban.UseVisualStyleBackColor = true;
            this.btn_xuatban.Click += new System.EventHandler(this.btn_xuatban_Click);
            // 
            // button1
            // 
            this.button1.Image = global::HMresourcemanagementsystem.Properties.Resources.close_32px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1007, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 66);
            this.button1.TabIndex = 19;
            this.button1.Text = "Thoát";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_moi
            // 
            this.btn_moi.Image = global::HMresourcemanagementsystem.Properties.Resources.reset_32px1;
            this.btn_moi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_moi.Location = new System.Drawing.Point(45, 29);
            this.btn_moi.Name = "btn_moi";
            this.btn_moi.Size = new System.Drawing.Size(125, 66);
            this.btn_moi.TabIndex = 13;
            this.btn_moi.Text = "Làm Mới";
            this.btn_moi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_moi.UseVisualStyleBackColor = true;
            this.btn_moi.Click += new System.EventHandler(this.btn_moi_Click);
            // 
            // btn_them
            // 
            this.btn_them.Image = global::HMresourcemanagementsystem.Properties.Resources.add_32px;
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(211, 29);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(179, 66);
            this.btn_them.TabIndex = 14;
            this.btn_them.Text = "Thêm hợp đồng";
            this.btn_them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::HMresourcemanagementsystem.Properties.Resources.save_32px;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(847, 29);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(107, 66);
            this.btn_luu.TabIndex = 17;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Image = global::HMresourcemanagementsystem.Properties.Resources.update_32px;
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(630, 29);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(176, 66);
            this.btn_sua.TabIndex = 16;
            this.btn_sua.Text = "Sửa hợp đồng";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Image = global::HMresourcemanagementsystem.Properties.Resources.delete_32px;
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(428, 29);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(164, 66);
            this.btn_xoa.TabIndex = 15;
            this.btn_xoa.Text = "Hủy hợp đồng";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // QuanLyHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1836, 926);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_hd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyHopDong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuanLyHopDong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mask_ngbatdau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.DataGridView dgv_hd;
        private System.Windows.Forms.TextBox txt_sohd;
        private System.Windows.Forms.MaskedTextBox mask_ngketthuc;
        private System.Windows.Forms.TextBox txt_thoihan;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_moi;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.TextBox txt_hesoluong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_nv;
        private System.Windows.Forms.Button btn_xuatban;
    }
}