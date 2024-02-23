using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _57_61_QuanLyBanSach
{
    internal class cls57_61_QuanLyBanSach
    {
        SqlConnection con = new SqlConnection();
        public void ketNoi()
        {
            con.ConnectionString = @"Data source=MSI\SQLEXPRESS;Initial Catalog=QuanLyBanSach;integrated Security=True";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void dongKetNoi()
        {
            con.Close();
        }
        public cls57_61_QuanLyBanSach()
        {
            ketNoi();
        }
        public DataSet layDuLieu(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }

        public int capnhatdulieu(string sql )
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
    }
}
