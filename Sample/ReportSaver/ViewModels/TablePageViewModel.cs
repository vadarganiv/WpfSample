using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Windows.Input;
using ReportSaver.Models;
using ReportSaver.Services;
using ReportSaver.Views;

namespace ReportSaver.ViewModels
{
    public class TablePageViewModel : BaseNavigationViewModel
    {
        public ICommand ApproveChangeCommand { get; private set; }
        public ICommand MainMenuCommand { get; private set; }

        public TableControlViewModel TableControlViewModel { get; }

        public TablePageViewModel(PageManager pageManager, TableControlViewModel tableControlViewModel) : base(pageManager)
        {
            TableControlViewModel = tableControlViewModel;
            commandsInit();
        }
        private void commandsInit()
        {
            ApproveChangeCommand = new RelayCommand(approveChangeCommand);
            MainMenuCommand = new RelayCommand(mainMenuCommand);
        }


        private void mainMenuCommand(object obj)
        {
            PageManager.Navigate<MainMenuPage>();
        }

        private async void approveChangeCommand(object obj)
        {
            await Task.Factory.StartNew(() =>
           {
               if (obj is Report report)
               {
                   using (ReportBaseContext kPPContext = new ReportBaseContext())
                   {
                       kPPContext.Reports.AddOrUpdate(report);
                       kPPContext.ReportLogs.AddRange(TableControlViewModel.Changes);
                       TableControlViewModel.Changes.Clear();
                       kPPContext.SaveChanges();
                   }
               }
           });
        }
    }
}
