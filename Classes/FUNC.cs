using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DPI.Classes
{
    class FUNC
    {
        DB_CONNECTION connection = new DB_CONNECTION();

        public Boolean ExecQuery(MySqlCommand command)
        {
            command.Connection = connection.getConnection;

            connection.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
                return true;
            }
        }

        //update

        //delete

        //getdata
        public DataTable getData(MySqlCommand command)
        {
            command.Connection = connection.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }
    }
}
