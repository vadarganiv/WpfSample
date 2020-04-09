using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Input;
using ReportSaver.Models;
using ReportSaver.Services;
using ReportSaver.Views;

namespace ReportSaver.ViewModels
{
    public class ReportsViewModel : BaseNavigationViewModel
    {
        public ICommand MainMenuCommand { get; private set; }
        public ICommand SetCurrentReportCommand { get; private set; }
        private readonly ICurrentReport currentReport;

        private BindingList<Report> reports;
        public BindingList<Report> Reports
        {
            get => reports;
            set
            {
                reports = value;
                OnPropertyChanged();
            }
        }

        private void commandsInit()
        {
            MainMenuCommand = new RelayCommand(mainMenuCommand);
            SetCurrentReportCommand = new RelayCommand(setReport);
        }

        private void setReport(object obj)
        {
            if (obj is Report report)
            {
                currentReport.Report = report;
                PageManager.Navigate<TablePage>();
            }
        }

        private void mainMenuCommand(object obj)
        {
            PageManager.Navigate<MainMenuPage>();
        }

        public ReportsViewModel(PageManager pageManager, ICurrentReport currentReport) : base(pageManager)
        {
            this.currentReport = currentReport;
            commandsInit();
            using (ReportBaseContext context = new ReportBaseContext())
            {
                context.Reports.Load();
                Reports = context.Reports.Local.ToBindingList();
            }
        }
    }
}
