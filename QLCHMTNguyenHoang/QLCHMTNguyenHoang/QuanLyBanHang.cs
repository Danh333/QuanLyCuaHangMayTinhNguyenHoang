using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyBanHang : Form
    {
     
        private string tdn="";
        private string mk="";
        private string quyen="";
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public QuanLyBanHang()
        {
            InitializeComponent();
            
            cn.ConnectionString = Properties.Settings.Default.ChuoiKetNoiDangNhap;
            cn.Open();
            cmd.Connection = cn;
        }

        public QuanLyBanHang(string tdn, string mk, string quyen)
        {
            InitializeComponent();
           
            this.tdn = tdn;
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
            KiemTraQuyenNguoiDung();
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
        
        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
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
            KiemTraQuyenNguoiDung();
        }
        private void KiemTraQuyenNguoiDung()
        {

            
            if (quyen == "1")
            {


                labelTenNguoidung.Text = "Xin chào User:";
                btnQLNhanVien.Hide();
                btnQLHeThong.Hide();
                
            }
            else
            {
                labelTenNguoidung.Text = "Xin chào Admin";
            }


        }
        private void QuanLyBanHang_Activated(object sender, EventArgs e)
        {
            CheckUserPermission();
        }
        private void CheckUserPermission()
        {
            //// Xác định quyền của người dùng khi đăng nhập
            //string userRole = GetUserRole(loggedInUsername); // Thay thế bằng hàm xác định vai trò từ CSDL

            //// Kiểm tra quyền của người dùng
            //if (userRole != "User") // Thay "User" bằng vai trò cần kiểm tra
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập vào Form này.", "Lỗi quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close(); // Đóng Form nếu không có quyền
            //}
            //// Tiếp tục hiển thị Form nếu có quyền
        }
    }
    }
