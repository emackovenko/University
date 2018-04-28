using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DialogService;
using University.ViewModel.Validation;

namespace University.ViewModel
{
    class MagicAttribute : Attribute { }
    class NoMagicAttribute : Attribute { }

    [Magic]
    public abstract class ViewModelBase: GalaSoft.MvvmLight.ViewModelBase
    {
        public bool ShowEditor(ViewModelBase viewModel)
        {
            var editorWindow = new EditorWindow(viewModel);
            return editorWindow.ShowDialog() ?? false;
        }

        public bool ShowEditor(ViewModelBase viewModel, IEntityValidator validator)
        {
            var editorWindow = new EditorWindow(viewModel, validator);
            return editorWindow.ShowDialog() ?? false;
        }
    }
}
