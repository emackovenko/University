using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class StudentNameChangingAgreementViewModel: ViewModelBase
    {
        public StudentNameChangingAgreementViewModel(StudentNameChangingAgreement agreement)
        {
            Agreement = agreement;
        }

        public StudentNameChangingAgreement Agreement { get; set; }

        public IEnumerable<StudentNameChangingOrder> StudentNameChangingOrders
        {
            get
            {
                var student = Agreement.Contract?.Student;
                if (student != null)
                {
                    return Context.StudentNameChangingOrders.Where(o => o.StudentId == student.Id);
                }
                return null;
            }
        }
    }
}
