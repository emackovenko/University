using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data.University;
using Microsoft.EntityFrameworkCore;

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

            var desktop = new MainWindow();
            desktop.ShowDialog();
            App.Current.Shutdown();
        }
    }
}
