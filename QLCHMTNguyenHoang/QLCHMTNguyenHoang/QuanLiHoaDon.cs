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
    public partial class QuanLiHoaDon : Form
    {
        SqlConnection cn;
        public QuanLiHoaDon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLiBanHang trove = new QuanLiBanHang();
            trove.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLiHoaDon_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=M3\SQLEXPRESS;Initial Catalog=nguoidung;Integrated Security=True");
            string sql = "select * from hoadon";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                listView1.Items.Add(dr["mahd"].ToString());
                listView1.Items[i].SubItems.Add(dr["tenhd"].ToString());
                listView1.Items[i].SubItems.Add(dr["tensp"].ToString());
                listView1.Items[i].SubItems.Add(dr["gia"].ToString());

                listView1.Items[i].SubItems.Add(dr["ngayhd"].ToString());
                listView1.Items[i].SubItems.Add(dr["tinhtrang"].ToString());

                i++;
            }
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.txtGia.Enabled = false;
            this.txtTensp.Enabled = false;
            this.txttinhtrang.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
                    txtTensp.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
                    txtGia.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
                    txttinhtrang.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
  

            this.textBox1.Clear();
            this.textBox2.Clear();
            this.txtGia.Clear();
            this.txtTensp.Clear();
            this.txttinhtrang.Clear();

            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.txtGia.Enabled = true;
            this.txtTensp.Enabled = true;
            this.txttinhtrang.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.txtGia.Enabled = false;
            this.txtTensp.Enabled = false;
            this.txttinhtrang.Enabled = false;
        }
    }
}
