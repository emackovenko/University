using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class PriceChangingAgreementViewModel: ViewModelBase
    {
        public PriceChangingAgreementViewModel(PriceChangingAgreement agreement)
        {
            Agreement = agreement;
        }

        public PriceChangingAgreement Agreement { get; set; }



    }
}
