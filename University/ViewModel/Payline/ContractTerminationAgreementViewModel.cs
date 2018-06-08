using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class ContractTerminationAgreementViewModel: ViewModelBase
    {
        public ContractTerminationAgreementViewModel(ContractTerminationAgreement agreement)
        {
            Agreement = agreement;
        }


        public ContractTerminationAgreement Agreement { get; set; }
    }
}
