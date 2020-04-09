using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using ReportSaver.Modals;
using ReportSaver.Models;
using ReportSaver.Services;

namespace ReportSaver.ViewModels
{
    public class TableControlViewModel : NotificationObject
    {
        public ICommand OnFieldChangedCommand { get; private set; }

        private readonly ICurrentReport currentReport;
        private readonly WindowFactory _windowFactory;
        public Report Report => currentReport.Report;

        public List<ReportLog> Changes { get; set; } = new List<ReportLog>();

        public TableControlViewModel(ICurrentReport currentReport, WindowFactory windowFactory)
        {
            this.currentReport = currentReport;
            _windowFactory = windowFactory;
            commandInit();
        }

        private void commandInit()
        {
            OnFieldChangedCommand = new RelayCommand(onFieldChange);
        }

        private void onFieldChange(object obj)
        {
            if (obj is TextBlock tb)
            {
                var dialog = _windowFactory.GetInstance<EditFieldModal>();
                if (dialog.ShowDialog() == true)
                {
                    if (dialog.DataContext is EditFieldModalViewModel dataContext)
                    {
                        var expression = tb.GetBindingExpression(TextBlock.TextProperty);
                        if (expression?.ParentBinding != null)
                        {
                            var propertyName = expression.ParentBinding.Path.Path;

                            ReportLog log = new ReportLog()
                            {
                                ReportId = Report.Id,
                                Author = Environment.UserName,
                                Reason = dataContext.Reason,
                                Date = DateTime.Now,
                                FieldName = propertyName,
                                ValueBefore = Report[propertyName],
                                ValueAfter = dataContext.ChangingValue
                            };

                            Changes.Add(log);

                            Report[propertyName] = dataContext.ChangingValue;
                        }
                    }
                }
            }
        }
    }
}
