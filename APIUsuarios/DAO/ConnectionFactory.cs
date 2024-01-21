
using MySql.Data.MySqlClient;

public class ConnectionFactory
{
    public static MySqlConnection Build()
    {
        var connectionString = "Server=localhost;Database=Apostila;Uid=root;Pwd=0527lilva;";
        return new MySqlConnection(connectionString);
    }
}

