using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dal
{
    public class DBHelper
    {
        private static DBHelper _Instance;
        public SqlConnection sqlcon = null;

        public DBHelper(string s)
        {
            sqlcon = new SqlConnection(s);
        }

        public static DBHelper getInStance
        {
            get
            {
                if (_Instance == null)             
                    _Instance = new DBHelper(@"Data Source=DESKTOP-M4UKRGH\SQLEXPRESS01;Initial Catalog=QLSV_bt4;Integrated Security=True");
                    return _Instance;
            }
            private set
            {

            }
        }

        public DataTable getInrecord(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter(query, sqlcon);

            sqlcon.Open();
            sqladapter.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public void ExectuteNonQuery(string query)
        {

            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        public void ExecuteNonQuery(string query, SqlParameter[] list)
        {
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);

            if (list != null)
            {
                sqlcmd.Parameters.AddRange(list);
            }
            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

        }
        public DataTable getInfo(string query, SqlParameter[] list)
        {
            DataTable dt = new DataTable();
            // thuc thu truy van 
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            if (list != null)
            {
                cmd.Parameters.AddRange(list);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            sqlcon.Open();
            adapter.Fill(dt);
            sqlcon.Close();
            return dt;
        }
    }
}
