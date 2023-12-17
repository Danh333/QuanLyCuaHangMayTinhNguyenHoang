using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyKhachHang : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        string MachineName = Environment.MachineName;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            cn.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            cn.Open();
            cmd.Connection = cn;

            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;
           
        }
        void hienthi()
        {
           // cn = new SqlConnection("Data Source="+ MachineName +@";Initial Catalog=QLCHMTNguyenHoang;Integrated Security=True");
            string sql = "select * from khachhang";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            getsizecolums();//ham chinh chieu rong
            this.txtMakh.Enabled = false;
            this.txtTenkh.Enabled = false;
            this.txtEmail.Enabled = false;

            this.txtDiachi.Enabled = false;
            this.txtsodt.Enabled = false;
            LoadComboBoxCongNo();
        }
        void moTextbox()
        {
            txtMakh.Enabled = true;
            txtTenkh.Enabled = true;
            txtEmail.Enabled = true;
            txtDiachi.Enabled = true;
            txtsodt.Enabled = true;
            comboBox.Enabled = true;
        }
        void dongTextbox()
        {
            txtMakh.Enabled = false;
            txtTenkh.Enabled = false;
            txtEmail.Enabled = false;
            txtDiachi.Enabled = false;
            txtsodt.Enabled = false;
            comboBox.Enabled = false;
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
            label8.Text = "Tổng số khách hàng :" + (dataGridView1.Rows.Count).ToString();
        }

        private void RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label8.Text = "Tổng số khách hàng : " + (dataGridView1.Rows.Count).ToString();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
           
            hienthi();
            dongTextbox();        
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
            
           
            //Reset textBox
            txtMakh.Clear();
            txtTenkh.Clear();
            txtEmail.Clear();
            txtsodt.Clear();
            txtDiachi.Clear();
            //Mở textBox
            txtMakh.Enabled = true;
            txtTenkh.Enabled = true;
            txtEmail.Enabled = true;
            txtsodt.Enabled = true;
            txtDiachi.Enabled = true;
          
            moButton();
        }
        public void getsizecolums()
        {
            //chinh chieu rong cot theo y muon
            //dataGridView1.Columns[0].Width = 150;
            //dataGridView1.Columns[1].Width = 150;
            //dataGridView1.Columns[2].Width = 150;
            //dataGridView1.Columns[3].Width = 150;
            //dataGridView1.Columns[4].Width = 150;
            //dataGridView1.Columns[5].Width = 150;
            //dataGridView1.Columns[6].Width = 250;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnCapnhat.Visible = true;
            if (txtMakh.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mã khách hàng !");
                txtMakh.Focus();
                return;
            }
            if (txtTenkh.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập Tên khách hàng");
                txtTenkh.Focus(); return;
            }
            
            if (txtsodt.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập số điện thoại ");
                txtsodt.Focus(); return;
            }
            if (txtDiachi.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập địa chỉ ");
                txtDiachi.Focus(); return;
            }
            try
            {
                cn.Open();
                string sql = "insert  into khachhang(makh,tenkh,sodt,email,diachi,congno)  values(@makh,@tenkh,@sodt,@email,@diachi,@congno)";
                SqlCommand cmd = new SqlCommand(sql, cn);
               
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txtTenkh.Text);
               
                cmd.Parameters.AddWithValue("@sodt", txtsodt.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@congno", comboBox.Text);

                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                btnLuu.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(" Đã có Khách hàng mang tên : " + txtMakh.Text + ". Vui lòng chọn tên khác ", "THÔNG BÁO ");
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update khachhang set makh=@makh, tenkh=@tenkh,sodt=@sodt,email=@email,diachi=@diachi,congno=@congno where makh=@makh";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txtTenkh.Text);

                cmd.Parameters.AddWithValue("@sodt", txtsodt.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@congno", comboBox.Text);

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
            string sql = "delete from khachhang where makh=@makh";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();         
            dongTextbox();

          
         
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextbox();
            moButton();
            btnLuu.Enabled = false;
            
            btnSua.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {       
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;

            try
            {
                txtMakh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenkh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtsodt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDiachi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();


            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }

        void Xoa_TextBox()
        {
            txtMakh.Clear();
            txtTenkh.Clear();
            txtEmail.Clear();
            txtsodt.Clear();
            txtDiachi.Clear();
           
           
            
        }

        private void btnReset_Click(object sender, EventArgs e)
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
            
            dongTextbox();
            Xoa_TextBox();
        }

       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from khachhang where makh like '%" + txttimkiem.Text + "%' or tenKH like N'%" + txttimkiem.Text + "%'";
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

        private void btReset_Click(object sender, EventArgs e)
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
            
            Xoa_TextBox();
        }

        public void LoadComboBoxCongNo()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT congno From khachhang ", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBox.DataSource = dt;
                comboBox.DisplayMember = "Congno";
                comboBox.ValueMember = "Congno";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }



    }
    
    
}
