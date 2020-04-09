using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ReportSaver.ViewModels;

namespace ReportSaver.Models
{
    public class Report : NotificationObject
    {
        public int Id { get; set; }

        [NotMapped]
        public int this[string propName]
        {
            get => (int)(GetType().GetProperty(propName)?.GetValue(this) ?? 0);
            set => GetType().GetProperty(propName)?.SetValue(this, value);
        }

        private int produced;
        public int Produced
        {
            get => produced;
            set
            {
                produced = value;
                OnPropertyChanged();
            }
        }
        private int rejected;
        public int Rejected
        {
            get => rejected;
            set
            {
                rejected = value;
                OnPropertyChanged();
            }
        }
        private int purchased;
        public int Purchased
        {
            get => purchased;
            set
            {
                purchased = value;
                OnPropertyChanged();
            }
        }
        private int sales;
        public int Sales
        {
            get => sales;
            set
            {
                sales = value;
                OnPropertyChanged();
            }
        }
        private int returned;
        public int Returned
        {
            get => returned;
            set
            {
                returned = value;
                OnPropertyChanged();
            }
        }
        private int lost;
        public int Lost
        {
            get => lost;
            set
            {
                lost = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<ReportLog> Changes { get; set; } = new List<ReportLog>();
    }
}
