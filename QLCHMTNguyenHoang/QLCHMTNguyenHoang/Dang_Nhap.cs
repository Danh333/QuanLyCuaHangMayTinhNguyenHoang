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

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

       // SqlConnection cn;
       // string MachineName = Environment.MachineName;

        public DangNhap()
        {
            InitializeComponent();
            cn.ConnectionString = Properties.Settings.Default.ChuoiKetNoiDangNhap;
            cn.Open();
            cmd.Connection = cn;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

          //  cn = new SqlConnection("Data Source="+ MachineName +@";Initial Catalog=QLtaikhoan;Integrated Security=True");

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
            string sql = "select username,password,quyen from nguoidung1 where username = '" + userName + "'  and password  = '" + passWord + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                // MessageBox.Show("Đăng nhập thành công ","Thông báo");
                QuanLyBanHang fmain = new QuanLyBanHang(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công . Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {


         

        }

        private void DangNhap_Load_1(object sender, EventArgs e)
        {

        }
    }
}
