﻿using System;
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
using University.ViewModel.Validation;
using System.Reflection;

namespace University.ViewService
{
    /// <summary>
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class ViewerWindow : Window
    {
        public ViewerWindow()
        {
            InitializeComponent();
        }

        public ViewerWindow(object dataContext)
            : this ()
        {
            // TODO: переделать это говно

            DataContext = dataContext;
            
            // предполагаем, что наша МП (модель представления - ViewModel) названа в формате "SomenameViewModel" и находится в ViewModel=>SomeNamespace
            // Ищем вьюху класса UserControl с именем в формате "SomenameView" в View=>SomeNamespace
            string viewName = dataContext.GetType().FullName.Replace("ViewModel", "View");

            // Вызываем ее конструктор
            var viewType = Type.GetType(string.Format("{0}", viewName), false);
            if (viewType == null)
            {
                throw new InvalidOperationException("Не найдено представление для редактирования данной модели.");
            }
            var ci = viewType.GetConstructor(new Type[] { });
            var view = ci.Invoke(new object[] { });

            //встраиваем в грид
            editingArea.Children.Add(view as UIElement);
        }
        
        public ViewerWindow(object dataContext, IEntityValidator validator)
            : this (dataContext)
        {
            _validator = validator;
        }

        IEntityValidator _validator;

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_validator != null)
            {
                if (_validator.IsValid)
                {
                    DialogResult = true;
                }
                else
                {
                    validatorMessagesTextBlock.Visibility = Visibility.Visible;
                    MessageBox.Show("Объект не прошел валидацию. Подробности в списке ошибок.");
                }
            }
            else
            {
                DialogResult = true;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_validator.GetEntityErrors(), "Список ошибок");
        }
    }
}
