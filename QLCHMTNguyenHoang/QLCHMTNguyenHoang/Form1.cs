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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "insert  into hoadon2(mahd,tenhd,tensp,gia,ngayhd,tinhtrang,anh)  values(@mahd,@tenhd,@tensp,@gia,@ngayhd,@tinhtrang,@anh)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            MemoryStream str = new MemoryStream();
            cmd.Parameters.AddWithValue("@mahd",txtMahd.Text);
            cmd.Parameters.AddWithValue("@tenhd",txtTenhd.Text);
            cmd.Parameters.AddWithValue("@tensp",txtTensp.Text);
            cmd.Parameters.AddWithValue("@gia",txtGia.Text);
            cmd.Parameters.AddWithValue("@ngayhd",dateTimePicker1.Value.ToString());
            cmd.Parameters.AddWithValue("@tinhtrang",comboBox1.Text);
            pictureBox1.Image.Save(str, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("@anh", str.ToArray());
            cmd.ExecuteNonQuery();
            cn.Close();
            hienthi();
            Image imageCircle = Image.FromFile("Anh\\empty.jpg");

            // Set deafult picture on start
            pictureBox1.Image = imageCircle;
             
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn ảnh";
            op.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = op.FileName;
            }
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
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenhd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTensp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
