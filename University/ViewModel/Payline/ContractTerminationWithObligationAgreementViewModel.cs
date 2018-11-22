using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class ContractTerminationWithObligationAgreementViewModel: ViewModelBase
    {
        public ContractTerminationWithObligationAgreementViewModel(ContractTerminationWithObligationAgreement agreement)
        {
            Agreement = agreement;
        }

        public ContractTerminationWithObligationAgreement Agreement { get; set; }
    }
}
