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
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
            //Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong
            //pictureBox1.Image = imageCircle;
            //Reset textBox
            
            txtMahh.Clear();
           
            txtGia.Clear();
            //Mở textBox
            
            txtMahh.Enabled = true;
            
            dateTimePicker1.Value = DateTime.Now.Date;

            txtGia.Enabled = true;
            moButton();
        }
        void moTextbox()
        {
           
            txtMahh.Enabled = true;
           
            txtGia.Enabled = true;
        }
        void dongTextbox()
        {
           
            txtMahh.Enabled = false;
          
          
           
         
            
            txtGia.Enabled = false;
        }
        void dongButton()
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
        }
        void moButton()
        {
            btnLuu.Enabled = true;
            btnCapnhat.Enabled = true;
          
        }
        void hienthi()
        {
            cn = new SqlConnection(@"Data Source=m15\sqlexpress;Initial Catalog=QLCHMaytinh;Integrated Security=True");
            string sql = "select * from qlhoadon";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[6];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            getsizecolums();
            //dataGridView1.Columns
            
            this.txtMahh.Enabled = false;
            this.txtGia.Enabled = false;
            
        }
        public void getsizecolums()
        {
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 250;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 250;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnCapnhat.Visible = true;
           

            

            
            try
            {
                cn.Open();
                string sql = "insert  into qlhoadon(mahoadon,mahh,manv,makh,soluong,ngayban,diachi,sodt,giaban,hinhanh)  values(@mahoadon,@mahh,@manv,@makh,@soluong,@ngayban,@diachi,@sodt,@giaban,@hinhanh)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
              
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
               
               
                cmd.Parameters.AddWithValue("@ngayban", dateTimePicker1.Value.ToString());
              
              
                cmd.Parameters.AddWithValue("@giaban", txtGia.Text);
                // cmd.Parameters.AddWithValue("@tinhtrang", comboBox1.Text);
                pictureBox.Image.Save(str, pictureBox.Image.RawFormat);
                cmd.Parameters.AddWithValue("@hinhanh", str.ToArray());

                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                btnLuu.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            catch (Exception)
            {

                MessageBox.Show(" Đã có Hàng hóa mang tên : " + txtMahh.Text + ". Vui lòng chọn tên khác ", "THÔNG BÁO ");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextbox();
            moButton();
            btnLuu.Enabled = false;
            
            btnSua.Enabled = false;
        }
            

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from qlhoadon where mahoadon=@mahoadon";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@mahanghoa", txtMahh.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            pictureBox.Image = null;
            dongTextbox();


            //else if (dialogResult == DialogResult.No)
            //{
            //    cn.Close();
            //}
            Image imageCircle = Image.FromFile("Anh\\empty1.jpg");
            //Dat hinh mat dinh khi khoi dong
            pictureBox.Image = imageCircle;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update qlhoadon set  mahoadon=@mahoadon,mahh=@mahh,manv=@manv,makh=@makh,soluong=@soluong,ngayban=@ngayban,diachi=@diachi,sodt=@sodt,giaban=@giaban,hinhanh=@hinhanh where mahoadon=@mahoadon";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                
                
                
                cmd.Parameters.AddWithValue("@ngayban", dateTimePicker1.Value.ToString());
               
                
                cmd.Parameters.AddWithValue("@giaban", txtGia.Text);
                //  cmd.Parameters.AddWithValue("@tinhtrang", g);
                pictureBox.Image.Save(str, pictureBox.Image.RawFormat);
                cmd.Parameters.AddWithValue("@anh", str.ToArray());
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi cập nhật");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //mở
            dataGridView1.Enabled = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnCapnhat.Visible = true;
            //đóng
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnCapnhat.Enabled = false;
            
            

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from qlhoadon where mahd like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();
        }
        void dongbtn_clickdatagridview_()
        {
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;

            try
            {
                txtMahd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtMahh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtManv.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtMakh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDiachi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtSdt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtGia.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value);
                pictureBox.Image = Image.FromStream(ms);
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số          
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
