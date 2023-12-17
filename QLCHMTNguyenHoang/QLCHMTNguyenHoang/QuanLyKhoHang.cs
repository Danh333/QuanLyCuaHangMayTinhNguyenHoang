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
    public partial class QuanLyKhoHang : Form
    {
        SqlConnection cn;
        string MachineName = Environment.MachineName;
        public QuanLyKhoHang()
        {

            InitializeComponent();
            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;
        }
        void hienthi()
        {
            cn = new SqlConnection("Data Source ="+ MachineName +@"; Initial Catalog = QLCHMaytinh; Integrated Security = True");
            string sql = "select * from khachhang2";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            //da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            //pic = (DataGridViewImageColumn)dataGridView1.Columns[6];
            //pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            getsizecolums();
            //dataGridView1.Columns
            this.txtMahh.Enabled = false;
            this.txtTenhh.Enabled = false;
            this.txtSol.Enabled = false;
            this.txtGia.Enabled = false;
            this.txttinhtrang.Enabled = false;


        }
        void moTextbox()
        {
            txtMahh.Enabled = true;
            txtTenhh.Enabled = true;
            txtSol.Enabled = true;
            txtGia.Enabled = true;
            txttinhtrang.Enabled = true;

        }
        void dongTextbox()
        {
            txtMahh.Enabled = false;
            txtTenhh.Enabled = false;
            txtSol.Enabled = false;
            txtGia.Enabled = false;
            txttinhtrang.Enabled = false;

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
            label8.Text = "Tổng số hàng hóa  :" + (dataGridView1.Rows.Count).ToString();
        }

        private void RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label8.Text = "Tổng số hàng hóa : " + (dataGridView1.Rows.Count).ToString();
        }
        private void btnTrove_Click(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void QuanLyKhoHang_Load(object sender, EventArgs e)
        {
           
            hienthi();
            dongTextbox();


            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
          

            //Reset textBox
            txtMahh.Clear();
            txtTenhh.Clear();
            txtSol.Clear();
            txtGia.Clear();
            txttinhtrang.Clear();
            //Mở textBox
            txtMahh.Enabled = true;
            txtTenhh.Enabled = true;
            txtSol.Enabled = true;
            txtGia.Enabled = true;
            txttinhtrang.Enabled = true;

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
            //dataGridView1.Columns[6].Width = 250;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;

            try
            {
                txtMahh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenhh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSol.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtGia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttinhtrang.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
               

            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
            btnCapnhat.Visible = true;
            if (txtMahh.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mã hàng hóa !");
                txtMahh.Focus();
                return;
            }
            if (txtTenhh.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập Tên hàng hóa");
                txtTenhh.Focus(); return;
            }
            if (txtSol.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập số lượng hàng hóa ");
                txtSol.Focus(); return;
            }
            if (txtGia.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập giá hàng hóa ");
                txtGia.Focus(); return;
            }
            if (txttinhtrang.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập tình trạng hoàng hóa ");
                txttinhtrang.Focus(); return;
            }

            try
            {
                cn.Open();
                string sql = "insert  into khachhang2(mahh,tenhh,sohd,sodt,ghichu,diachi,anh)  values(@mahh,@tenhh,@sohd,@sodt,@ghichu,@diachi,@anh)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@tenhh", txtTenhh.Text);
                cmd.Parameters.AddWithValue("@sohd", txtSol.Text);
                cmd.Parameters.AddWithValue("@sodt", txtGia.Text);
                cmd.Parameters.AddWithValue("@ghichu", txttinhtrang.Text);
                //cmd.Parameters.AddWithValue("@anh", str.ToArray());

                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                btnLuu.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(" Tên đã tồn tại : " + txtMahh.Text + ". Vui lòng chọn tên khác ", "THÔNG BÁO ");
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update hanghoa2 set  tenhh=@tenhh,sohd=@sohd,sodt=@sodt,ghichu=@ghichu,diachi=@diachi,anh=@anh where makh=@mahh";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
                cmd.Parameters.AddWithValue("@tenhh", txtTenhh.Text);
                cmd.Parameters.AddWithValue("@sohd", txtSol.Text);
                cmd.Parameters.AddWithValue("@sodt", txtGia.Text);
                cmd.Parameters.AddWithValue("@ghichu", txttinhtrang.Text);

                //cmd.Parameters.AddWithValue("@anh", str.ToArray());
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
            string sql = "delete from hanghoa2 where makh=@mahh";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@mahh", txtMahh.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();

            dongTextbox();


            //else if (dialogResult == DialogResult.No)
            //{
            //    cn.Close();
            //}
            //Image imageCircle = Image.FromFile("Anh\\empty1.jpg");
            //Dat hinh mat dinh khi khoi dong
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            moTextbox();
            moButton();
            btnLuu.Enabled = false;

            btnSua.Enabled = false;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
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
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if ((e.Exception) is System.Data.ConstraintException)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "must be unique value";
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "must be unique value";
                    MessageBox.Show(e.Exception.Message, "Error ConstraintException",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.ThrowException = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: dataGridView1_DataError",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Xoa_TextBox()
        {
            txtMahh.Clear();
            txtTenhh.Clear();
            txtSol.Clear();
            txtGia.Clear();
            txttinhtrang.Clear();

            //Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong

        }

        private void button8_Click(object sender, EventArgs e)
        {
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
            string sql = @"select * from khohang2 where makh like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
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

    }
}
