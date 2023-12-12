using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyHangHoa : Form
    {
        public QuanLyHangHoa()
        {
            InitializeComponent();
        }

        private void QuanLiHangHoa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string tenHangHoa = txtTenHangHoa.Text;
            string maHangHoa = txtMahh.Text;
            decimal gia = Convert.ToDecimal(txtGia.Text);

            // TODO: Thêm thông tin hàng hóa vào cơ sở dữ liệu hoặc danh sách hàng hóa

            // Ví dụ: Hiển thị thông tin hàng hóa đã thêm vào MessageBox
            string thongTinHangHoa = $"Mã hàng hóa: {maHangHoa} \nTên hàng hóa: {tenHangHoa}\nGiá: {gia:C}";
            MessageBox.Show($"Đã thêm hàng hóa mới:\n{thongTinHangHoa}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Sau khi thêm, có thể làm sạch các trường nhập liệu
            txtMahh.Text = "";
            txtTenHangHoa.Text = "";
            txtGia.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (HangHoa hangHoa in danhSachHangHoa)
                    {
                        string query = "INSERT INTO TenBang (MaHangHoa, TenHangHoa, Gia, NgayNhap, NgayXuat) VALUES (@MaHangHoa, @TenHangHoa, @Gia, @NgayNhap, @NgayXuat)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaHangHoa", hangHoa.MaHangHoa);
                        cmd.Parameters.AddWithValue("@TenHangHoa", hangHoa.TenHangHoa);
                        cmd.Parameters.AddWithValue("@Gia", hangHoa.Gia);
                        cmd.Parameters.AddWithValue("@NgayNhap", hangHoa.NgayNhap);
                        cmd.Parameters.AddWithValue("@NgayXuat", hangHoa.NgayXuat);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã lưu thông tin hàng hóa vào cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
