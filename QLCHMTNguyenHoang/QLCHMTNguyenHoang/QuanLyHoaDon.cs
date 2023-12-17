using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyHoaDon : Form
    {
        SqlConnection cn = new SqlConnection();
       
        SqlCommand cmd = new SqlCommand();
        

        public QuanLyHoaDon()
        {
            InitializeComponent();
            cn.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            cn.Open();
            cmd.Connection = cn;

            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;
            numericUpDown1.TextChanged += TinhTong;
            txtGiaTien.TextChanged += TinhTong;
           
            
        }
        void hienthi()
        {        
            string sql = "select * from hoadon";                    
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            getsizecolums();        
            KhoaNhapDuLieu();
            LoadComboBoxNhanVien();
            //LoadComboBoxTenHangHoa();
            LoadComboBoxKH();
            LoadComboBoxMaHH();
        }


        void Xoa_TextBox()
        {
            
            txtMaHoaDon.Clear();
            comboBoxMaHH.ResetText();
            txtMaKhachHang.ResetText();
            comboBoxMaNV.ResetText();
            numericUpDown1.ResetText();
            txtGiaTien.Clear();
            txtTongTien.Clear();
            dateTimePicker1.Value = DateTime.Now.Date;
        }
        void MoKhoaNhapDuLieu()
        {
            txtMaHoaDon.Enabled = true;
            comboBoxMaNV.Enabled = true;          
            comboBoxMaHH.Enabled = true;
            comboBoxMaKH.Enabled = true;
            numericUpDown1.Enabled = true;
            txtGiaTien.Enabled = true;
            txtTongTien.Enabled = true;
            dateTimePicker1.Enabled = true;
        }
        void KhoaNhapDuLieu()
        {      
            txtMaHoaDon.Enabled = false;          
            comboBoxMaHH.Enabled = false;
            comboBoxMaKH.Enabled = false;
            comboBoxMaNV.Enabled = false;
            numericUpDown1.Enabled = false;
            txtGiaTien.Enabled = false;
            txtTongTien.Enabled = false;
            dateTimePicker1.Enabled = false;          
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
            KhoaNhapDuLieu();   
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            comboBoxMaHH.Text = "";
            comboBoxMaKH.Text = "";
            comboBoxMaNV.Text = "";
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
            MoKhoaNhapDuLieu();
            //txtMaHoaDon.Enabled = true;  
            //txtMaKhachHang.Enabled = true;    
            //dateTimePicker1.Value = DateTime.Now.Date;          
            //txtTongTien.Enabled = true;
            //txtMaNhanVien.Enabled = true;
            moButton();//mở button
        }
        public void getsizecolums()  //đặt chiều rộng cố định cho cột
        {
            //dataGridView1.Columns[0].Width = 100;
            //dataGridView1.Columns[1].Width = 100; 
            //dataGridView1.Columns[2].Width = 150;
            //dataGridView1.Columns[3].Width = 100;
            //dataGridView1.Columns[4].Width = 100;
            //dataGridView1.Columns[5].Width = 100;
            //dataGridView1.Columns[6].Width = 100;
            //dataGridView1.Columns[7].Width = 100;
            //dataGridView1.Columns[8].Width = 100;
            //dataGridView1.Columns[9].Width = 100;

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
            KhoaNhapDuLieu();
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
           
            //if (txtMaKhachHang.Text == "")
            //{
            //    dongbtn_clickdatagridview_();
            //    MessageBox.Show("Vui lòng nhập Tên sản phẩm");
            //    txtMaKhachHang.Focus(); return;
            //}
            
                   
          // try
            {
                cn.Open();
                string sql = "insert into hoadon (MaHD,MaHH,MaKH,MaNV,Soluong,dongia,tongtien,NgayLap) values (@MaHD,@MaHH,@MaKH,@MaNV,@Soluong,@Dongia,@tongtien,@NgayLap)";                  
                SqlCommand   cmd = new SqlCommand(sql,cn);             
                cmd.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaHH", comboBoxMaHH.Text);
                cmd.Parameters.AddWithValue("@MaKH", comboBoxMaKH.Text);
                cmd.Parameters.AddWithValue("@MaNV", comboBoxMaNV.Text); 
                cmd.Parameters.AddWithValue("@Soluong", numericUpDown1.Value.ToString());
                cmd.Parameters.AddWithValue("@Dongia", txtGiaTien.Text);
                cmd.Parameters.AddWithValue("@tongtien", txtTongTien.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value.ToString());        
                                 
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
            dataGridView1.Enabled = true;
            try
            {
                cn.Open();
                string sql = "update hoadon set  mahd=@MaHD,mahh=@MaHH,makh=@MaKH,manv=@MaNV,soluong=@Soluong,dongia=@Dongia,tongtien=@tongtien,ngaylap=@NgayLap where mahd=@mahd";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaHH", comboBoxMaHH.Text);
                cmd.Parameters.AddWithValue("@MaKH", comboBoxMaKH.Text);
                cmd.Parameters.AddWithValue("@MaNV", comboBoxMaNV.Text);
                cmd.Parameters.AddWithValue("@Soluong", numericUpDown1.Value.ToString());
                cmd.Parameters.AddWithValue("@Dongia", txtGiaTien.Text);
                cmd.Parameters.AddWithValue("@tongtien", txtTongTien.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                //cmd.Parameters.AddWithValue("@NgayLap", dateTimePicker1.Value.ToString());DateTime.Parse(Đ/MM/YYYY)
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi cập nhật");
            }
        }
       
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaHoaDon.Text))
            {
                // Display a confirmation dialog
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "DELETE FROM hoadon WHERE mahd = @mahd";
                        using (SqlCommand cmd = new SqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@mahd", txtMaHoaDon.Text);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        hienthi();
                        KhoaNhapDuLieu();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            dongbtn_clickdatagridview_();
            MoKhoaNhapDuLieu();
            moButton();
            btnLuu.Enabled = false;
            btnCapnhat.Visible = true;
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
            btnLuu.Enabled     = false;
            btnSua.Enabled     = true;
            btnXoa.Enabled = true;
            //try
            {
                txtMaHoaDon.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxMaHH.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBoxMaKH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBoxMaNV.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtGiaTien.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtTongTien.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();            
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
               
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
            KhoaNhapDuLieu();
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
        public void LoadComboBoxNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT MaNV From Nhanvien ", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBoxMaNV.DataSource = dt;
                comboBoxMaNV.DisplayMember = "MaNV";
                comboBoxMaNV.ValueMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
       

        public void LoadComboBoxKH()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT MaKH From Khachhang ", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBoxMaKH.DataSource = dt;
                comboBoxMaKH.DisplayMember = "MaKH";
                comboBoxMaKH.ValueMember = "MaKh";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
        //public void LoadComboBoxTenHangHoa()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("SELECT TenHH From HangHoa ", cn);
        //        da.Fill(dt);
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Có lỗi");
        //    }
        //    try
        //    {
        //        comboBoxTenHH.DataSource = dt;
        //        comboBoxTenHH.DisplayMember = "TenHH";
        //        comboBoxTenHH.ValueMember = "TenHH";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
        //    }
        //}


        public void LoadComboBoxMaHH()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaHH From HangHoa ", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBoxMaHH.DataSource = dt;
                comboBoxMaHH.DisplayMember = "MaHH";
                comboBoxMaHH.ValueMember = "MaHH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
        private void TinhTong(object sender, EventArgs e)
        {   
            if (int.TryParse(numericUpDown1.Text, out int soLuong) && int.TryParse(txtGiaTien.Text, out int giaTien))
            {              
                int tongTien = soLuong * giaTien;          
                txtTongTien.Text = tongTien.ToString();
            }       
        }
        private void comboBoxSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaHH.SelectedItem != null)
            {
                try
                {
                    cn.Open();

                    string ChonHH = comboBoxMaHH.SelectedValue.ToString();

                    string query = "SELECT dongia, tenHH FROM HangHoa WHERE MaHH = @MaHH";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@MaHH", ChonHH);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Read values from the data reader
                                txtGiaTien.Text = reader["dongia"].ToString();
                                txtTenHH.Text = reader["tenHH"].ToString();
                            }
                            else
                            {
                                txtTenHH.Text = "";
                                txtGiaTien.Text = "Trống";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Khi load Giá: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            //if (comboBoxMaHH.SelectedItem != null)
            //{
            //    try
            //    {
            //        cn.Open();

            //        string ChonHH = comboBoxMaHH.SelectedValue.ToString();


            //        string query = "SELECT dongia,tenHH FROM HangHoa WHERE MaHH = @MaHH";
            //        using (SqlCommand cmd = new SqlCommand(query, cn))
            //        {
            //            cmd.Parameters.AddWithValue("@MaHH", ChonHH);


            //            object result = cmd.ExecuteScalar();

            //            if (result != null)
            //            {

            //                txtGiaTien.Text = result.ToString();
            //                txtTenHH.Text = result.ToString();
            //            }
            //            else
            //            {
            //                txtTenHH.Text = "";
            //                txtGiaTien.Text = "Trống";
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi Khi load Giá: " + ex.Message);
            //    }
            //    finally
            //    {
            //        cn.Close();
            //    }
            // }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
   
}