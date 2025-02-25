namespace HMresourcemanagementsystem
{
    partial class KetQuaDanhGia
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
            this.dgv_ketquadg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_desearch = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btt_xuatban = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ketquadg)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ketquadg
            // 
            this.dgv_ketquadg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_ketquadg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ketquadg.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ketquadg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ketquadg.Location = new System.Drawing.Point(79, 307);
            this.dgv_ketquadg.Name = "dgv_ketquadg";
            this.dgv_ketquadg.RowHeadersWidth = 51;
            this.dgv_ketquadg.RowTemplate.Height = 24;
            this.dgv_ketquadg.Size = new System.Drawing.Size(1397, 500);
            this.dgv_ketquadg.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(641, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 53);
            this.label1.TabIndex = 28;
            this.label1.Text = "KẾT QUẢ ĐÁNH GIÁ";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btn_desearch);
            this.groupBox3.Controls.Add(this.btn_search);
            this.groupBox3.Controls.Add(this.txt_search);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(174, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(628, 134);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm tên kế hoạch đánh giá";
            // 
            // btn_desearch
            // 
            this.btn_desearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_desearch.Image = global::HMresourcemanagementsystem.Properties.Resources.searchdelete_24px1;
            this.btn_desearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_desearch.Location = new System.Drawing.Point(474, 45);
            this.btn_desearch.Name = "btn_desearch";
            this.btn_desearch.Size = new System.Drawing.Size(112, 48);
            this.btn_desearch.TabIndex = 21;
            this.btn_desearch.Text = "Xóa";
            this.btn_desearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_desearch.UseVisualStyleBackColor = true;
            this.btn_desearch.Click += new System.EventHandler(this.btn_desearch_Click_1);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Image = global::HMresourcemanagementsystem.Properties.Resources.search_24px1;
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(320, 45);
            this.btn_search.Name = "btn_search";
            this.btn_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_search.Size = new System.Drawing.Size(106, 48);
            this.btn_search.TabIndex = 20;
            this.btn_search.Text = "Tìm";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click_1);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(27, 55);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(226, 30);
            this.txt_search.TabIndex = 1;
            // 
            // btt_xuatban
            // 
            this.btt_xuatban.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btt_xuatban.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_xuatban.Image = global::HMresourcemanagementsystem.Properties.Resources.excel;
            this.btt_xuatban.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_xuatban.Location = new System.Drawing.Point(865, 189);
            this.btt_xuatban.Name = "btt_xuatban";
            this.btt_xuatban.Size = new System.Drawing.Size(191, 74);
            this.btt_xuatban.TabIndex = 30;
            this.btt_xuatban.Text = "Xuất bản";
            this.btt_xuatban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_xuatban.UseVisualStyleBackColor = true;
            this.btt_xuatban.Click += new System.EventHandler(this.btt_xuatban_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Image = global::HMresourcemanagementsystem.Properties.Resources.close_32px;
            this.btn_thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thoat.Location = new System.Drawing.Point(1395, 199);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(137, 74);
            this.btn_thoat.TabIndex = 31;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // KetQuaDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1553, 819);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btt_xuatban);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_ketquadg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KetQuaDanhGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KetQuaDanhGia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KetQuaDanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ketquadg)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ketquadg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_desearch;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btt_xuatban;
        private System.Windows.Forms.Button btn_thoat;
    }
}