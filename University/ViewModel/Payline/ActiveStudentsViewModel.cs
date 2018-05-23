using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;

namespace University.ViewModel.Payline
{
    public class ActiveStudentsViewModel: ViewModelBase
    {
        public ActiveStudentsViewModel()
        {

        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(Context.Students
                    .Where(s => s.StatusId == 1)
                    .Where(s => s.FinanceSourceId == 2)
                    .OrderBy(s => s.FullName));
            }
        }

        public Student SelectedStudent { get; set; }


    }
}
