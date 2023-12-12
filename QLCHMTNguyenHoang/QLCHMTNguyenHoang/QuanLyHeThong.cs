using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyHeThong : Form
    {
        public QuanLyHeThong()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        private void QuanLyHeThong_Load(object sender, EventArgs e)
        {

        }
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonTrove_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien trove = new QuanLyNhanVien();
            trove.Show();
            this.Hide();
        }
    }
}
