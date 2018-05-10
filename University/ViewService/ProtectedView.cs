using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace University.ViewService
{
    public static class ProtectedView
    {
        public static readonly DependencyProperty IdentityProperty =
            DependencyProperty.RegisterAttached("Identity", typeof(string), typeof(ProtectedView), new PropertyMetadata(new PropertyChangedCallback(OnIdentityChanged)));
        
        public static void SetIdentity(DependencyObject element, string value)
        {
            element.SetValue(IdentityProperty, value);
        }

        public static string GetIdentity(DependencyObject element)
        {
            return (string)element.GetValue(IdentityProperty);
        }

        private static void OnIdentityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                return;
            }
            string identityName = (string)e.NewValue;
            UIElement element = d as UIElement;
            if (Session.CurrentUser.Role.AvailableViews.FirstOrDefault(v => v.InterfaceElement.Name == identityName) != null)
            {
                element.Visibility = Visibility.Visible;
            }
            else
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
    }
}
