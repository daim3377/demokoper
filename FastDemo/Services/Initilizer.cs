using EasyDB.Abstractions;
using EasyDB.Extensions;
using FastDemo.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace FastDemo.Services;

public class Initilizer
{
    private IServiceProvider _services;

    public Initilizer(IServiceProvider services)
    {
        _services = services;
    }

    public void Init()
    {
        try
        {
            try
            {
                _services.GetRequiredService<IDataBase>().Write("CREATE DATABASE demoapp");
            }
            catch { }
            //DoWithTables(x => x.Drop());
            DoWithTables(x => x.Create());
            DoWithTables(x => x.Fill());
        }
        catch { }
    }

    public void DoWithTables(Action<IDBTable> action)
    {
        action(_services.GetRequiredService<UsersTable>());
    }
}
