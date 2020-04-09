using ReportSaver.Models;

namespace ReportSaver.Services
{
    public interface ICurrentReport
    {
        Report Report { get; set; } 
    }
}
