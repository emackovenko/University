using GalaSoft.MvvmLight.Messaging;
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

namespace University.View.Common.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, MessageHandler);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cs = new ConnectionSettingsWindow();
            cs.ShowDialog();
        }

        void MessageHandler(string message)
        {
            if (message == "AuthGOOD")
            {
                DialogResult = true;
            }
            if (message == "AuthFUCK")
            {
                MessageBox.Show("Не удалось установить соединение. Проверьте параметры подключения и попробуйте заново.");
            }
            if (message == "AuthEXIT")
            {
                DialogResult = false;
            }
        }
    }
}
