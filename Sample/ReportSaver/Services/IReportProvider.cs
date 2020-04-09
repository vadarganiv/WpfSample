using ReportSaver.Models;

namespace ReportSaver.Services
{
    public interface IReportProvider
    {
        Report GetReport();
    }
}
