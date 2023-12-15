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
        private void ButtonThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void ButtonTrove_Click(object sender, EventArgs e)
        //{
        //    QuanLyNhanVien trove = new QuanLyNhanVien();
        //    trove.Show();
        //    this.Hide();
        //}

        private void ButtonTrove_Click_1(object sender, EventArgs e)
        {
            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();
        }
    }
}
