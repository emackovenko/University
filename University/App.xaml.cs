using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data.University;
using Microsoft.EntityFrameworkCore;
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

            var authWindow = new AuthWindow();
            authWindow.ShowDialog();

            var desktop = new MainWindow();
            MainWindow = desktop;
            desktop.ShowDialog();
            App.Current.Shutdown();
        }
    }
}
