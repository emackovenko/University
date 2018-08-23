using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class AuxAgreementViewModel: ViewModelBase
    {
        public AuxAgreementViewModel(AuxAgreement agreement)
        {
            Agreement = agreement;
        }

        public AuxAgreement Agreement { get; set; }
    }
}
