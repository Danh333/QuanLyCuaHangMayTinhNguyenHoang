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
    
    public partial class QuanLiHoaDon : Form
    {
        Database db;
        public QuanLiHoaDon()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuanLiHoaDon_Load(object sender, EventArgs e)
        {
            db = new Database(@"WHOANHMINH\SQLEXPRESS", "QLCUAHANGTHUCAN");
            string sql = "Select distinct Loai from MONAN";
            DataTable dtrow = new DataTable();
            dtrow = db.Execute(sql);
            for (int i = 0; i < dtrow.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = dtrow.Rows[i][0].ToString();
             
                treeView1.Nodes.Add(node);
                string sql1 = "Select Iditem,Name from MONAN where loai like N'" + dtrow.Rows[i][0].ToString() + "%'";
                DataTable dtrow1 = new DataTable();
                dtrow1 = db.Execute(sql1);
                for (int j = 0; j < dtrow1.Rows.Count; j++)
                {
                    TreeNode node1 = new TreeNode();
                    node1.Text = dtrow1.Rows[j][1].ToString();
                    node1.Tag = dtrow1.Rows[j][0].ToString();
                    treeView1.Nodes[i].Nodes.Add(node1);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string iditem = "";

            if (treeView1.SelectedNode.Parent != null)
            {
                iditem = treeView1.SelectedNode.Tag.ToString();
                string monan = treeView1.SelectedNode.Text;
                string sql = "Select Hinhanh from MONAN where Iditem='" + iditem + "'";
                string hinh = db.Dlookup(sql);
                try
                {
                    pictureBox1.Load(hinh);
                }
                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
