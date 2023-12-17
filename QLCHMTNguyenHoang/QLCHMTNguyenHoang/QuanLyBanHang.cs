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

        private void QLnhanvien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nv = new QuanLyNhanVien();
            nv.Show();
            this.Hide();
        }

        private void QLkhachhang_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang kh = new QuanLyKhachHang();
            kh.Show();
            this.Hide();
        }

        private void QLhoadon_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hd = new QuanLyHoaDon();
            hd.Show();
            this.Hide();
        }

        private void QLkhohang_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang kho = new QuanLyKhoHang();
            kho.Show();
            this.Hide();
        }

        private void QLhanghoa_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa hh = new QuanLyHangHoa();
            hh.Show();
            this.Hide();
        }

        private void QLhethong_Click(object sender, EventArgs e)
        {
            QuanLyHeThong ht = new QuanLyHeThong();
            ht.Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nv = new QuanLyNhanVien();
            nv.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang kh = new QuanLyKhachHang();
            kh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang kho = new QuanLyKhoHang();
            kho.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hd = new QuanLyHoaDon();
            hd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa hh = new QuanLyHangHoa();
            hh.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QuanLyHeThong ht = new QuanLyHeThong();
            ht.Show();
            this.Hide();
        }

        private void QLNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nv = new QuanLyNhanVien();
            nv.Show();
            this.Hide();
        }

        private void QLKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang kh = new QuanLyKhachHang();
            kh.Show();
            this.Hide();
        }

        private void QLKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang kho = new QuanLyKhoHang();
            kho.Show();
            this.Hide();
        }

        private void QLHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hd = new QuanLyHoaDon();
            hd.Show();
            this.Hide();
        }

        private void QLHHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa hh = new QuanLyHangHoa();
            hh.Show();
            this.Hide();
        }

        private void QLHTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHeThong ht = new QuanLyHeThong();
            ht.Show();
            this.Hide();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
    }
}
