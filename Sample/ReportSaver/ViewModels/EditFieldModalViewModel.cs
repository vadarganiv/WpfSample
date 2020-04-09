using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ReportSaver.Models;

namespace ReportSaver.ViewModels
{
    public class EditFieldModalViewModel : NotificationObject, IDataErrorInfo
    {
        private string reason;

        public string Reason
        {
            get { return reason; }
            set
            {
                reason = value;
                OnPropertyChanged();
            }
        }

        private int changingValue;

        public int ChangingValue
        {
            get { return changingValue; }
            set
            {
                changingValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand OkCommand { get;private set; }

        public string Error => throw new System.NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Reason":
                        if (string.IsNullOrEmpty(Reason))
                        {
                            error = "Поле причины не может быть пустое!";
                        }
                        break;
                }
                return error;
            }
        }

        public EditFieldModalViewModel()
        {
            commandInit();
        }

        private void commandInit()
        {
            OkCommand = new RelayCommand(okCommand);
        }

        private void okCommand(object obj)
        {
            if (obj is Window wnd)
            {
                wnd.DialogResult = true;
            }
        }
    }
}
