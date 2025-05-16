/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/



using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortalGUI
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=.;Initial Catalog=JobPortalDB_New;Integrated Security=True";

        // Method to open a database connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Method to execute a non-query (e.g., INSERT, UPDATE, DELETE) with parameters
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Method to execute a query and return a result (e.g., SELECT) without parameters
        public SqlDataReader ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand(query, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        // Method to close the connection if necessary
        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
