using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace University.ViewModel.Common.Auth
{
    public class AuthViewModel: ViewModelBase
    {

        public AuthViewModel()
        {
            Login = University.Properties.Settings.Default.Username;
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public RelayCommand EnterCommand
        {
            get => new RelayCommand(Enter);
        }

        public RelayCommand ExitCommand
        {
            get => new RelayCommand(Exit);
        }

        void Enter()
        {
            if (Session.Initialize(Login, Password))
            {
                University.Properties.Settings.Default.Username = Login;
                University.Properties.Settings.Default.Save();
                Messenger.Default.Send("AuthGOOD");
            }
            else
            {
                Messenger.Default.Send("AuthFUCK");
            }
        }

        private bool CanEnter()
        {
            return !(string.IsNullOrWhiteSpace(Login) && string.IsNullOrWhiteSpace(Password));
        }

        void Exit()
        {
            Messenger.Default.Send("AuthEXIT");
        }
    }
}
