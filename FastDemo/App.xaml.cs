using System.Net.Http;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using EasyDB.Abstractions;
using EasyDB.Services;
using FastDemo.DataBase;
using FastDemo.Services;
using FastDemo.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FastDemo;
public partial class App : Application
{
    private IServiceProvider _services;

    public App()
    {
        _services = new ServiceCollection()
            .AddSingleton<HttpClient>()
            .AddSingleton<Initilizer>()
            .AddSingleton<Simulator>()

            .AddSingleton<IDBConnector, DBConnector>()
            .AddSingleton<IDataBase, OneTimeDatabase>()
            .AddSingleton<UsersTable>()

            .AddSingleton<LoginWindow>()
            .AddSingleton<LoginWindowViewModel>()

            .AddSingleton<ValidateWindow>()
            .AddSingleton<ValidateWinodwViewModel>()
            .BuildServiceProvider();

        Ioc.Default.ConfigureServices(_services);
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _services.GetRequiredService<Initilizer>().Init();
        _services.GetRequiredService<LoginWindow>().Show();
        _services.GetRequiredService<ValidateWindow>().Show();
    }
}
