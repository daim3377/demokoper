using System.Data.Common;
using EasyDB.Abstractions;
using MySqlConnector;

namespace FastDemo.DataBase;

class DBConnector : IDBConnector
{
    public DbConnection Connect()
        => new MySqlConnection("Server=localhost;User ID=root;Password=student;Database=demoapp");
}
