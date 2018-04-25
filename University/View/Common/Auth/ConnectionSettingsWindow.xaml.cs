using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace University.View.Common.Auth
{
    /// <summary>
    /// Логика взаимодействия для ConnectionSettingsWindow.xaml
    /// </summary>
    public partial class ConnectionSettingsWindow : Window
    {
        public ConnectionSettingsWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, CloseRecieving);
        }

        void CloseRecieving(string message)
        {
            Close();
        }
    }
}
