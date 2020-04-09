using System.Windows.Controls;
using ReportSaver.ViewModels;

namespace ReportSaver.Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage(MainMenuViewModel mainMenuViewModel)
        {
            InitializeComponent();
            DataContext = mainMenuViewModel;
        }
    }
}
