using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastDemo.Services;

namespace FastDemo.ViewModels;

public partial class ValidateWinodwViewModel : ObservableObject
{
    private Simulator _simulator;

    [ObservableProperty]
    private string? _fullName = "Здесь будет ваше ФИО";

    public ValidateWinodwViewModel(Simulator simulator)
    {
        _simulator = simulator;
    }

    [RelayCommand]
    public async Task Generate()
    {
        try
        {
            FullName = await _simulator.GetFullName();
        }
        catch
        {
            MessageBox.Show("Не удалось получить данные из симуялтора. Проверьте его доступность.");
        }
    }

    [RelayCommand]
    public void Validate()
    {
        string? text = FullName;
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Введите давнные, не наглейте.");
            return;
        }

        foreach (char item in text)
            if (!(char.IsLetter(item) || item == ' '))
            {
                MessageBox.Show("ФИО содержит запрещённый символ!", "Ошибка валидации");
                break;
            }

        MessageBox.Show("Проверка прошла успешно", "Валидация");
    }
}