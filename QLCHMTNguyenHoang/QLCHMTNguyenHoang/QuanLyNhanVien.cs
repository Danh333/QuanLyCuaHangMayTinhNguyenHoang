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
    public partial class QuanLyNhanVien : Form
    {
        SqlConnection cn;
        string machineName = Environment.MachineName;
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?","",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void ButtonTrove_Click(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }
        void hienthi()
        {
            //\SQLEXPRESS
            cn = new SqlConnection("Data Source ="+machineName+@"; Initial Catalog = QLCHMTNguyenHoang; Integrated Security = True");
            string sql = "select * from NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }
        void moTextbox()
        {
            this.TextBoxMaNV.Enabled = true;
            this.TextBoxTenNV.Enabled = true;
            this.TextBoxCCCD.Enabled = true;
            this.TextBoxSoDT.Enabled = true;
            this.TextBoxDiaChi.Enabled = true;
            this.comboBoxChucvu.Enabled = true;
        }
        void dongTextbox()
        {
            this.TextBoxMaNV.Enabled = false;
            this.TextBoxTenNV.Enabled = false;
            this.TextBoxCCCD.Enabled = false;
            this.TextBoxSoDT.Enabled = false;
            this.TextBoxDiaChi.Enabled = false;
            this.comboBoxChucvu.Enabled = false;
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
                SqlDataAdapter da = new SqlDataAdapter("Select Chucvu From NhanVien", cn);
                da.Fill(dt);
                comboBoxChucvu.DataSource = dt;
                comboBoxChucvu.DisplayMember = "Chucvu";
                comboBoxChucvu.ValueMember = "Chucvu";
                cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi load dữ liệu" + ex.ToString());
            }
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            hienthi();
            dongTextbox();
            LoadComboBox();
            getsizecolums();//chinh chieu rong cho cot datagridview
            ButtonLuu.Enabled = false;
            ButtonCapnhat.Enabled = false;
            ButtonSua.Enabled = false;
        }
        public void getsizecolums()
        {
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
        }
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = false;
            ButtonXoa.Visible = false;
            ButtonSua.Visible = false;
            ButtonCapnhat.Visible = false;
            //Reset textBox
            TextBoxMaNV.Clear();
            TextBoxTenNV.Clear();
            TextBoxSoDT.Clear();
            TextBoxCCCD.Clear();
            TextBoxDiaChi.Clear();
            //Mở textBox
            TextBoxMaNV.Enabled = true;
            TextBoxTenNV.Enabled = true;
            TextBoxSoDT.Enabled = true;
            TextBoxCCCD.Enabled = true;
            TextBoxDiaChi.Enabled = true;
            comboBoxChucvu.Enabled = true;
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
            if (TextBoxMaNV.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                TextBoxMaNV.Focus(); return;
            }
            if (TextBoxTenNV.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                TextBoxTenNV.Focus(); return;
            }
            if (TextBoxSoDT.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                TextBoxSoDT.Focus(); return;
            }
            if (TextBoxCCCD.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập số CCCD!");
                TextBoxCCCD.Focus(); return;
            }
            if (TextBoxDiaChi.Text == "")
            {
                dongbtn_clickdatagridview_();
                MessageBox.Show("Vui lòng nhập địa chỉ ");
                TextBoxDiaChi.Focus(); return;
            }
            try
            {
                cn.Open();
                string sql = "insert into NhanVien(manv,tennv,cccd,sodt,dichi)  values(@manv,@tennv,@cccd,@sodt,@diachi)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@manv", TextBoxMaNV.Text);
                cmd.Parameters.AddWithValue("@tennv", TextBoxTenNV.Text);
                cmd.Parameters.AddWithValue("@sodt", TextBoxSoDT.Text);
                cmd.Parameters.AddWithValue("@CCCD", TextBoxCCCD.Text);
                cmd.Parameters.AddWithValue("@diachi", TextBoxDiaChi.Text);

                hienthi();
                ButtonLuu.Enabled = false;
                ButtonCapnhat.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(" Ðã có mã nhân viên mang tên : " + TextBoxMaNV.Text + ". Vui lòng chọn mã khác!", "THÔNG BÁO ");
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
            string sql = "delete from NhanVien where manv=@manv";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@manv", TextBoxMaNV.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            dongTextbox();
        }
        void Xoa_TextBox()
        {
            TextBoxMaNV.Clear();
            TextBoxTenNV.Clear();
            TextBoxSoDT.Clear();
            TextBoxCCCD.Clear();
            TextBoxDiaChi.Clear();
            comboBoxChucvu.ValueMember = "";
        }

        private void ButtonCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string sql = "update NhanVien set  tennv=@tennv,cccd=@cccd,sodt=@sodt,diachi=@diachi where manv=@manv";
                SqlCommand cmd = new SqlCommand(sql, cn);
                MemoryStream str = new MemoryStream();
                cmd.Parameters.AddWithValue("@manv", TextBoxMaNV.Text);
                cmd.Parameters.AddWithValue("@tennv", TextBoxTenNV.Text);
                cmd.Parameters.AddWithValue("@cccd", TextBoxCCCD.Text);
                cmd.Parameters.AddWithValue("@sodt", TextBoxSoDT.Text);
                cmd.Parameters.AddWithValue("@diachi", TextBoxDiaChi.Text);
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
            //mở
            dataGridView.Enabled = true;
            ButtonXoa.Visible = true;
            ButtonSua.Visible = true;
            ButtonCapnhat.Visible = true;
            //đóng
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
            string sql = @"select * from NhanVien where manv like '%" + textBoxTimkiem.Text + "%' or tennv like N'%" + textBoxTimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();
        }
    }
}
