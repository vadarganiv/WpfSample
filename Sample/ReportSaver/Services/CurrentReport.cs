using ReportSaver.Models;
using ReportSaver.ViewModels;

namespace ReportSaver.Services
{
    public class CurrentReport : NotificationObject, ICurrentReport
    {
        private Report report = new Report();
        public Report Report
        {
            get => report;
            set
            {
                report = value;
                OnPropertyChanged();
            }
        }
    }
}
