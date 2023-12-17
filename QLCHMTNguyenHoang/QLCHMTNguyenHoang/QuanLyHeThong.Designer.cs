namespace QLCHMTNguyenHoang
{
    partial class QuanLyHeThong
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTendangnhap = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMatkhau = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonThem = new System.Windows.Forms.Button();
            this.ButtonSua = new System.Windows.Forms.Button();
            this.ButtonXoa = new System.Windows.Forms.Button();
            this.ButtonTrove = new System.Windows.Forms.Button();
            this.ButtonThoat = new System.Windows.Forms.Button();
            this.ButtonLuu = new System.Windows.Forms.Button();
            this.ButtonCapnhat = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonTimkiem = new System.Windows.Forms.Button();
            this.textBoxTimkiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(8, 78);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(124, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tên đăng nhập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Quyền";
            // 
            // textBoxTendangnhap
            // 
            this.textBoxTendangnhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTendangnhap.Location = new System.Drawing.Point(138, 75);
            this.textBoxTendangnhap.Name = "textBoxTendangnhap";
            this.textBoxTendangnhap.Size = new System.Drawing.Size(203, 30);
            this.textBoxTendangnhap.TabIndex = 12;
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(138, 143);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(203, 30);
            this.comboBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(12, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mật khẩu";
            // 
            // textBoxMatkhau
            // 
            this.textBoxMatkhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxMatkhau.Location = new System.Drawing.Point(138, 108);
            this.textBoxMatkhau.Name = "textBoxMatkhau";
            this.textBoxMatkhau.Size = new System.Drawing.Size(203, 30);
            this.textBoxMatkhau.TabIndex = 15;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 311);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(560, 174);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // ButtonThem
            // 
            this.ButtonThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonThem.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_add_40;
            this.ButtonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonThem.Location = new System.Drawing.Point(12, 187);
            this.ButtonThem.Name = "ButtonThem";
            this.ButtonThem.Size = new System.Drawing.Size(124, 49);
            this.ButtonThem.TabIndex = 28;
            this.ButtonThem.Text = "Thêm  ";
            this.ButtonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonThem.UseVisualStyleBackColor = true;
            this.ButtonThem.Click += new System.EventHandler(this.ButtonThem_Click);
            // 
            // ButtonSua
            // 
            this.ButtonSua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSua.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_pencil_drawing_40;
            this.ButtonSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonSua.Location = new System.Drawing.Point(142, 187);
            this.ButtonSua.Name = "ButtonSua";
            this.ButtonSua.Size = new System.Drawing.Size(147, 49);
            this.ButtonSua.TabIndex = 29;
            this.ButtonSua.Text = "Sửa    ";
            this.ButtonSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonSua.UseVisualStyleBackColor = true;
            this.ButtonSua.Click += new System.EventHandler(this.ButtonSua_Click);
            // 
            // ButtonXoa
            // 
            this.ButtonXoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonXoa.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_delete_40;
            this.ButtonXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonXoa.Location = new System.Drawing.Point(295, 187);
            this.ButtonXoa.Name = "ButtonXoa";
            this.ButtonXoa.Size = new System.Drawing.Size(147, 49);
            this.ButtonXoa.TabIndex = 30;
            this.ButtonXoa.Text = "Xóa    ";
            this.ButtonXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonXoa.UseVisualStyleBackColor = true;
            this.ButtonXoa.Click += new System.EventHandler(this.ButtonXoa_Click);
            // 
            // ButtonTrove
            // 
            this.ButtonTrove.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTrove.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_previous_32;
            this.ButtonTrove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonTrove.Location = new System.Drawing.Point(448, 187);
            this.ButtonTrove.Name = "ButtonTrove";
            this.ButtonTrove.Size = new System.Drawing.Size(124, 49);
            this.ButtonTrove.TabIndex = 32;
            this.ButtonTrove.Text = "Trở về";
            this.ButtonTrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonTrove.UseVisualStyleBackColor = true;
            this.ButtonTrove.Click += new System.EventHandler(this.ButtonTrove_Click);
            // 
            // ButtonThoat
            // 
            this.ButtonThoat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonThoat.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_close_window_32;
            this.ButtonThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonThoat.Location = new System.Drawing.Point(448, 242);
            this.ButtonThoat.Name = "ButtonThoat";
            this.ButtonThoat.Size = new System.Drawing.Size(124, 47);
            this.ButtonThoat.TabIndex = 33;
            this.ButtonThoat.Text = "Thoát  ";
            this.ButtonThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonThoat.UseVisualStyleBackColor = true;
            this.ButtonThoat.Click += new System.EventHandler(this.ButtonThoat_Click);
            // 
            // ButtonLuu
            // 
            this.ButtonLuu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLuu.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_save_32;
            this.ButtonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonLuu.Location = new System.Drawing.Point(12, 242);
            this.ButtonLuu.Name = "ButtonLuu";
            this.ButtonLuu.Size = new System.Drawing.Size(124, 47);
            this.ButtonLuu.TabIndex = 63;
            this.ButtonLuu.Text = "Lưu    ";
            this.ButtonLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonLuu.UseVisualStyleBackColor = true;
            this.ButtonLuu.Click += new System.EventHandler(this.ButtonLuu_Click);
            // 
            // ButtonCapnhat
            // 
            this.ButtonCapnhat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCapnhat.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_sync_40;
            this.ButtonCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCapnhat.Location = new System.Drawing.Point(142, 242);
            this.ButtonCapnhat.Name = "ButtonCapnhat";
            this.ButtonCapnhat.Size = new System.Drawing.Size(147, 47);
            this.ButtonCapnhat.TabIndex = 64;
            this.ButtonCapnhat.Text = "Cập nhật";
            this.ButtonCapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonCapnhat.UseVisualStyleBackColor = true;
            this.ButtonCapnhat.Click += new System.EventHandler(this.ButtonCapnhat_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonReset.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_reset_32;
            this.ButtonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonReset.Location = new System.Drawing.Point(295, 241);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(147, 47);
            this.ButtonReset.TabIndex = 70;
            this.ButtonReset.Text = "Reset    ";
            this.ButtonReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonTimkiem);
            this.groupBox1.Controls.Add(this.textBoxTimkiem);
            this.groupBox1.Location = new System.Drawing.Point(372, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // ButtonTimkiem
            // 
            this.ButtonTimkiem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonTimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonTimkiem.Image = global::QLCHMTNguyenHoang.Properties.Resources.icons8_search_20;
            this.ButtonTimkiem.Location = new System.Drawing.Point(68, 61);
            this.ButtonTimkiem.Name = "ButtonTimkiem";
            this.ButtonTimkiem.Size = new System.Drawing.Size(69, 32);
            this.ButtonTimkiem.TabIndex = 36;
            this.ButtonTimkiem.UseVisualStyleBackColor = false;
            this.ButtonTimkiem.Click += new System.EventHandler(this.ButtonTimkiem_Click);
            // 
            // textBoxTimkiem
            // 
            this.textBoxTimkiem.Location = new System.Drawing.Point(6, 33);
            this.textBoxTimkiem.Name = "textBoxTimkiem";
            this.textBoxTimkiem.Size = new System.Drawing.Size(188, 22);
            this.textBoxTimkiem.TabIndex = 0;
            // 
            // QuanLyHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonCapnhat);
            this.Controls.Add(this.ButtonLuu);
            this.Controls.Add(this.ButtonThoat);
            this.Controls.Add(this.ButtonTrove);
            this.Controls.Add(this.ButtonXoa);
            this.Controls.Add(this.ButtonSua);
            this.Controls.Add(this.ButtonThem);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBoxMatkhau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.textBoxTendangnhap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "QuanLyHeThong";
            this.Text = "Quản Lý Hệ Thống";
            this.Load += new System.EventHandler(this.QuanLyHeThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTendangnhap;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMatkhau;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonThem;
        private System.Windows.Forms.Button ButtonSua;
        private System.Windows.Forms.Button ButtonXoa;
        private System.Windows.Forms.Button ButtonTrove;
        private System.Windows.Forms.Button ButtonThoat;
        private System.Windows.Forms.Button ButtonLuu;
        private System.Windows.Forms.Button ButtonCapnhat;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTimkiem;
        private System.Windows.Forms.Button ButtonTimkiem;
    }
}