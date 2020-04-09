using Ninject;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReportSaver.Services
{
    public class PageManager
    {
        private readonly NavigationService _navigationService;
        private readonly IKernel _kernel;
        public PageManager(IKernel kernel, NavigationService navigationService)
        {
            _navigationService = navigationService;
            _kernel = kernel;
        }
     
        public void Navigate<T>() where T : Page
        {
            _navigationService.Navigate(_kernel.Resolve<T>());
        }

    }
}
