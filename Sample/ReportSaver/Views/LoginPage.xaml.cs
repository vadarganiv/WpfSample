using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ReportSaver.ViewModels;

namespace ReportSaver.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage(LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            DataContext = loginPageViewModel;
        }
    }
}
