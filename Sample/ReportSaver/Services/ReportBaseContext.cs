using System.Data.Entity;
using ReportSaver.Models;

namespace ReportSaver.Services
{
    class ReportBaseContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportLog> ReportLogs { get; set; }
        
    }
}
