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
    public partial class QuanLiKhachHang : Form
    {
        public QuanLiKhachHang()
        {
            InitializeComponent();
        }
        ConnectCSDL co = new ConnectCSDL();
        public void LoadData()
        {
            co.KetNoi();
            dataGridView1.DataSource = co.GetData("select * from tblKhachhang");
            co.NgatKetNoi();
        }

        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void butthem_Click(object sender, EventArgs e)
        {
            string sqlthem = "insert into tblKhachhang values ('" + txtmakh.Text + "','" + txttenkh.Text
             + "','" + txtghichu.Text + "','" + txtSodt.Text + "','" + txtdiachi.Text + "')";
            co.ThucThi(sqlthem);
            frmkhachhang_Load(sender, e);
        }

        private void butsua_Click(object sender, EventArgs e)
        {
            string sqlsua = "update tblKhachhang set MaKH='" + txtmakh.Text + "',TenKH='" + txttenkh.Text + "',Ghichu = '" + txtghichu.Text
                 + "',Diachi='" + txtdiachi.Text + "',sdt='" + txtSodt.Text + "'where MaKH='" + txtmakh.Text + "'";
            co.ThucThi(sqlsua);
            LoadData();
            frmkhachhang_Load(sender, e);

        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn xóa không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                string sqlxoa = "delete from tblKhachhang where MaKH = '" + txtmakh.Text + "'";
                co.ThucThi(sqlxoa);
            }
        }

        private void butcapnhat_Click(object sender, EventArgs e)
        {

        }

        private void buttrove_Click_1(object sender, EventArgs e)
        {

            QuanLiBanHang trove = new QuanLiBanHang();
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
    }
    }
   


}
