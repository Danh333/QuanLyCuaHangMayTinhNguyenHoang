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
using System.IO;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyHangHoa : Form
    {
        SqlConnection cn;
        string MachineName = Environment.MachineName;
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
            buttonxoa.Visible = false;
            buttonsua.Visible = false;
            buttoncapnhat.Visible = false;
            

            txtMahh.Clear();
            txtTenHangHoa.Clear();
            txtimei.Clear();
            txtsoluong.Clear();
            txtDongia.Clear();



            txtMahh.Enabled = true;
            txtTenHangHoa.Enabled = true;
            txtimei.Enabled = true;
            txtsoluong.Enabled = true;
            txtDongia.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker1.Value = DateTime.Now.Date;
            moButton();
        }
        void moTextbox()
        {

            txtMahh.Enabled = true;
            txtTenHangHoa.Enabled = true;
            txtimei.Enabled = true;
            txtsoluong.Enabled = true;
            txtDongia.Enabled = true;
            dateTimePicker1.Enabled = true;
            
        }
        void dongTextbox()
        {

            txtMahh.Enabled = false;
            txtTenHangHoa.Enabled = false;
            txtimei.Enabled = false;
            txtsoluong.Enabled = false;
            txtDongia.Enabled = false;
            dateTimePicker1.Enabled = false;
        }
        void dongButton()
        {
            buttonxoa.Enabled = false;
            buttonluu.Enabled = false;
            buttoncapnhat.Enabled = false;
        }
        void moButton()
        {
            buttonluu.Enabled = true;
            buttoncapnhat.Enabled = true;

        }
        void hienthi()
        {
            cn = new SqlConnection(@"Data Source=m15\sqlexpress;Initial Catalog=QLCHMaytinh;Integrated Security=True");
            string sql = "select * from qlhanghoa";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            getsizecolums();
            dongButton();



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
            buttonxoa.Visible = true;
            buttonsua.Visible = true;
            buttoncapnhat.Visible = true;
            try
            {
                cn.Open();
                string sql = "insert  into qlhanghoa(mahh,tenhh,imei,soluong,dongia,ngaycapnhat)  values(@mahh,@tenhh,@imei,@soluong,@dongia,@ngaycapnhat)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();

                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@tenhh", txtTenHangHoa.Text);
                cmd.Parameters.AddWithValue("@imei", txtimei.Text);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@dongia", txtDongia.Text);
                cmd.Parameters.AddWithValue("@ngaycapnhat", dateTimePicker1.Value.ToString());
                
                
                
            

                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                buttonluu.Enabled = false;
                buttoncapnhat.Enabled = false;
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
            buttonluu.Enabled = false;

            buttonsua.Enabled = false;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from qlhanghoa where mahh=@mahh";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@mahanghoa", txtMahh.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            
            dongTextbox();


            
            
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update qlhanghoa set  ,mahh=@mahh,tenhh=@tenhh,imei=@imei,soluong=@soluong,dongia=@dongia,ngaycapnhat=@ngaycapnhat where mahh=@mahh";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();

                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@tenhh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@imei", txtMahh.Text);
                cmd.Parameters.AddWithValue("@soluong", txtMahh.Text);
                cmd.Parameters.AddWithValue("@dongia", txtDongia.Text);
                cmd.Parameters.AddWithValue("@ngaycapnhat", dateTimePicker1.Value.ToString());

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
            buttonxoa.Visible = true;
            buttonsua.Visible = true;
            buttoncapnhat.Visible = true;
            //đóng
            buttonluu.Enabled = false;
            buttonsua.Enabled = false;
            buttoncapnhat.Enabled = false;



        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from qlhanghoa where mahh like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
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
            buttonxoa.Visible = false;
            buttonsua.Visible = false;
            buttoncapnhat.Visible = false;
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
            buttoncapnhat.Enabled = false;
            buttonluu.Enabled = false;
            buttonsua.Enabled = true;

            try
            {

                txtMahh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenHangHoa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtimei.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtsoluong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDongia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();



                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value);
                
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
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

