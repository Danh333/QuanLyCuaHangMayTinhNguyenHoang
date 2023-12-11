using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLCHMTNguyenHoang
{
    class Database
    {
        SqlConnection cn;
        public Database(string srvname, string dbname)
        {
            string cnnstr = "Data source=" + srvname + ";Initial Catalog=" + dbname + ";Integrated Security=True";
            cn = new SqlConnection(cnnstr);
        }
        public DataTable laydulieu(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }
        public void thucthi(string strsql)
        {
            SqlCommand sqlcmd = new SqlCommand(strsql);
            cn.Open();
            sqlcmd.ExecuteNonQuery();
            cn.Close();

        }
    }
}
