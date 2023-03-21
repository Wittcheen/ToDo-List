using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Database
{
    public partial class Database
    {
        private static Database? instance;
        private static readonly object padlock = new();

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new();
                    return instance;
                }
            }
        }

        /// <summary>
        /// Establishes a connection with the SQL server as a superuser
        /// </summary>
        /// <returns>Returns an SqlConnection object used to communicate with the sql server</returns>
        public static SqlConnection GetDatabaseConnection()
        {
            SqlConnectionStringBuilder sb = new()
            {
                DataSource = "sql.itcn.dk\\TCAA",
                InitialCatalog = "chri36ky2.SKOLE",
                UserID = "chri36ky.SKOLE",
                Password = "password"
            };
            string connectionstring = sb.ToString();
            SqlConnection? connection = new(connectionstring);

            try { connection.Open(); }
            catch (SqlException) { connection = null; }
            return connection;
        }

        /// <summary>
        /// Sends SQL query to the sql database server.
        /// </summary>
        /// <param name="sql">string containing a singe sql query</param>
        private static void ExecuteSqlCommand(string sql)
        {
            using (var connection = GetDatabaseConnection())
            {
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Reads data in the database with a query
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="sql">SQL query to read</param>
        /// <returns>Returns the reader</returns>
        private static SqlDataReader ExecuteReader(SqlConnection connection, string sql)
        {
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
