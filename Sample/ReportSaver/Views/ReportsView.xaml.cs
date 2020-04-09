using System.Windows.Controls;
using ReportSaver.ViewModels;

namespace ReportSaver.Views
{
    public partial class ReportsView : Page
    {
        public ReportsView(ReportsViewModel reportsViewModel)
        {
            InitializeComponent();
            DataContext = reportsViewModel;
        }
    }
}
