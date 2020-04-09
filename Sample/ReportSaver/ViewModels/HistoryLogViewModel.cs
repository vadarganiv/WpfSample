using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Input;
using ReportSaver.Models;
using ReportSaver.Services;
using ReportSaver.Views;

namespace ReportSaver.ViewModels
{
    public class HistoryLogViewModel : BaseNavigationViewModel
    {
        public ICommand MainMenuCommand { get; private set; }

        private BindingList<ReportLog> historyLogs;
        public BindingList<ReportLog> HistoryLogs
        {
            get => historyLogs;
            set
            {
                historyLogs = value;
                OnPropertyChanged();
            }
        }

        private void commandsInit()
        {
            MainMenuCommand = new RelayCommand(mainMenuCommand);
        }

        private void mainMenuCommand(object obj)
        {
            PageManager.Navigate<MainMenuPage>();
        }

        public HistoryLogViewModel(PageManager pageManager) : base(pageManager)
        {
            commandsInit();
            using (ReportBaseContext context = new ReportBaseContext())
            {
                context.ReportLogs.Load();
                HistoryLogs = context.ReportLogs.Local.ToBindingList();
            }
        }
    }
}
