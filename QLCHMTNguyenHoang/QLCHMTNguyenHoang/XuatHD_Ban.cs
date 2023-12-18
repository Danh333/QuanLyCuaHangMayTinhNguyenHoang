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
    public partial class XuatHD_Ban : Form
    {
        SqlConnection cn = new SqlConnection();
        public XuatHD_Ban()
        {
            InitializeComponent();
        }
        public void SetReportSource(CryXuatHD_Ban report)
        {
            crystalReportViewer1.ReportSource = report;
        }

        void Load_HD()
        {
            cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=QLCHMTNguyenHoang;Integrated Security=True");
            string sql = "SELECT hoadon.mahd, Khachhang.tenkh,hanghoa.tenhh,   hoadon.soluong,    hanghoa.dongia,    hoadon.tongtien,   hoadon.ngaylap,   Khachhang.sodt FROM  hoadon JOIN   Khachhang ON hoadon.makh = Khachhang.makh JOIN  hanghoa ON hoadon.mahh = hanghoa.mahh where mahd = 'HD001'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CryXuatHD_Ban rp = new CryXuatHD_Ban();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
        private void XuatHD_Ban_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("HD Nhập");
            comboBox1.Items.Add("HD Bán");
           
            LoadComboBoxMaHH();
        }
        public void LoadComboBoxMaHH()
        {
            cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=QLCHMTNguyenHoang;Integrated Security=True");
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT distinct MaKH From HoaDon ", cn);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi");
            }
            try
            {
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "MaKH";
                comboBox2.ValueMember = "MaKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu\n", ex.ToString());
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "HD Nhập")
            {
                HDnhap n = new HDnhap();
                n.ShowDialog();
            }
            if (comboBox1.SelectedItem == "HD Bán")
            {
                XuatHD c = new XuatHD();
                c.ShowDialog();
            }
        }
        void LoadHDKH()
        {

        }
        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox2.SelectedItem != null)
        //    {
        //        try
        //        {
        //            cn.Open();

        //            string ChonHH = comboBox2.SelectedValue.ToString();

        //            string query = "SELECT   hoadon.mahd, Khachhang.makh, Khachhang.tenkh, hanghoa.tenhh, hoadon.soluong, hanghoa.dongia, hoadon.tongtien,hoadon.ngaylap, Khachhang.sodt FROM hoadon JOIN  Khachhang ON hoadon.makh = Khachhang.makh JOIN hanghoa ON hoadon.mahh = hanghoa.mahh WHERE  Khachhang.makh =@makh";
        //            using (SqlCommand cmd = new SqlCommand(query, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@MaHH", ChonHH);

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        // Read values from the data reader

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi Khi load Giá: " + ex.Message);
        //        }
        //        finally
        //        {
        //            cn.Close();
        //        }
        //    }
        //}
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                try
                {
                    cn.Open();

                    string ChonHH = comboBox2.SelectedValue.ToString();

                   // string query = "SELECT hoadon.mahd, Khachhang.makh, Khachhang.tenkh, hanghoa.tenhh, hoadon.soluong, hanghoa.dongia, hoadon.tongtien, hoadon.ngaylap, Khachhang.sodt FROM hoadon JOIN Khachhang ON hoadon.makh = Khachhang.makh JOIN hanghoa ON hoadon.mahh = hanghoa.mahh WHERE Khachhang.makh = @makh";
                    string query1 = "select tenkh from khachhang where makh=@makh";
                    using (SqlCommand cmd = new SqlCommand(query1, cn))
                    {
                        cmd.Parameters.AddWithValue("@makh", ChonHH);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                txtTenKH.Text = reader["tenKH"].ToString();


                            }
                            else
                            {
                                txtTenKH.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Khi load Giá: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // LoadHDKH();
            if (comboBox2.SelectedItem != null)
            {
                try
                {
                    cn.Open();

                    string ChonHH = comboBox2.SelectedValue.ToString();

                    // Assuming 'rp' is an instance of your Crystal Report
                    CryXuatHD_Ban rp = new CryXuatHD_Ban();

                    string query = "SELECT hoadon.mahd, Khachhang.makh, Khachhang.tenkh, hanghoa.tenhh, hoadon.soluong, hanghoa.dongia, hoadon.tongtien, hoadon.ngaylap, Khachhang.sodt FROM hoadon JOIN Khachhang ON hoadon.makh = Khachhang.makh JOIN hanghoa ON hoadon.mahh = hanghoa.mahh WHERE Khachhang.makh = @makh";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@makh", ChonHH);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);


                            rp.SetDataSource(dt);
                        }
                    }


                    crystalReportViewer1.ReportSource = rp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Khi load Giá: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
