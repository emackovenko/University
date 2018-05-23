using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;
using System.Collections.ObjectModel;

namespace University.ViewModel.Payline
{
    public class StudentViewModel: ViewModelBase
    {

        public StudentViewModel(Student student)
        {
            Student = student;
        }

        public Student Student { get; set; }

        public IEnumerable<IdentityDocumentType> IdentityDocumentTypes
        {
            get => Context.IdentityDocumentTypes;
        }
    }
}
