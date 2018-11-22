using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data.University;
using Microsoft.EntityFrameworkCore;
using University.View.Common.Auth;
using University.View.Common;

namespace University
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Запуск перехватчика ошибок
            App.Current.DispatcherUnhandledException += (new ExceptionDispatcher()).Handler;
            
            // Регистрация библиотек GemBox
            GemBox.Document.ComponentInfo.SetLicense("DH5L-PTFV-SL2S-5PCN");
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("E43Y-75J1-FTBX-2T9U");

            // Авторизация
            var authWindow = new AuthWindow();            
            if (authWindow.ShowDialog() ?? false)
            {
                var desktop = new DesktopWindow();
                MainWindow = desktop;
                desktop.ShowDialog();
            }

            App.Current.Shutdown();
        }
    }
}
