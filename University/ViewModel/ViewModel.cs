using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.ViewModel
{
    class MagicAttribute : Attribute { }
    class NoMagicAttribute : Attribute { }

    [Magic]
    public abstract class ViewModelBase: GalaSoft.MvvmLight.ViewModelBase
    {
    }
}
