using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AnalogGoogleTableCSharp.Controllers

{
    /// <summary>
    /// Подключение к базе данных
    /// </summary>
    public class SQLConnect
    {
        public static string username = "skycote";
        public static string password = "SkyCote36";

        public static string server = "192.168.0.5";
        public static string database = "master";
        public static int port = 1433;

        public static string connectionStringMySQL = $"server = {server}; username = {username}; " +
            $"password = {password}; database = {database}; port = {port}";

        public static string connectionStringMSSQL = "Data Source=192.168.0.5;Initial Catalog=agt;" +
            "User ID=skycote; Password=SkyCote36;" +
            "Encrypt=True;Trust Server Certificate=True";

        public string connectionStatus = "";

        /// <summary>
        /// Метод для подключения к БД MySQL
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ReturnMySQLConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionStringMySQL);

            try
            {
                mySqlConnection.Open();
            }
            catch (MySqlException e)
            {
                connectionStatus = e.Message;
            }

            return mySqlConnection;
        }

        /// <summary>
        /// Метод для подключения к БД MSSQL
        /// </summary>
        /// <returns></returns>
        public SqlConnection ReturnSQLConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStringMSSQL);

            try
            {
                sqlConnection.Open();
            }
            catch (SqlException e)
            {
                connectionStatus = e.Message;
            }

            return sqlConnection;
        }
    }
}
