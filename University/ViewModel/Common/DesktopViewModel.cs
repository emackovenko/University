using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.ViewModel.Common
{
    public class DesktopViewModel: ViewModelBase
    {
        public string UserFullName
        {
            get => string.Format("{0} {1} {2}", Session.CurrentUser.LastName,
                Session.CurrentUser.FirstName, Session.CurrentUser.Patronimyc);
        }
    }
}
