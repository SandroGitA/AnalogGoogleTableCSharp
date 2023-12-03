using MySql.Data.MySqlClient;

namespace AnalogGoogleTableCSharp.Controllers

{
    /// <summary>
    /// Подключение к базе данных
    /// </summary>
    public class SQLConnect
    {
        public string username;
        public string password;

        public string server = "localhost";
        public string database_name = "DataTable";
        public int port;

        public string conncetionString = "";
        public string connectrionStatus = "";

        /// <summary>
        /// Конструктор
        /// </summary>
        SQLConnect() { }

        /// <summary>
        /// Метод для подключения к БД
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ReturnSQLConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conncetionString);
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception e)
            {
                connectrionStatus = e.Message;
            }

            return mySqlConnection;
        }
    }
}
