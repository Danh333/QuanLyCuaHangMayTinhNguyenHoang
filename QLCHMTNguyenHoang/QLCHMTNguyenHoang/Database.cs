using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHMTNguyenHoang
{
    internal class Database
    {
        SqlConnection sqlconn;
        SqlDataAdapter da;
        DataSet ds;
        public Database(string srvname, string dbName)
        {
            string cnnstr = "Data source =" + srvname + "; Initial Catalog =" + dbName + "; Integrated Security = true ";
            sqlconn = new SqlConnection(cnnstr);
        }

        public string Dlookup(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlconn);
            da.Fill(dt);
            string data = dt.Rows[0][0].ToString();
            return data;
        }

        public DataTable Execute(string sqlstr)
        {
            da = new SqlDataAdapter(sqlstr, sqlconn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExcuteNoQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlconn);
            sqlconn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}
