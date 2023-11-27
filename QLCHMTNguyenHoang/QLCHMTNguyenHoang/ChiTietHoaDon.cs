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
    public partial class ChiTietHoaDon : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        void hienthi()
        {
            cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=abc;Integrated Security=True");
            string sql = "select * from hoadon2";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
        }
            private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
