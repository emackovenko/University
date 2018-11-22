using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class ContractPriceAndPeriodChangingViewModel: ViewModelBase
    {
        public ContractPriceAndPeriodChangingViewModel(ContractPriceAndPeriodChangingAgreement agreement)
        {
            Agreement = agreement;
        }

        public ContractPriceAndPeriodChangingAgreement Agreement { get; set; }
    }
}
