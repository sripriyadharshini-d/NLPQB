using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryProcessorEngine
{
    public class SqlDAL
    {
        public DataTable GetDatabaseValues(string query, string dbName)
        {
            DataTable dt = new DataTable();
            var connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
            }
            return dt;
        }
    }
}
