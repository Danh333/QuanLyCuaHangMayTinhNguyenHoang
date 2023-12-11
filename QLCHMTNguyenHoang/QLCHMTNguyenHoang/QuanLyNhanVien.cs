using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLCHMTNguyenHoang
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        Database db;
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void ButtonTrove_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien trove = new QuanLyNhanVien();
            trove.Show();
            this.Hide();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            db = new Database(@"\SQLEXPRESS", "QLCHMTNguyenHoang");
            DataTable dt = new DataTable();
            dt = db.laydulieu("Select * from QLnhanvien");
        }
    }
}
