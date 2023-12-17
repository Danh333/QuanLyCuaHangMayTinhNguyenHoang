using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyBanHang : Form
    {
        string tendn = "", mk = "", quyen = "";
        public QuanLyBanHang()
        {
            InitializeComponent();
        }

        public QuanLyBanHang(string tendn, string mk, string quyen)
        {
            InitializeComponent();
            this.tendn = tendn;
            this.mk = mk;
            this.quyen = quyen;
        }

        private void QLnhanvien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien fNhanvien = new QuanLyNhanVien();
            fNhanvien.Show();
            this.Hide();
        }

        private void QLkhachhang_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang fKhachhang = new QuanLyKhachHang();
            fKhachhang.Show();
            this.Hide();
        }

        private void QLhoadon_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon fHoadon = new QuanLyHoaDon();
            fHoadon.Show();
            this.Hide();
        }

        private void QLkhohang_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang fKhohang = new QuanLyKhoHang();
            fKhohang.Show();
            this.Hide();
        }

        private void QLhanghoa_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa fHanghoa = new QuanLyHangHoa();
            fHanghoa.Show();
            this.Hide();
        }

        private void QLhethong_Click(object sender, EventArgs e)
        {
            QuanLyHeThong fHethong = new QuanLyHeThong();
            fHethong.Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien f = new QuanLyNhanVien();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang f = new QuanLyKhachHang();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang f = new QuanLyKhoHang();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon f = new QuanLyHoaDon();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa f = new QuanLyHangHoa();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QuanLyHeThong f = new QuanLyHeThong();
            f.Show();
            this.Hide();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon f = new QuanLyHoaDon();
            f.Show();
            this.Hide();
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            if (quyen == "1")
            {
                btnQLHeTHong.Hide();
                btnQLNhanVien.Hide();
            }
        }
    }
    }
