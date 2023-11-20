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
        public QuanLyBanHang()
        {
            InitializeComponent();
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {

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
    }
}
