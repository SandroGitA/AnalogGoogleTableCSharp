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

        public static string connectionString = $"server = {server}; username = {username}; " +
            $"password = {password}; database = {database}; port = {port}";
        public string connectionStatus = "";

        /// <summary>
        /// Метод для подключения к БД
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ReturnSQLConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

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
    }
}
