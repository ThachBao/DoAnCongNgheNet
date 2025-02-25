namespace HMresourcemanagementsystem
{
    partial class QuanLyNhanSu
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
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.cbo_bophan = new System.Windows.Forms.ComboBox();
            this.cbo_phongban = new System.Windows.Forms.ComboBox();
            this.cbo_gioitinh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.picture_1 = new System.Windows.Forms.PictureBox();
            this.mask_ngsinh = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_trinhdo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_chucvu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_hinhanh = new System.Windows.Forms.TextBox();
            this.txt_trangthai = new System.Windows.Forms.TextBox();
            this.txt_cancuoc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgv_ns = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_moi = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_desearch = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ns)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(712, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Nhân Sự";
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(164, 64);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(283, 32);
            this.txt_manv.TabIndex = 1;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Location = new System.Drawing.Point(603, 67);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(219, 32);
            this.txt_diachi.TabIndex = 5;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(164, 121);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(283, 32);
            this.txt_hoten.TabIndex = 2;
            this.txt_hoten.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_hoten_KeyPress);
            // 
            // cbo_bophan
            // 
            this.cbo_bophan.FormattingEnabled = true;
            this.cbo_bophan.Location = new System.Drawing.Point(603, 232);
            this.cbo_bophan.Name = "cbo_bophan";
            this.cbo_bophan.Size = new System.Drawing.Size(219, 33);
            this.cbo_bophan.TabIndex = 7;
            // 
            // cbo_phongban
            // 
            this.cbo_phongban.FormattingEnabled = true;
            this.cbo_phongban.Location = new System.Drawing.Point(603, 180);
            this.cbo_phongban.Name = "cbo_phongban";
            this.cbo_phongban.Size = new System.Drawing.Size(219, 33);
            this.cbo_phongban.TabIndex = 8;
            this.cbo_phongban.SelectedIndexChanged += new System.EventHandler(this.cbo_phongban_SelectedIndexChanged);
            // 
            // cbo_gioitinh
            // 
            this.cbo_gioitinh.FormattingEnabled = true;
            this.cbo_gioitinh.Location = new System.Drawing.Point(164, 175);
            this.cbo_gioitinh.Name = "cbo_gioitinh";
            this.cbo_gioitinh.Size = new System.Drawing.Size(283, 33);
            this.cbo_gioitinh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bộ Phận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phòng Ban";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã Nhân Viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Họ Tên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giới Tính";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày Sinh";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btn_file);
            this.groupBox1.Controls.Add(this.picture_1);
            this.groupBox1.Controls.Add(this.mask_ngsinh);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_trinhdo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbo_chucvu);
            this.groupBox1.Controls.Add(this.cbo_phongban);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbo_bophan);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_hinhanh);
            this.groupBox1.Controls.Add(this.txt_trangthai);
            this.groupBox1.Controls.Add(this.txt_hoten);
            this.groupBox1.Controls.Add(this.cbo_gioitinh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_cancuoc);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_diachi);
            this.groupBox1.Controls.Add(this.txt_manv);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(139, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1522, 282);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(1213, 233);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(122, 33);
            this.btn_file.TabIndex = 13;
            this.btn_file.Text = "Open File";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // picture_1
            // 
            this.picture_1.Location = new System.Drawing.Point(1321, 55);
            this.picture_1.Name = "picture_1";
            this.picture_1.Size = new System.Drawing.Size(179, 165);
            this.picture_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_1.TabIndex = 7;
            this.picture_1.TabStop = false;
            // 
            // mask_ngsinh
            // 
            this.mask_ngsinh.Location = new System.Drawing.Point(164, 234);
            this.mask_ngsinh.Mask = "00/00/0000";
            this.mask_ngsinh.Name = "mask_ngsinh";
            this.mask_ngsinh.Size = new System.Drawing.Size(283, 32);
            this.mask_ngsinh.TabIndex = 4;
            this.mask_ngsinh.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(885, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trình Độ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(885, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Chức Vụ";
            // 
            // cbo_trinhdo
            // 
            this.cbo_trinhdo.FormattingEnabled = true;
            this.cbo_trinhdo.Location = new System.Drawing.Point(1023, 120);
            this.cbo_trinhdo.Name = "cbo_trinhdo";
            this.cbo_trinhdo.Size = new System.Drawing.Size(184, 33);
            this.cbo_trinhdo.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(473, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Căn Cước";
            // 
            // cbo_chucvu
            // 
            this.cbo_chucvu.FormattingEnabled = true;
            this.cbo_chucvu.Location = new System.Drawing.Point(1023, 67);
            this.cbo_chucvu.Name = "cbo_chucvu";
            this.cbo_chucvu.Size = new System.Drawing.Size(184, 33);
            this.cbo_chucvu.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(473, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Địa Chỉ";
            // 
            // txt_hinhanh
            // 
            this.txt_hinhanh.Location = new System.Drawing.Point(1023, 233);
            this.txt_hinhanh.Name = "txt_hinhanh";
            this.txt_hinhanh.Size = new System.Drawing.Size(184, 32);
            this.txt_hinhanh.TabIndex = 12;
            // 
            // txt_trangthai
            // 
            this.txt_trangthai.Location = new System.Drawing.Point(1023, 176);
            this.txt_trangthai.Name = "txt_trangthai";
            this.txt_trangthai.Size = new System.Drawing.Size(184, 32);
            this.txt_trangthai.TabIndex = 11;
            // 
            // txt_cancuoc
            // 
            this.txt_cancuoc.Location = new System.Drawing.Point(603, 124);
            this.txt_cancuoc.Name = "txt_cancuoc";
            this.txt_cancuoc.Size = new System.Drawing.Size(219, 32);
            this.txt_cancuoc.TabIndex = 6;
            this.txt_cancuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cancuoc_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(885, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Hình Ảnh";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(885, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Trạng Thái";
            // 
            // dgv_ns
            // 
            this.dgv_ns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgv_ns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ns.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ns.Location = new System.Drawing.Point(139, 536);
            this.dgv_ns.Name = "dgv_ns";
            this.dgv_ns.RowHeadersWidth = 51;
            this.dgv_ns.RowTemplate.Height = 24;
            this.dgv_ns.Size = new System.Drawing.Size(1522, 507);
            this.dgv_ns.TabIndex = 19;
            this.dgv_ns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ns_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btn_excel);
            this.groupBox2.Controls.Add(this.btn_moi);
            this.groupBox2.Controls.Add(this.btn_thoat);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.btn_luu);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(139, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1071, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các Chức Năng";
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::HMresourcemanagementsystem.Properties.Resources.excel;
            this.btn_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excel.Location = new System.Drawing.Point(883, 24);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(169, 63);
            this.btn_excel.TabIndex = 20;
            this.btn_excel.Text = "Xuất Excel";
            this.btn_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_moi
            // 
            this.btn_moi.Image = global::HMresourcemanagementsystem.Properties.Resources.reset_32px1;
            this.btn_moi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_moi.Location = new System.Drawing.Point(26, 31);
            this.btn_moi.Name = "btn_moi";
            this.btn_moi.Size = new System.Drawing.Size(148, 56);
            this.btn_moi.TabIndex = 13;
            this.btn_moi.Text = "Làm Mới";
            this.btn_moi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_moi.UseVisualStyleBackColor = true;
            this.btn_moi.Click += new System.EventHandler(this.btn_moi_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Image = global::HMresourcemanagementsystem.Properties.Resources.close_32px;
            this.btn_thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thoat.Location = new System.Drawing.Point(756, 24);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(98, 63);
            this.btn_thoat.TabIndex = 18;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_them
            // 
            this.btn_them.Image = global::HMresourcemanagementsystem.Properties.Resources.add_32px;
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(211, 31);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(119, 56);
            this.btn_them.TabIndex = 14;
            this.btn_them.Text = "Thêm";
            this.btn_them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::HMresourcemanagementsystem.Properties.Resources.save_32px;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(632, 24);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(90, 63);
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
            this.btn_sua.Location = new System.Drawing.Point(495, 31);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(106, 56);
            this.btn_sua.TabIndex = 16;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Image = global::HMresourcemanagementsystem.Properties.Resources.delete_32px;
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(362, 31);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 56);
            this.btn_xoa.TabIndex = 15;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btn_desearch);
            this.groupBox3.Controls.Add(this.btn_search);
            this.groupBox3.Controls.Add(this.txt_search);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1247, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm nhân viên";
            // 
            // btn_desearch
            // 
            this.btn_desearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_desearch.Image = global::HMresourcemanagementsystem.Properties.Resources.searchdelete_24px1;
            this.btn_desearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_desearch.Location = new System.Drawing.Point(300, 29);
            this.btn_desearch.Name = "btn_desearch";
            this.btn_desearch.Size = new System.Drawing.Size(92, 48);
            this.btn_desearch.TabIndex = 21;
            this.btn_desearch.Text = "Xóa";
            this.btn_desearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_desearch.UseVisualStyleBackColor = true;
            this.btn_desearch.Click += new System.EventHandler(this.btn_desearch_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Image = global::HMresourcemanagementsystem.Properties.Resources.search_24px1;
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(191, 29);
            this.btn_search.Name = "btn_search";
            this.btn_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_search.Size = new System.Drawing.Size(80, 48);
            this.btn_search.TabIndex = 20;
            this.btn_search.Text = "Tìm";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(33, 39);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(151, 30);
            this.txt_search.TabIndex = 1;
            // 
            // QuanLyNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 1055);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_ns);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyNhanSu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyNhanSu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuanLyNhanSu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ns)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.ComboBox cbo_bophan;
        private System.Windows.Forms.ComboBox cbo_phongban;
        private System.Windows.Forms.ComboBox cbo_gioitinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mask_ngsinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_cancuoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo_trinhdo;
        private System.Windows.Forms.ComboBox cbo_chucvu;
        private System.Windows.Forms.PictureBox picture_1;
        private System.Windows.Forms.TextBox txt_hinhanh;
        private System.Windows.Forms.TextBox txt_trangthai;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgv_ns;
        private System.Windows.Forms.Button btn_moi;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_desearch;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_excel;
    }
}