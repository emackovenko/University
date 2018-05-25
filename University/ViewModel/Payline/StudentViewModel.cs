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
        public StudentViewModel()
        {

        }

        public StudentViewModel(Student student)
        {
            Student = student;
        }

        #region View Propeties

        public Student Student { get; set; }

        StudentContract _selectedContract;

        public StudentContract SelectedContract
        {
            get
            {
                if (_selectedContract == null)
                {
                    _selectedContract = Student.Contracts.FirstOrDefault();
                }
                return _selectedContract;
            }
            set
            {
                _selectedContract = value;
                RaisePropertyChanged("Agreements");
            }
        }

        public ObservableCollection<AuxAgreement> Agreements
        {
            get => new ObservableCollection<AuxAgreement>(_selectedContract.Agreements);
        }

        #endregion

        #region Navigated collections

        public IEnumerable<IdentityDocumentType> IdentityDocumentTypes
        {
            get => Context.IdentityDocumentTypes;
        }

        #endregion


    }
}
