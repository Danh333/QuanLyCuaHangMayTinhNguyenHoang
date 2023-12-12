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
        public object ConfigurationManager { get; private set; }

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
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();

                    // Chuẩn bị câu lệnh SQL để xóa thông tin hàng hóa từ cơ sở dữ liệu
                    string query = "DELETE FROM TenBang WHERE MaHangHoa = @MaHangHoa";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền Mã hàng hóa từ trường nhập liệu vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@MaHangHoa", txtMahh.Text);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã xóa thông tin hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hàng hóa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
           

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();

                    // Chuẩn bị câu lệnh SQL để cập nhật thông tin hàng hóa trong cơ sở dữ liệu
                    string query = "UPDATE TenBang SET TenHangHoa = @TenHangHoa, Gia = @Gia, NgayNhap = @NgayNhap, NgayXuat = @NgayXuat WHERE MaHangHoa = @MaHangHoa";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền các giá trị mới từ các trường nhập liệu vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@MaHangHoa", txtMahh.Text);
                    cmd.Parameters.AddWithValue("@TenHangHoa", txtTenHangHoa.Text);
                    cmd.Parameters.AddWithValue("@Gia", Convert.ToDecimal(txtGia.Text));
                    cmd.Parameters.AddWithValue("@NgayNhapXuat", dateTimePicker1.Value);
                    

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã cập nhật thông tin hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hàng hóa cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Xóa hoặc đặt lại thông tin trên giao diện người dùng về giá trị mặc định
            txtMahh.Text = ""; 
            txtTenHangHoa.Text = ""; 
            txtGia.Text = ""; 
            dateTimePicker1.Value = DateTime.Now; 
            
        }
    }
}
