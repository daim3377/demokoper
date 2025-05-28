using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastDemo.DataBase;

namespace FastDemo.ViewModels;

public partial class LoginWindowViewModel: ObservableObject
{
    private UsersTable _users;

    [ObservableProperty]
    private string? _login;

    [ObservableProperty]
    private string? _password;

    public LoginWindowViewModel(UsersTable users)
    {
        _users = users;
    }

    [RelayCommand]
    public void Auth()
    {
        if (string.IsNullOrWhiteSpace(Login)
         || string.IsNullOrWhiteSpace(Password))
        {
            MessageBox.Show("Введите логин и пароль!", "Ошибка");
            return;
        }

        try
        {
            MessageBox.Show(_users.Test(Login, Password), "Информация");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось подключиться к базе данных!" + ex.Message, "База данных");
        }
    }

    [RelayCommand]
    public void Regen()
    {
        try
        {
            _users.Drop();
            _users.Create();
            _users.Fill();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось подключиться к базе данных!" + ex.Message, "База данных");
        }
    }
}
