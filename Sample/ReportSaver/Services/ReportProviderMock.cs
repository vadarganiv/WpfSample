using System;
using ReportSaver.Models;

namespace ReportSaver.Services
{
    public class ReportProviderMock : IReportProvider
    {
        public Report GetReport()
        {
            Random rnd = new Random();
            return new Report()
            {
                Lost = rnd.Next(300),
                Produced = rnd.Next(300),
                Purchased = rnd.Next(300),
                Rejected = rnd.Next(300),
                Returned = rnd.Next(300),
                Sales = rnd.Next(300)
            };
        }
    }
}
