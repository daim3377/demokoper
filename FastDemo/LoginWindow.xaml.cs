using System.Windows;
using FastDemo.ViewModels;

namespace FastDemo;

public partial class LoginWindow : Window
{
    public LoginWindow(LoginWindowViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}