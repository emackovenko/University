using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using University.Properties;

namespace University.ViewModel.Common.Auth
{
    public class ConnectionSettingsViewModel: ViewModelBase
    {
        public string Server
        {
            get
            {
                return Settings.Default.Server;
            }
            set
            {
                Settings.Default.Server = value;
            }
        }

        public string Port
        {
            get
            {
                return Settings.Default.Port;
            }
            set
            {
                Settings.Default.Port = value;
            }
        }

        public string Database
        {
            get
            {
                return Settings.Default.DatabaseName;
            }
            set
            {
                Settings.Default.DatabaseName = value;
            }
        }

        public string Charset
        {
            get
            {
                return Settings.Default.Charset;
            }
            set
            {
                Settings.Default.Charset = value;
            }
        }


        public RelayCommand SaveCommand { get => new RelayCommand(Save); }

        public RelayCommand CancelCommand { get => new RelayCommand(Cancel); }

        void Save()
        {
            Settings.Default.Save();
            Messenger.Default.Send<string>("CLOSE");
        }

        void Cancel()
        {
            Settings.Default.Reload();
            Messenger.Default.Send<string>("CLOSE");
        }

    }
}
