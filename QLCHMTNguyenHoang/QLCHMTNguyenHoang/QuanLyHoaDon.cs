using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyHoaDon : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=m15\sqlexpress;Initial Catalog=QLCHMaytinh;Integrated Security=True");

        public QuanLyHoaDon()
        {
            InitializeComponent();
            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;          
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
            this.txtMahd.Enabled = false;
            this.txtMahh.Enabled = false;
            this.txtGia.Enabled = false;
            this.txtManv.Enabled = false;
           
            btnAnh.Enabled= false;
        }
        void moTextbox()
        {
            txtMahd.Enabled = true;
            txtMahh.Enabled = true;
            txtManv.Enabled = true;
            txtMakh.Enabled = true;
            numericUpDown1.Enabled = true;
            txtDiachi.Enabled = true;
            txtSdt.Enabled = true;            
            txtGia.Enabled = true;
        }
        void dongTextbox()
        {
            txtMahd.Enabled = false;
            txtMahh.Enabled = false;
            txtManv.Enabled = false;
            txtMakh.Enabled = false;
            numericUpDown1.Enabled = false;
            txtDiachi.Enabled = false;
            txtSdt.Enabled = false;
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
            btnAnh.Enabled = true;
        }
        private void RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            label8.Text = "Tổng số đơn hàng :" + (dataGridView1.Rows.Count ).ToString();
        }

        private void RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label8.Text = "Tổng số hoa đơn : " + (dataGridView1.Rows.Count ).ToString();
        }
        private void QuanLiHoaDon_Load(object sender, EventArgs e)
        {
           
           // this.hoadon2TableAdapter.Fill(this.abcDataSet.hoadon2);
            hienthi();
            dongTextbox();   
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {   
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
            //Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong
            //pictureBox1.Image = imageCircle;
            //Reset textBox
            txtMahd.Clear();
            txtMahh.Clear();
            txtManv.Clear();
            txtGia.Clear();
            //Mở textBox
            txtMahd.Enabled = true;
            txtMahh.Enabled = true;
            txtManv.Enabled = true;
            dateTimePicker1.Value = DateTime.Now.Date;
           
            txtGia.Enabled = true;
            moButton();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();           
            cn.Open();
            string sql = @"select * from qlhoadon where mahoadon like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnCapnhat.Visible = true;
            if (txtMahd.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mã hóa đơn !");
                txtMahd.Focus();
                return;
            }
           
            if (txtManv.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập Tên sản phẩm");
                txtManv.Focus(); return;
            }
            
            if (numericUpDown1.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng chọn số lượng");
                numericUpDown1.Focus(); return;
            }                  
           try
            {
                cn.Open();
                string sql = "insert  into qlhoadon(mahoadon,mahh,manv,makh,soluong,ngayban,diachi,sodt,giaban,hinhanh)  values(@mahoadon,@mahh,@manv,@makh,@soluong,@ngayban,@diachi,@sodt,@giaban,@hinhanh)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@mahoadon", txtMahd.Text);
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@manv", txtManv.Text);
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@soluong", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@ngayban", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@sodt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@giaban", txtGia.Text);              
               // cmd.Parameters.AddWithValue("@tinhtrang", comboBox1.Text);
                pictureBox1.Image.Save(str, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("@hinhanh", str.ToArray());
               
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                btnLuu.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            catch (Exception)
            {
              
                MessageBox.Show(" Đã có Hóa đơn mang tên : " + txtMahd.Text + ". Vui lòng chọn tên khác ", "THÔNG BÁO ");
            }

        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update qlhoadon set  mahoadon=@mahoadon,mahh=@mahh,manv=@manv,makh=@makh,soluong=@soluong,ngayban=@ngayban,diachi=@diachi,sodt=@sodt,giaban=@giaban,hinhanh=@hinhanh where mahoadon=@mahoadon";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@mahoadon", txtMahd.Text);
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@manv", txtManv.Text);
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@soluong", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@ngayban", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@sodt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@giaban", txtGia.Text);
                //  cmd.Parameters.AddWithValue("@tinhtrang", g);
                pictureBox1.Image.Save(str, pictureBox1.Image.RawFormat);
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
       
        private void btnXoa_Click(object sender, EventArgs e)
        {
           
                string sql = "delete from qlhoadon where mahoadon=@mahoadon";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@mahoadon", txtMahd.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                pictureBox1.Image=null;
                dongTextbox();


            //else if (dialogResult == DialogResult.No)
            //{
            //    cn.Close();
            //}
            Image imageCircle = Image.FromFile("Anh\\empty1.jpg");
            //Dat hinh mat dinh khi khoi dong
            pictureBox1.Image = imageCircle;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextbox();
            moButton();
            btnLuu.Enabled = false;
            btnAnh.Enabled = true;
            btnSua.Enabled = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTrove_Click_1(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                numericUpDown1.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDiachi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtSdt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtGia.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
               
               
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value);
                pictureBox1.Image = Image.FromStream(ms);              
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }
        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn ảnh";
            op.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            if(op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = op.FileName;
            }    
        }         
        void Xoa_TextBox()
        {
            txtMahd.Clear();
            txtMahh.Clear();
            txtManv.Clear();
            txtGia.Clear();
            dateTimePicker1.Value = DateTime.Now.Date;
          
           // Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong
           // pictureBox1.Image = imageCircle;
        }
        private void button2_Click(object sender, EventArgs e)
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
            btnAnh.Enabled = false;
            dongTextbox();
            Xoa_TextBox();
        }      
    }
}