﻿using System;
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
        SqlConnection cn;
        string MachineName = Environment.MachineName;

        public QuanLyHoaDon()
        {
            InitializeComponent();
            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;          
        }
       
        void hienthi()
        {
            cn = new SqlConnection("Data Source="+ MachineName +@";Initial Catalog=QLCHMTNguyenHoang;Integrated Security=True");
            string sql = "select * from hoadon";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;         
            getsizecolums();
            //dataGridView1.Columns
            dongTextbox();
            LoadComboBox();
           
        }
        void moTextbox()
        {
            comboBox1.Enabled = true;
            txtMaHoaDon.Enabled = true;
            txtMaKhachHang.Enabled = true;
           // txtMaNhanVien.Enabled = true;
            dateTimePicker1.Enabled = true;
            numericUpDown1.Enabled = true;
        }
        void dongTextbox()
        {
            comboBox1.Enabled = false;
            txtMaHoaDon.Enabled = false;          
            txtMaKhachHang.Enabled = false;
           // txtMaNhanVien.Enabled = false;
            dateTimePicker1.Enabled = true;
            numericUpDown1.Enabled = false;
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
           
         
            hienthi();
            dongTextbox();   
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {   
            //đóng datagview và tắt button
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
            //Dat hinh mat dinh khi khoi dong


            //Reset textBox
            Xoa_TextBox();

            //Mở textBox
            moTextbox();
            //txtMaHoaDon.Enabled = true;  
            //txtMaKhachHang.Enabled = true;    
            //dateTimePicker1.Value = DateTime.Now.Date;          
            //txtTongTien.Enabled = true;
            //txtMaNhanVien.Enabled = true;
            moButton();//mở button
        }
        public void getsizecolums()  //đặt chiều rộng cố định cho cột
        {
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100; 
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();           
            cn.Open();
            string sql = @"select * from hoadon where mahoadon like '%" + txttimkiem.Text + "%' or makh like N'%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();           
        }
        void dongbtn_clickdatagridview_()  //tắt btn và datagview
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
            if (txtMaHoaDon.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mã hóa đơn !");
                txtMaHoaDon.Focus();
                return;
            }
           
            if (txtMaKhachHang.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập Tên sản phẩm");
                txtMaKhachHang.Focus(); return;
            }
            
                   
          // try
            {
                cn.Open();
               
                string sql = "insert into hoadon (MaHoaDon,MaKH,MaNV,NgayLap,Soluong) values (@MaHoaDon,@MaKH,@MaNV,@NgayLap,@Soluong)";
                SqlCommand   cmd = new SqlCommand(sql,cn);
                //MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@MaNV", comboBox1.Text);          
                cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value.ToString());        
                cmd.Parameters.AddWithValue("@Soluong", numericUpDown1.Value.ToString());                           
                //pictureBox1.Image.Save     (str        , pictureBox1.Image.RawFormat);
                //cmd.Parameters.AddWithValue("@hinhanh" , str.ToArray());               
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi() ;
                btnLuu.Enabled     = false;
                btnCapnhat.Enabled = false;
            }
            //catch (Exception)
            //{
              
            //    MessageBox.Show(" Đã có Hóa đơn mang tên : " + txtMahd.Text + ". Vui lòng chọn tên khác ", "THÔNG BÁO ");
            //}

        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            moButton();
            try
            {
                cn.Open();
                string sql = "update hoadon set  MaHoaDon=@MaHoaDon,MaKh=@MaKh,MaNV=@MaNv,NgayLap=@NgayLap,Soluong=@Soluong where mahoadon=@mahoadon";
                SqlCommand cmd = new SqlCommand(sql, cn);
                //MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@MaNV", comboBox1.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@Soluong", numericUpDown1.Value.ToString());
                //pictureBox1.Image.Save     (    str      , pictureBox1.Image.RawFormat);
                //cmd.Parameters.AddWithValue("@anh"       , str.ToArray());
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
           
                string sql = "delete from hoadon where mahoadon = @mahoadon";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@mahoadon", txtMaHoaDon.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                dongTextbox();

            //else if (dialogResult == DialogResult.No)
            //{
            //    cn.Close();
            //}
         
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            dongbtn_clickdatagridview_();
            moTextbox();
            moButton();
            btnLuu.Enabled = false;
            btnCapnhat.Visible = true;
            btnSua.Enabled = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
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
            btnLuu.Enabled     = false;
            btnSua.Enabled     = true;
            btnXoa.Enabled = true;
            //try
            {
                txtMaHoaDon.Text         =  dataGridView1.CurrentRow.Cells[0].Value.ToString();
                
                txtMaKhachHang.Text         =  dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //txtMaNhanVien.Text         =  dataGridView1.CurrentRow.Cells[2].Value.ToString();
               comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Text =  dataGridView1.CurrentRow.Cells[3].Value.ToString();
              
                numericUpDown1.Text          =  dataGridView1.CurrentRow.Cells[4].Value.ToString();                         
                //MemoryStream ms      =  new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value);
                //pictureBox1.Image    =  Image.FromStream(ms);              
            }
            //catch
            //{
            //    MessageBox.Show("Lỗi xảy ra");
            //}
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

        //private void btnAnh_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog op = new OpenFileDialog();
        //    op.Title = "Chọn ảnh";
        //    op.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
        //    if(op.ShowDialog() == DialogResult.OK)
        //    {
        //        pictureBox1.ImageLocation = op.FileName;
        //    }    
        //}         
        void Xoa_TextBox()
        {
            txtMaHoaDon.Clear();
            comboBox1.ResetText();
            txtMaKhachHang.Clear();
            numericUpDown1.ResetText();
            dateTimePicker1.Value = DateTime.Now.Date;
          
            //Image imageCircle = Image.FromFile("img\\rong.jpg");
            ////Dat hinh mat dinh khi khoi dong
            //pictureBox1.Image = imageCircle;
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
            hienthi();
            dongTextbox();
            Xoa_TextBox();
        }

       
        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            XuatHD f = new XuatHD();
            f.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void LoadComboBox()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT MaNV From Nhanvien ", cn);
                da.Fill(dt);
                cn.Close();
            }//where nhanvien.manv=hoadon.manv
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "MaNV";
                comboBox1.ValueMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
    }
}