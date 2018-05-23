using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;
using University.ViewService;

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

        public RelayCommand OpenStudentViewCommand
        {
            get => new RelayCommand(OpenStudentView);
        }

        void OpenStudentView()
        {
            var vm = new StudentViewModel(SelectedStudent);
            if (ViewInvoker.ShowEditorWindow(vm))
            {
                SelectedStudent.Save();
                SelectedStudent.Info.Save();
                RaisePropertyChanged("SelectedStudent");
            }
        }

    }
}
