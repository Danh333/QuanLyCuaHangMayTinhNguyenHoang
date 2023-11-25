using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
       
        public void LoadData()
        {
           
        }

        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void butthem_Click(object sender, EventArgs e)
        {
            
        }

        private void butsua_Click(object sender, EventArgs e)
        {
           

        }

        private void butxoa_Click(object sender, EventArgs e)
        {
          
        }

        private void butcapnhat_Click(object sender, EventArgs e)
        {

        }

        private void buttrove_Click_1(object sender, EventArgs e)
        {

            QuanLyBanHang trove = new QuanLyBanHang();
            trove.Show();
            this.Hide();

        }

        private void butthoat_Click_1(object sender, EventArgs e)

        {
            this.Close();
        }

        private void buttimkiem_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
