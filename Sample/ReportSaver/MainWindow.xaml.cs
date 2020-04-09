using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using ReportSaver.Services;

namespace ReportSaver
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseBack, OnBrowseBack));
            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseForward, OnBrowseForward));
        }

        private void OnBrowseForward(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void OnBrowseBack(object sender, ExecutedRoutedEventArgs e)
        {

        }

    }
}
