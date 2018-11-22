using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class ContractViewModel : ViewModelBase
    {
        public ContractViewModel(StudentContract contract)
        {
            Contract = contract;
        }

        public StudentContract Contract { get; set; }
    }
}
