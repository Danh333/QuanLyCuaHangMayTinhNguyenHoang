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
        SqlConnection cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");

        public QuanLyHoaDon()
        {
            InitializeComponent();
            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;
        }
        void hienthi()
        {
            cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
            string sql = "select * from hoadon1";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.txtMahd.Enabled = false;
            this.txtTenhd.Enabled = false;
            this.txtGia.Enabled = false;
            this.txtTensp.Enabled = false;
            this.comboBox1.Enabled = false;
        }
        void moTextbox()
        {
            txtMahd.Enabled = true;
            txtTenhd.Enabled = true;
            txtTensp.Enabled = true;
            comboBox1.Enabled = true;
            txtGia.Enabled = true;
        }
        void dongTextbox()
        {
            txtMahd.Enabled = false;
            txtTenhd.Enabled = false;
            txtTensp.Enabled = false;
            comboBox1.Enabled = false;
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
        public void LoadComboBox()
        {
            DataTable dt = new DataTable();
            cn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select distinct tinhtrang From hoadon1", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.ToString());
            }
            try
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "tinhtrang";
                comboBox1.ValueMember = "tinhtrang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
        private void RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            label8.Text = "Tổng số đơn hàng :" + (dataGridView1.Rows.Count - 1).ToString();
        }

        private void RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label8.Text = "Tổng số hoa đơn : " + (dataGridView1.Rows.Count - 1).ToString();
        }
        private void QuanLiHoaDon_Load(object sender, EventArgs e)
        {
            hienthi();
            dongTextbox();
            LoadComboBox();
           
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            //Reset textBox
            txtMahd.Clear();
            txtTenhd.Clear();
            txtTensp.Clear();
            txtGia.Clear();
            //Mở textBox
            txtMahd.Enabled = true;
            txtTenhd.Enabled = true;
            txtTensp.Enabled = true;
            dateTimePicker1.Value = DateTime.Now.Date;
            comboBox1.Enabled = true;
            txtGia.Enabled = true;
            moButton();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from hoadon1 where mahd like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMahd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn !");
                txtMahd.Focus();
                return;
            }
            if (txtTenhd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên hóa đơn");
                txtTenhd.Focus(); return;
            }
            if (txtTensp.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm");
                txtTensp.Focus(); return;
            }
            if (txtGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Giá tiền ");
                txtGia.Focus(); return;
            }
            if (dateTimePicker1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngày hóa đơn");
                dateTimePicker1.Focus(); return;
            }
            try
            {
                cn.Open();
                string mahd = txtMahd.Text;
                string tenhd = txtTenhd.Text;
                string tensp = txtTensp.Text;
                string gia = txtGia.Text;
                string ngayhd = dateTimePicker1.Value.ToString();
                string cbtinhtrang = comboBox1.Text;
                string sql = "insert into hoadon1(mahd,tenhd,tensp,gia,ngayhd,tinhtrang) values  ('" + mahd + "','" + tenhd + "','" + tensp + "','" + gia + "','" + ngayhd + "','" + cbtinhtrang + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                cmd.ExecuteNonQuery();
                hienthi();
                dongTextbox();
                cn.Close();
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
                string mahd = txtMahd.Text;
                string tenhd = txtTenhd.Text;
                string tensp = txtTensp.Text;
                string gia = txtGia.Text;
                string ngayhd = dateTimePicker1.Value.ToString();
                string cbtinhtrang = comboBox1.Text;
                string sql = "UPDATE hoadon1 SET  tenhd = '" + tenhd + "' , tensp='" + tensp + "', gia='" + gia + "', NgayHD = '" + ngayhd + "',TinhTrang='" + cbtinhtrang + "'WHERE mahd='" + mahd + "'     ";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                hienthi();
                dongTextbox();
                cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi cập nhật");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            DialogResult dialogResult = MessageBox.Show("Xác nhận xóa ", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string sql = @"delete from hoadon1 where mahd=N'" + txtMahd.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                hienthi();
                dongTextbox();
            }
            else if (dialogResult == DialogResult.No)
            {
                cn.Close();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextbox();
            moButton();
            btnLuu.Enabled = false;
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
            try
            {
                int numrow;
                numrow = e.RowIndex;
                if (dataGridView1.Rows.Count > 0)
                {
                    txtMahd.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
                    txtTenhd.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
                    txtTensp.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
                    txtGia.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();                  
                }
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

     
    }
}