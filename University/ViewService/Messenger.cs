using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace University.ViewService
{
    public static class Messenger
    {
        public static MessageBoxResult YesNoMessage(string messageText)
        {
            return MessageBox.Show(messageText);
        }
    }
}
