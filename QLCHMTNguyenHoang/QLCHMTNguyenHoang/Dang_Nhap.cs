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
    public partial class DangNhap : Form
    {
        SqlConnection cn;
        string MachineName = Environment.MachineName;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source="+ MachineName +@";Initial Catalog=QLtaikhoan;Integrated Security=True");
            string userName = txtTenDangNhap.Text;
            string passWord = txtMatKhau.Text;
            if (userName == null || userName.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!!", "Thông báo");
                return;
            }
            if (passWord == null || passWord.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!!", "Thông báo");
                return;
            }
            cn.Open();
            string sql = "select username,password from nguoidung where username = '" + userName + "'  and password  = '" + passWord + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dt = cmd.ExecuteReader();


            if (dt.Read())
            {
                // MessageBox.Show("Đăng nhập thành công ","Thông báo");
                QuanLyBanHang  fmain = new QuanLyBanHang();
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công . Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo");

            }
            cn.Close();
        }
    }
}
