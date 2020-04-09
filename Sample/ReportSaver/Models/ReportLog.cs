using System;

namespace ReportSaver.Models
{
    public class ReportLog
    {
        public int Id { get; set; }

        public string FieldName { get; set; }
        public string Author { get; set; }
        public string Reason { get; set; }
        public int ValueBefore { get; set; }
        public int ValueAfter { get; set; }
        public DateTime Date { get; set; }

        public int? ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
