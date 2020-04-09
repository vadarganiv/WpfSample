using System.Windows.Controls;
using ReportSaver.ViewModels;

namespace ReportSaver.Views
{
    public partial class HistoryLogView : Page
    {
        public HistoryLogView(HistoryLogViewModel historyLogViewModel)
        {
            InitializeComponent();
            DataContext = historyLogViewModel;
        }
    }
}
