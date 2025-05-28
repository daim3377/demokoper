using EasyDB.Abstractions;
using EasyDB.Extensions;

namespace FastDemo.DataBase;

public class UsersTable : IDBTable
{
    private IDataBase _db;

    public UsersTable(IDataBase db)
    {
        _db = db;
    }

    public void Create() => _db.Write(@"CREATE TABLE users(
    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    login VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(100) NOT NULL,
    login_attempts INT NOT NULL DEFAULT 0,
    last_login DATE DEFAULT NULL
)");

    public void Drop() => _db.Write("DROP TABLE IF EXISTS users");

    public void Register(string login, string password)
        => _db.Write($"INSERT INTO users(login, password) VALUES ('{login}', '{password}')");

    private (int id, string password, int login_attempts, DateTime? last_login)? Get(string login)
        => _db.ReaderWrapper<(int,string, int, DateTime?)?>($"SELECT id, password, login_attempts, last_login FROM users WHERE login = '{login}'",
            reader => reader.Read() ? (
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2),
                reader.IsDBNull(3) ? null : reader.GetDateTime(3)
            ) : null);

    public string Test(string login, string password)
    {
        (int id, string password, int login_attempts, DateTime? last_login)? user = Get(login);

        if (user is null)
            return "Неверный логин или пароль";

        if (user.Value.password == password)
        {
            if (user.Value.login_attempts > 3 || (user.Value.last_login.HasValue && (DateTime.Today - user.Value.last_login.Value).TotalDays > 30))
                return "Вы заблокированы. Обратитесь системному администратору";

            _db.Write($"UPDATE users SET login_attempts = 0, last_login = '{DateTime.Today:yyyy-MM-dd}' WHERE id = {user.Value.id}");
            return "Вход успешен";
        }

        _db.Write($"UPDATE users SET login_attempts = login_attempts + 1 WHERE id = {user.Value.id}");
        return "Неверный логин или пароль";
    }

    public void Fill()
    {
        Register("admin", "super");
        Register("manager", "owner");
    }
}
