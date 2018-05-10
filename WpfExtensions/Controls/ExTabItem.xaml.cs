using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfExtensions.Controls
{
    /// <summary>
    /// Логика взаимодействия для ExTabItem.xaml
    /// </summary>
    public partial class ExTabItem : TabItem
    {
        public ExTabItem()
        {
            InitializeComponent();
        }


        static ExTabItem()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ExTabItem),
                new FrameworkPropertyMetadata("TabItem", new PropertyChangedCallback(OnTitleChanged)));
            IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ExTabItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIconChanged)));
        }
        

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static DependencyProperty TitleProperty;

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string value = (string)e.NewValue;
            ExTabItem parent = (ExTabItem)d;
            parent.Title = value;
        }

        public ImageSource Icon
        {
            get
            {
                return (ImageSource)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public static DependencyProperty IconProperty;

        private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageSource icon = (ImageSource)e.NewValue;
            ExTabItem parent = (ExTabItem)d;
            parent.Icon = icon;
        }

    }
}
