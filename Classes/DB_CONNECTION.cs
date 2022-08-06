using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DPI.Classes
{
    class DB_CONNECTION
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=pecesool;password=1234;database=dpi");

        //подключение
        public MySqlConnection getConnection
        {
            get
            {
                return connection;
            }
        }

        //open connection
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //close connection
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
