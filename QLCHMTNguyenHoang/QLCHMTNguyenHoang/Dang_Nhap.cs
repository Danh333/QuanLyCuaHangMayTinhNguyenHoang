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
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=WHOANHMINH\SQLEXPRESS;Initial Catalog=abc;Integrated Security=True");
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
            sqlcon.Open();
            string sql = "select username,password from nguoidung1 where username = '" + userName + "'  and password  = '" + passWord + "'";

            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader dt = cmd.ExecuteReader();


            if (dt.Read())
            {
                // MessageBox.Show("Đăng nhập thành công ","Thông báo");
               QuanLiBanHang  fmain = new QuanLiBanHang();
                fmain.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công . Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo");

            }
            sqlcon.Close();

        }
    }
}
