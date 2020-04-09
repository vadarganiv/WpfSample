using System.Windows.Controls;
using ReportSaver.ViewModels;

namespace ReportSaver.Views
{
    /// <summary>
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public TablePage(TablePageViewModel tablePageViewModel)
        {
            InitializeComponent();
            DataContext = tablePageViewModel;
        }
    }
}
