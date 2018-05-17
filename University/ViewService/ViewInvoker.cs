using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.ViewModel;

namespace University.ViewService
{
    public static class ViewInvoker
    {
        public static bool ShowSimpleWindow(ViewModelBase dataContext)
        {
            var viewer = new ViewerWindow(dataContext);
            viewer.controlArea.Visibility = System.Windows.Visibility.Collapsed;
            return viewer.ShowDialog() ?? false;
        }

        public static bool ShowEditorWindow(ViewModelBase dataContext)
        {
            var viewer = new ViewerWindow(dataContext);
            return viewer.ShowDialog() ?? false;
        }
    }
}
