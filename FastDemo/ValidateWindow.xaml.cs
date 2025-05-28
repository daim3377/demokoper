using System.Windows;
using FastDemo.ViewModels;

namespace FastDemo;

public partial class ValidateWindow : Window
{
    public ValidateWindow(ValidateWinodwViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}
