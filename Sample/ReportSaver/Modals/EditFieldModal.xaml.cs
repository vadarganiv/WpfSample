using System.Windows;
using ReportSaver.ViewModels;

namespace ReportSaver.Modals
{
    /// <summary>
    /// Логика взаимодействия для EditFieldModal.xaml
    /// </summary>
    public partial class EditFieldModal : Window
    {
        public EditFieldModal(EditFieldModalViewModel editFieldModalViewModel)
        {
            InitializeComponent();
            DataContext = editFieldModalViewModel;
        }
    }
}
