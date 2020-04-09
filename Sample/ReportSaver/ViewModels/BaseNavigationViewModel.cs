using ReportSaver.Services;

namespace ReportSaver.ViewModels
{
    public abstract class BaseNavigationViewModel : NotificationObject
    {
        protected readonly PageManager PageManager;

        protected BaseNavigationViewModel(PageManager pageManager)
        {
            PageManager = pageManager;
        }
    }
}
