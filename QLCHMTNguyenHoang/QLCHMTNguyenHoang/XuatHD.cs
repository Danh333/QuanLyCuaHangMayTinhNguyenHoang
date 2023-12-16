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
    public partial class XuatHD : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=whoanhminh\sqlexpress;Initial Catalog=quanli123;Integrated Security=True");
        public XuatHD()
        {
            InitializeComponent();
        }

        private void XuatHD_Load(object sender, EventArgs e)
        {
            string sql = "select * from hoadon ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
           // CrystalReport1 rp = new CrystalReport1();
            //rp.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = rp;
        }
    }
}
