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
    public partial class QuanLyHeThong : Form
    {
        SqlConnection cn =new SqlConnection(); SqlCommand cmd = new SqlCommand();
        //string MachineName = Environment.MachineName;
        public QuanLyHeThong()
        {
            InitializeComponent();
            cn.ConnectionString = Properties.Settings.Default.ChuoiKetNoiDangNhap;
            cn.Open();
            cmd.Connection = cn;
        }
        
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void ButtonTrove_Click(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }

        private void QuanLyHeThong_Load(object sender, EventArgs e)
        {
            hienthi();
            dongTextbox();
            LoadComboBox();
            getsizecolums();//chinh chieu rong cho cot datagridview
            ButtonLuu.Enabled = false;
            ButtonCapnhat.Enabled = false;
            ButtonSua.Enabled = false;
        }
        void hienthi()
        {
            //cn = new SqlConnection("Data Source = "+ MachineName +@"; Initial Catalog = QLtaikhoan; Integrated Security = True");
            string sql = "select * from nguoidung1";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            moButton();
        }
        void moTextbox()
        {
            this.textBoxTendangnhap.Enabled = true;
            this.textBoxMatkhau.Enabled = true;
            this.comboBox.Enabled = true;
        }
        void dongTextbox()
        {
            this.textBoxTendangnhap.Enabled = false;
            this.textBoxMatkhau.Enabled = false;
            this.comboBox.Enabled = false;
        }
        void dongButton()
        {
            ButtonXoa.Enabled = false;
            ButtonLuu.Enabled = false;
            ButtonCapnhat.Enabled = false;
        }
        void moButton()
        {
          
            ButtonLuu.Enabled = true;
            ButtonCapnhat.Enabled = true;
        }
        public void LoadComboBox()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select Quyen from nguoidung1", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.ToString());
            }
            try
            {
                comboBox.DataSource = dt;
                comboBox.DisplayMember = "Quyen";
                comboBox.ValueMember = "Quyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
        public void getsizecolums()
        {
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = false;
            ButtonXoa.Visible = false;
            ButtonSua.Visible = false;
            ButtonCapnhat.Visible = false;
            //Reset textBox
            textBoxTendangnhap.Clear();
            textBoxMatkhau.Clear();
            //Mở textBox
            textBoxTendangnhap.Enabled = true;
            textBoxMatkhau.Enabled = true;
            comboBox.Enabled = true;
            moButton();
        }
        void dongbtn_clickdatagridview_()
        {
            dataGridView.Enabled = false;
            ButtonXoa.Visible = false;
            ButtonSua.Visible = false;
            ButtonCapnhat.Visible = false;
        }
        private void ButtonLuu_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = true;
            ButtonXoa.Visible = true;
            ButtonSua.Visible = true;
            ButtonCapnhat.Visible = true;
            if (textBoxTendangnhap.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                textBoxTendangnhap.Focus();
                return;
            }
            if (textBoxMatkhau.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                textBoxMatkhau.Focus();
                return;
            }
            try
            {
                cn.Open();
                string sql = "insert  into nguoidung1(username,password,quyen)  values(@username,@password,@quyen)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                
                cmd.Parameters.AddWithValue("@username", textBoxTendangnhap.Text);
                cmd.Parameters.AddWithValue("@password", textBoxMatkhau.Text);
                cmd.Parameters.AddWithValue("@quyen", comboBox.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
                ButtonLuu.Enabled = false;
                ButtonCapnhat.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(" Ðã có tên đăng nhập: " + textBoxTendangnhap.Text + ". Vui lòng chọn tên khác!", "THÔNG BÁO ");
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            moTextbox();
            moButton();
            ButtonLuu.Enabled = false;
            ButtonSua.Enabled = false;

        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from nguoidung1 where username=@username";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@username", textBoxTendangnhap.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            dongTextbox();
        }
        void Xoa_TextBox()
        {
            textBoxTendangnhap.Clear();
            textBoxMatkhau.Clear();
            comboBox.ValueMember = "";
        }

        private void ButtonCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update nguoidung1 set  username=@username,password=@password quyen=@quyen where username=@username";
                SqlCommand cmd = new SqlCommand(sql, cn);
                
                cmd.Parameters.AddWithValue("@username", textBoxTendangnhap.Text);
                cmd.Parameters.AddWithValue("@password", textBoxMatkhau.Text);
                cmd.Parameters.AddWithValue("@quyen", comboBox.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi cập nhật!");
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            //m?
            dataGridView.Enabled = true;
            ButtonXoa.Visible = true;
            ButtonSua.Visible = true;
            ButtonCapnhat.Visible = true;
            //dóng
            ButtonLuu.Enabled = false;
            ButtonSua.Enabled = false;
            ButtonCapnhat.Enabled = false;
            dongTextbox();
            Xoa_TextBox();
        }

        private void ButtonTimkiem_Click(object sender, EventArgs e)
        {
            textBoxTimkiem.Focus();
            cn.Open();
            string sql = @"select * from nguoidung1 where username like '%";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ButtonSua.Enabled = true;
            ButtonLuu.Enabled = true;
            textBoxTendangnhap.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            textBoxMatkhau.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            comboBox.Text= dataGridView.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
