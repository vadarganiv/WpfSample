using System;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Input;
using ReportSaver.Models;
using ReportSaver.Services;
using ReportSaver.Views;

namespace ReportSaver.ViewModels
{
    public class LoginPageViewModel : BaseNavigationViewModel
    {
        public ICommand LoginCommand { get; private set; }
        

        private bool passwordInvalid;
        public bool PasswordInvalid
        {
            get => passwordInvalid;
            set
            {
                passwordInvalid = value;
                OnPropertyChanged();
            }
        }

        public string UserName => Environment.UserName;
       
        public LoginPageViewModel(PageManager pageManager) : base(pageManager)
        {
            commandsInit();
        }

        private void commandsInit()
        {
            LoginCommand = new RelayCommand(login);
        }

        private void login(object pswdBox)
        {
            if (pswdBox is PasswordBox pwdBox)
                if (pwdBox.Password == ConfigurationManager.AppSettings[UserName])
                {
                    PageManager.Navigate<MainMenuPage>();
                    PasswordInvalid = false;
                }
                else
                {
                    //Пароль не подходит
                    PasswordInvalid = true;
                }
        }
    }
}
