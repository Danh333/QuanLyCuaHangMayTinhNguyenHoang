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
        SqlConnection cn = new SqlConnection("");
        public QuanLyKhachHang()
        {
            InitializeComponent();
            dataGridView1.RowsAdded += RowsAdded;
            dataGridView1.RowsRemoved += RowsRemoved;
            // this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
        }
        void hienthi()
        {
            cn = new SqlConnection("");
            string sql = "select * from khachhang2";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[6];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            getsizecolums();
            //dataGridView1.Columns
            this.txtMakh.Enabled = false;
            this.txtTenkh.Enabled = false;
            this.txtSohd.Enabled = false;
            this.txtDiachi.Enabled = false;
            this.txtsodt.Enabled = false;
            this.txtghichu.Enabled = false;
            this.comboBox1.Enabled = false;
            btnAnh.Enabled = false;

        }
        void moTextbox()
        {
            txtMakh.Enabled = true;
            txtTenkh.Enabled = true;
            txtSohd.Enabled = true;
            txtDiachi.Enabled = true;
            txtsodt.Enabled = true;
            comboBox1.Enabled = true;
            txtghichu.Enabled = true;
        }
        void dongTextbox()
        {
            txtMakh.Enabled = false;
            txtTenkh.Enabled = false;
            txtSohd.Enabled = false;
            txtDiachi.Enabled = false;
            txtsodt.Enabled = false;
            comboBox1.Enabled = false;
            txtghichu.Enabled = true;
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
        public void LoadComboBox()
        {
            DataTable dt = new DataTable();
            cn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select distinct tinhtrang From khachhang2", cn);
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
                comboBox1.DisplayMember = "ghichu";
                comboBox1.ValueMember = "ghichu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
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
            // TODO: This line of code loads data into the 'abcDataSet.hoadon2' table. You can move, or remove it, as needed.
            //this.""TableAdapter.Fill(this.abcDataSet."");
            hienthi();
            dongTextbox();
            LoadComboBox();

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
            Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong
            pictureBox1.Image = imageCircle;
            //Reset textBox
            txtMakh.Clear();
            txtTenkh.Clear();
            txtSohd.Clear();
            txtsodt.Clear();
            txtghichu.Clear();
            txtDiachi.Clear();
            //Mở textBox
            txtMakh.Enabled = true;
            txtTenkh.Enabled = true;
            txtSohd.Enabled = true;
            txtsodt.Enabled = true;
            txtghichu.Enabled = true;
            txtDiachi.Enabled = true;
            comboBox1.Enabled = true;
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
            if (txtSohd.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập số hóa đơn ");
                txtSohd.Focus(); return;
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
            if (txtghichu.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập ghi chú  ");
                txtghichu.Focus(); return;
            }

            try
            {
                cn.Open();
                string sql = "insert  into khachhang2(makh,tenkh,sohd,sodt,ghichu,diachi,anh)  values(@makh,@tenkh,@sohd,@sodt,@ghichu,@diachi,@anh)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txtTenkh.Text);
                cmd.Parameters.AddWithValue("@sohd", txtSohd.Text);
                cmd.Parameters.AddWithValue("@sodt", txtsodt.Text);
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                pictureBox1.Image.Save(str, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("@anh", str.ToArray());

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
                string sql = "update khachhang2 set  tenkh=@tenkh,sohd=@sohd,sodt=@sodt,ghichu=@ghichu,diachi=@diachi,anh=@anh where makh=@makh";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txtTenkh.Text);
                cmd.Parameters.AddWithValue("@sohd", txtSohd.Text);
                cmd.Parameters.AddWithValue("@sodt", txtsodt.Text);
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
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
            string sql = "delete from khachhang2 where makh=@makh";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            pictureBox1.Image = null;
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

        private void btnTrove_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang trove = new QuanLyKhachHang();
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
                txtSohd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtsodt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtghichu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtDiachi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn ảnh";
            op.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = op.FileName;
            }
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
            txtMakh.Clear();
            txtTenkh.Clear();
            txtSohd.Clear();
            txtsodt.Clear();
            txtghichu.Clear();
            txtDiachi.Clear();
            comboBox1.ValueMember = "";
            Image imageCircle = Image.FromFile("rong.jpg");
            //Dat hinh mat dinh khi khoi dong
            pictureBox1.Image = imageCircle;
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
            btnAnh.Enabled = false;
            dongTextbox();
            Xoa_TextBox();
        }

        private void txtTenkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbtimkiem_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from khachhang2 where makh like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
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

        private void btReset_Click_1(object sender, EventArgs e)
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
