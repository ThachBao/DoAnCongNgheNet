namespace HMresourcemanagementsystem
{
    partial class QuanLyKhenThuongKyLuat
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
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mask_ngay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_manv = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_loai = new System.Windows.Forms.TextBox();
            this.txt_tenktkl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.txt_maktkl = new System.Windows.Forms.TextBox();
            this.dgv_dt = new System.Windows.Forms.DataGridView();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_moi = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_excel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_xoasearch = new System.Windows.Forms.Button();
            this.txt_timMNV = new System.Windows.Forms.TextBox();
            this.picker1 = new System.Windows.Forms.DateTimePicker();
            this.rdbt_2 = new System.Windows.Forms.RadioButton();
            this.rdbt_1 = new System.Windows.Forms.RadioButton();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dt)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(622, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(437, 37);
            this.label14.TabIndex = 29;
            this.label14.Text = "Quản Lý Khen Thưởng Kỹ Luật";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(681, -114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 37);
            this.label1.TabIndex = 28;
            this.label1.Text = "Quản Lý Nhân Sự";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.mask_ngay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbo_manv);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_loai);
            this.groupBox1.Controls.Add(this.txt_tenktkl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_noidung);
            this.groupBox1.Controls.Add(this.txt_maktkl);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(115, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 326);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";
            // 
            // mask_ngay
            // 
            this.mask_ngay.Location = new System.Drawing.Point(164, 133);
            this.mask_ngay.Mask = "00/00/0000";
            this.mask_ngay.Name = "mask_ngay";
            this.mask_ngay.Size = new System.Drawing.Size(283, 32);
            this.mask_ngay.TabIndex = 3;
            this.mask_ngay.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Nhân Viên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nội Dung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã KTKL";
            // 
            // cbo_manv
            // 
            this.cbo_manv.FormattingEnabled = true;
            this.cbo_manv.Location = new System.Drawing.Point(667, 125);
            this.cbo_manv.Name = "cbo_manv";
            this.cbo_manv.Size = new System.Drawing.Size(217, 33);
            this.cbo_manv.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày";
            // 
            // txt_loai
            // 
            this.txt_loai.Location = new System.Drawing.Point(164, 210);
            this.txt_loai.Name = "txt_loai";
            this.txt_loai.Size = new System.Drawing.Size(283, 32);
            this.txt_loai.TabIndex = 5;
            // 
            // txt_tenktkl
            // 
            this.txt_tenktkl.Location = new System.Drawing.Point(667, 55);
            this.txt_tenktkl.Name = "txt_tenktkl";
            this.txt_tenktkl.Size = new System.Drawing.Size(283, 32);
            this.txt_tenktkl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên KTKL";
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(667, 196);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(219, 124);
            this.txt_noidung.TabIndex = 6;
            // 
            // txt_maktkl
            // 
            this.txt_maktkl.Location = new System.Drawing.Point(164, 64);
            this.txt_maktkl.Name = "txt_maktkl";
            this.txt_maktkl.Size = new System.Drawing.Size(283, 32);
            this.txt_maktkl.TabIndex = 1;
            // 
            // dgv_dt
            // 
            this.dgv_dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgv_dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dt.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dt.Location = new System.Drawing.Point(115, 642);
            this.dgv_dt.Name = "dgv_dt";
            this.dgv_dt.RowHeadersWidth = 51;
            this.dgv_dt.RowTemplate.Height = 24;
            this.dgv_dt.Size = new System.Drawing.Size(1439, 367);
            this.dgv_dt.TabIndex = 26;
            this.dgv_dt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dt_CellClick);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Image = global::HMresourcemanagementsystem.Properties.Resources.delete_32px;
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(468, 29);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 66);
            this.btn_xoa.TabIndex = 9;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Image = global::HMresourcemanagementsystem.Properties.Resources.add_32px;
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(310, 34);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(106, 66);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            this.btn_them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::HMresourcemanagementsystem.Properties.Resources.save_32px;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(796, 28);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(107, 66);
            this.btn_luu.TabIndex = 11;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Image = global::HMresourcemanagementsystem.Properties.Resources.update_32px;
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(639, 28);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(111, 66);
            this.btn_sua.TabIndex = 10;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_moi
            // 
            this.btn_moi.Image = global::HMresourcemanagementsystem.Properties.Resources.reset_32px1;
            this.btn_moi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_moi.Location = new System.Drawing.Point(143, 34);
            this.btn_moi.Name = "btn_moi";
            this.btn_moi.Size = new System.Drawing.Size(125, 66);
            this.btn_moi.TabIndex = 7;
            this.btn_moi.Text = "Làm Mới";
            this.btn_moi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_moi.UseVisualStyleBackColor = true;
            this.btn_moi.Click += new System.EventHandler(this.btn_moi_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Image = global::HMresourcemanagementsystem.Properties.Resources.close_32px;
            this.btn_thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thoat.Location = new System.Drawing.Point(957, 28);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(110, 66);
            this.btn_thoat.TabIndex = 12;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.Btn_excel);
            this.groupBox2.Controls.Add(this.btn_moi);
            this.groupBox2.Controls.Add(this.btn_thoat);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.btn_luu);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(115, 496);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1439, 100);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các Chức Năng";
            // 
            // Btn_excel
            // 
            this.Btn_excel.Image = global::HMresourcemanagementsystem.Properties.Resources.excel;
            this.Btn_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_excel.Location = new System.Drawing.Point(1098, 28);
            this.Btn_excel.Name = "Btn_excel";
            this.Btn_excel.Size = new System.Drawing.Size(146, 63);
            this.Btn_excel.TabIndex = 21;
            this.Btn_excel.Text = "Xuất Excel";
            this.Btn_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_excel.UseVisualStyleBackColor = true;
            this.Btn_excel.Click += new System.EventHandler(this.Btn_excel_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btn_xoasearch);
            this.groupBox3.Controls.Add(this.txt_timMNV);
            this.groupBox3.Controls.Add(this.picker1);
            this.groupBox3.Controls.Add(this.rdbt_2);
            this.groupBox3.Controls.Add(this.rdbt_1);
            this.groupBox3.Controls.Add(this.btn_timkiem);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1129, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 326);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm Kiếm";
            // 
            // btn_xoasearch
            // 
            this.btn_xoasearch.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoasearch.Location = new System.Drawing.Point(228, 273);
            this.btn_xoasearch.Name = "btn_xoasearch";
            this.btn_xoasearch.Size = new System.Drawing.Size(187, 47);
            this.btn_xoasearch.TabIndex = 2;
            this.btn_xoasearch.Text = "Xóa Tìm Kiếm";
            this.btn_xoasearch.UseVisualStyleBackColor = true;
            this.btn_xoasearch.Click += new System.EventHandler(this.btn_xoasearch_Click);
            // 
            // txt_timMNV
            // 
            this.txt_timMNV.Location = new System.Drawing.Point(57, 109);
            this.txt_timMNV.Name = "txt_timMNV";
            this.txt_timMNV.Size = new System.Drawing.Size(179, 33);
            this.txt_timMNV.TabIndex = 0;
            // 
            // picker1
            // 
            this.picker1.CustomFormat = "MM/yyyy";
            this.picker1.Location = new System.Drawing.Point(57, 217);
            this.picker1.Name = "picker1";
            this.picker1.Size = new System.Drawing.Size(290, 33);
            this.picker1.TabIndex = 0;
            this.picker1.Value = new System.DateTime(2024, 11, 6, 0, 0, 0, 0);
            // 
            // rdbt_2
            // 
            this.rdbt_2.AutoSize = true;
            this.rdbt_2.Location = new System.Drawing.Point(57, 164);
            this.rdbt_2.Name = "rdbt_2";
            this.rdbt_2.Size = new System.Drawing.Size(173, 29);
            this.rdbt_2.TabIndex = 1;
            this.rdbt_2.TabStop = true;
            this.rdbt_2.Text = "Tìm Theo Ngày";
            this.rdbt_2.UseVisualStyleBackColor = true;
            this.rdbt_2.CheckedChanged += new System.EventHandler(this.rdbt_2_CheckedChanged);
            // 
            // rdbt_1
            // 
            this.rdbt_1.AutoSize = true;
            this.rdbt_1.Location = new System.Drawing.Point(57, 55);
            this.rdbt_1.Name = "rdbt_1";
            this.rdbt_1.Size = new System.Drawing.Size(253, 29);
            this.rdbt_1.TabIndex = 1;
            this.rdbt_1.TabStop = true;
            this.rdbt_1.Text = "Tìm Theo Mã Nhân Viên";
            this.rdbt_1.UseVisualStyleBackColor = true;
            this.rdbt_1.CheckedChanged += new System.EventHandler(this.rdbt_1_CheckedChanged);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(28, 273);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(151, 47);
            this.btn_timkiem.TabIndex = 0;
            this.btn_timkiem.Text = "Tìm Kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // QuanLyKhenThuongKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 1055);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_dt);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyKhenThuongKyLuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyKhenThuongKyLuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuanLyKhenThuongKyLuat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mask_ngay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_manv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tenktkl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.TextBox txt_maktkl;
        private System.Windows.Forms.DataGridView dgv_dt;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_moi;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_loai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbt_1;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.RadioButton rdbt_2;
        private System.Windows.Forms.DateTimePicker picker1;
        private System.Windows.Forms.TextBox txt_timMNV;
        private System.Windows.Forms.Button btn_xoasearch;
        private System.Windows.Forms.Button Btn_excel;
    }
}