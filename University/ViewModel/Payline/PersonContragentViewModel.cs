using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class PersonContragentViewModel: ViewModelBase
    {
        public PersonContragentViewModel(PersonContragent contragent)
        {
            Contragent = contragent;
        }

        public PersonContragent Contragent { get; set; }
    }
}
