using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Contingent
{
    public class ActiveStudentsViewModel: ViewModelBase
    {
        public ObservableCollection<Student> Students
        {
            get
            {
                return null;// new ObservableCollection<Student>(Context.Students.Where(s => s.StatusId == 1).OrderBy(s => s.FullName).OrderBy(s => s.Course).OrderBy(s => s.Group.Name));
            }
        }
    }
}
