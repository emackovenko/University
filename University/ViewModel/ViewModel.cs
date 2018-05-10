using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using University.ViewService;
using University.ViewModel.Validation;
using System.Reflection;

namespace University.ViewModel
{
    class MagicAttribute : Attribute { }
    class NoMagicAttribute : Attribute { }

    [Magic]
    public abstract class ViewModelBase: DependencyObject, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<TE>(Expression<Func<TE>> property)
        {
            if (property.Body is MemberExpression propertyMemberExpression)
                RaisePropertyChanged(propertyMemberExpression.Member.Name);
        }

        public bool ShowEditor(ViewModelBase viewModel)
        {
            var editorWindow = new ViewerWindow(viewModel);
            return editorWindow.ShowDialog() ?? false;
        }

        public bool ShowEditor(ViewModelBase viewModel, IEntityValidator validator)
        {
            var editorWindow = new ViewerWindow(viewModel, validator);
            return editorWindow.ShowDialog() ?? false;
        }
    }

    public class RelayCommand : GalaSoft.MvvmLight.Command.RelayCommand
    {
        public RelayCommand(Action execute, bool keepTargetAlive = false) : base(execute, keepTargetAlive)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute, bool keepTargetAlive = false) : base(execute, canExecute, keepTargetAlive)
        {
        }
    }

    /*
    public class RelayCommand<TE> : RelayCommand where TE : class
    {
        public RelayCommand(Action<TE> execute, Predicate<TE> canExecute)
            : base(o => execute(o as TE), o => canExecute(o as TE)) { }
        public RelayCommand(Action<TE> execute)
            : base(o => execute(o as TE)) { }
    }

    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
                _execute(parameter);
        }
    } */

    public class ProtectedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private readonly string _protectedName;

        public ProtectedCommand(string protectedName, Action<object> execute, Predicate<object> canExecute = null)
        {
            _protectedName = protectedName;
            _execute = execute;
            _canExecute = canExecute;
        }

        bool IsAccept()
        {
            return Session.CurrentUser.Role.AvailableCommands.FirstOrDefault(c => c.Command.Name == _protectedName) != null;
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null || _canExecute(parameter) && IsAccept());
        }

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
                _execute(parameter);
        }
    }

}
