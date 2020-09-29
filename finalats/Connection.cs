using System.Data.SqlClient;

namespace finalats
{
    class Connection
    {
        public SqlConnection thisConnection = new SqlConnection("Data Source=DESKTOP-EF9DLAS;Initial Catalog=finalat;Integrated Security=True");
    }
}
