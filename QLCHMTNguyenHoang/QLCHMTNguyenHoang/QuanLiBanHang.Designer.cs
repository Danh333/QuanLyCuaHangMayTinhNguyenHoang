namespace QLCHMTNguyenHoang
{
    partial class QuanLiBanHang
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
            this.QLnhanvien = new System.Windows.Forms.Button();
            this.QLhethong = new System.Windows.Forms.Button();
            this.QLkhohang = new System.Windows.Forms.Button();
            this.QLkhachhang = new System.Windows.Forms.Button();
            this.QLhanghoa = new System.Windows.Forms.Button();
            this.QLhoadon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QLnhanvien
            // 
            this.QLnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLnhanvien.Location = new System.Drawing.Point(47, 34);
            this.QLnhanvien.Name = "QLnhanvien";
            this.QLnhanvien.Size = new System.Drawing.Size(209, 59);
            this.QLnhanvien.TabIndex = 0;
            this.QLnhanvien.Text = "Quản lí nhân viên";
            this.QLnhanvien.UseVisualStyleBackColor = true;
            this.QLnhanvien.Click += new System.EventHandler(this.QLnhanvien_Click);
            // 
            // QLhethong
            // 
            this.QLhethong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLhethong.Location = new System.Drawing.Point(47, 136);
            this.QLhethong.Name = "QLhethong";
            this.QLhethong.Size = new System.Drawing.Size(209, 59);
            this.QLhethong.TabIndex = 1;
            this.QLhethong.Text = "Quản lí hệ thống";
            this.QLhethong.UseVisualStyleBackColor = true;
            // 
            // QLkhohang
            // 
            this.QLkhohang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLkhohang.Location = new System.Drawing.Point(299, 136);
            this.QLkhohang.Name = "QLkhohang";
            this.QLkhohang.Size = new System.Drawing.Size(209, 59);
            this.QLkhohang.TabIndex = 3;
            this.QLkhohang.Text = "Quản lí kho hàng";
            this.QLkhohang.UseVisualStyleBackColor = true;
            // 
            // QLkhachhang
            // 
            this.QLkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLkhachhang.Location = new System.Drawing.Point(299, 34);
            this.QLkhachhang.Name = "QLkhachhang";
            this.QLkhachhang.Size = new System.Drawing.Size(209, 59);
            this.QLkhachhang.TabIndex = 2;
            this.QLkhachhang.Text = "Quản lí khách hàng";
            this.QLkhachhang.UseVisualStyleBackColor = true;
            // 
            // QLhanghoa
            // 
            this.QLhanghoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLhanghoa.Location = new System.Drawing.Point(555, 136);
            this.QLhanghoa.Name = "QLhanghoa";
            this.QLhanghoa.Size = new System.Drawing.Size(209, 59);
            this.QLhanghoa.TabIndex = 5;
            this.QLhanghoa.Text = "Quản lí hàng hóa";
            this.QLhanghoa.UseVisualStyleBackColor = true;
            // 
            // QLhoadon
            // 
            this.QLhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLhoadon.Location = new System.Drawing.Point(555, 34);
            this.QLhoadon.Name = "QLhoadon";
            this.QLhoadon.Size = new System.Drawing.Size(209, 59);
            this.QLhoadon.TabIndex = 4;
            this.QLhoadon.Text = "Quản lí hóa đơn";
            this.QLhoadon.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "QUẢN LÍ BÁN HÀNG ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(271, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(567, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "CỬA HÀNG MÁY TÍNH NGUYỄN HOÀNG";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.QLhanghoa);
            this.groupBox1.Controls.Add(this.QLnhanvien);
            this.groupBox1.Controls.Add(this.QLhethong);
            this.groupBox1.Controls.Add(this.QLkhachhang);
            this.groupBox1.Controls.Add(this.QLhoadon);
            this.groupBox1.Controls.Add(this.QLkhohang);
            this.groupBox1.Location = new System.Drawing.Point(138, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 226);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // QuanLiBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLiBanHang";
            this.Text = "Quản Lí Bán Hàng";
            this.Load += new System.EventHandler(this.QuanLiBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QLnhanvien;
        private System.Windows.Forms.Button QLhethong;
        private System.Windows.Forms.Button QLkhohang;
        private System.Windows.Forms.Button QLkhachhang;
        private System.Windows.Forms.Button QLhanghoa;
        private System.Windows.Forms.Button QLhoadon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}