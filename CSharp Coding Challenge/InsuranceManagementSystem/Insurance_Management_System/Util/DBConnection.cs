using System.Data.SqlClient;

namespace Insurance_Management_System.Util
{
    internal class DBConnection
    {
        private static SqlConnection connection = null;

        public static SqlConnection GetConnection()
        {
            if(connection == null)
            {
                string connectionString = PropertyUtil.GetPropertyString();
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
