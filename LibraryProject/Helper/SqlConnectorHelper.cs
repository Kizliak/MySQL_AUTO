using System.Data;
using System.Data.SqlClient;

namespace GameShopMySqlTest
{
    public class SqlConnectorHelper
    {
        private SqlConnection connection;

        public void ConnectToDataBase()
        {
            connection = new SqlConnection("Server = DESKTOP-G6IS2T2\\SQLEXPRESS; Database = GameStore; Integrated Security = true");
            this.connection.Open();
        }

        public DataTable MakeQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (!query.StartsWith("SELECT")) return null;
            return table;
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}