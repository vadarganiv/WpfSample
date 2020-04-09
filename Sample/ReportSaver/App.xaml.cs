using Ninject;
using System.Windows;
using System.Windows.Navigation;
using ReportSaver.Modals;
using ReportSaver.Services;
using ReportSaver.ViewModels;
using ReportSaver.Views;

namespace ReportSaver
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
  

        private  IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            container = new StandardKernel();

            container.Bind<MainWindow>().ToConstant(new MainWindow()).InSingletonScope();
            container.Bind<NavigationService>().ToConstant(container.Resolve<MainWindow>().NavigationService).InSingletonScope();
            container.Bind<PageManager>().ToSelf().InSingletonScope();
            //Services
            container.Bind<IReportProvider>().To<ReportProviderMock>();
            container.Bind<ICurrentReport>().To<CurrentReport>().InSingletonScope();
            container.Bind<WindowFactory>().ToSelf().InSingletonScope();
            // ViewModels
            container.Bind<LoginPageViewModel>().ToSelf();
            container.Bind<TablePageViewModel>().ToSelf();
            container.Bind<MainMenuViewModel>().ToSelf();
            container.Bind<ReportsViewModel>().ToSelf();
            container.Bind<TableControlViewModel>().ToSelf();
            container.Bind<EditFieldModalViewModel>().ToSelf();
            container.Bind<HistoryLogViewModel>().ToSelf();
            //Views
            container.Bind<LoginPage>().ToSelf();
            container.Bind<TablePage>().ToSelf();
            container.Bind<MainMenuPage>().ToSelf();
            container.Bind<ReportsView>().ToSelf();
            container.Bind<EditFieldModal>().ToSelf();
            container.Bind<HistoryLogView>().ToSelf();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = container.Resolve<MainWindow>();
            container.Resolve<PageManager>().Navigate<LoginPage>();
        }
    }
}
