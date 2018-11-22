using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class OrganizationContragentViewModel: ViewModelBase
    {
        public OrganizationContragentViewModel(OrganizationContragent contragent)
        {
            Contragent = contragent;
        }

        public OrganizationContragent Contragent { get; set; }
    }
}
