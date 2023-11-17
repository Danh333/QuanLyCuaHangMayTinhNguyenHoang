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
    public partial class QuanLiBanHang : Form
    {
        public QuanLiBanHang()
        {
            InitializeComponent();
        }

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {

        }

        private void QLnhanvien_Click(object sender, EventArgs e)
        {
            QuanLiNhanVien fNhanvien = new QuanLiNhanVien();
            fNhanvien.Show();
            this.Hide();
        }

        private void QLkhachhang_Click(object sender, EventArgs e)
        {
            QuanLiKhachHang fKhachhang = new QuanLiKhachHang();
            fKhachhang.Show();
            this.Hide();
        }

        private void QLhoadon_Click(object sender, EventArgs e)
        {
            QuanLiHoaDon fHoadon = new QuanLiHoaDon();
            fHoadon.Show();
            this.Hide();
        }

        private void QLkhohang_Click(object sender, EventArgs e)
        {
            QuanLiKhoHang fKhohang = new QuanLiKhoHang();
            fKhohang.Show();
            this.Hide();
        }

        private void QLhanghoa_Click(object sender, EventArgs e)
        {
            QuanLiHangHoa fHanghoa = new QuanLiHangHoa();
            fHanghoa.Show();
            this.Hide();
        }

        private void QLhethong_Click(object sender, EventArgs e)
        {
            QuanLiHeThong fHethong = new QuanLiHeThong();
            fHethong.Show();
            this.Hide();
        }
    }
}
