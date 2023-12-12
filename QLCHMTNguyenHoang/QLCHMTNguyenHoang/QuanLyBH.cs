using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyBH : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
        public QuanLyBH()
        {
            InitializeComponent();
        }

        private void QuanLyBH_Load(object sender, EventArgs e)
        {
            hienthi();
            dongTextbox();


            btnLuu.Enabled = false;
            btnCapnhat.Enabled = false;
            btnSua.Enabled = false;
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
        void hienthi()
        {
            cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
            string sql = "select * from hoadon2";
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

           
        }
        void moTextbox()
        {
            txtMahd.Enabled = true;
            txtMahh.Enabled = true;
            txtManv.Enabled = true;

            txtGia.Enabled = true;
        }
        void dongTextbox()
        {
            txtMahd.Enabled = false;
            txtMahh.Enabled = false;
            txtManv.Enabled = false;

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
            btnCapnhat.Visible = false;
            Image imageCircle = Image.FromFile("rong.jpg");
           
           
            //Reset textBox
            txtMahd.Clear();
            txtMahh.Clear();
            txtManv.Clear();
            txtGia.Clear();
            //Mở textBox
            txtMahd.Enabled = true;
            txtMahh.Enabled = true;
            txtManv.Enabled = true;
          

            txtGia.Enabled = true;
            moButton();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus();
            cn.Open();
            string sql = @"select * from hoadon2 where mahd like '%" + txttimkiem.Text + "%' or tensp like N'%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            dongTextbox();
            cn.Close();
        }
    }
}
