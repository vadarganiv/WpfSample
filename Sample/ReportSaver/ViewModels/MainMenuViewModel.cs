using System;
using System.Windows.Input;
using ReportSaver.Models;
using ReportSaver.Services;
using ReportSaver.Views;

namespace ReportSaver.ViewModels
{
    public class MainMenuViewModel : BaseNavigationViewModel
    {
        public ICommand GetReportCommand { get; private set; }
        public ICommand ReportListPageCommand { get; private set; }
        public ICommand HistoryLogsPageCommand { get; private set; }

        private readonly IReportProvider _reportProvider;
        private readonly ICurrentReport _currentReport;

        public MainMenuViewModel(PageManager pageManager, IReportProvider reportProvider, ICurrentReport currentReport) : base(pageManager)
        {
            commandsInit();
            _reportProvider = reportProvider;
            _currentReport = currentReport;
        }
        private void commandsInit()
        {
            GetReportCommand = new RelayCommand(getReportCommand);
            ReportListPageCommand = new RelayCommand(reportListPageCommand);
            HistoryLogsPageCommand = new RelayCommand(historyLogsPageCommand);
        }

        private void historyLogsPageCommand(object obj)
        {
            PageManager.Navigate<HistoryLogView>();
        }

        private void getReportCommand(object obj)
        {
            _currentReport.Report = _reportProvider.GetReport();
           PageManager.Navigate<TablePage>();
        }
        private void reportListPageCommand(object obj)
        {
            PageManager.Navigate<ReportsView>();
        }
    }
}
