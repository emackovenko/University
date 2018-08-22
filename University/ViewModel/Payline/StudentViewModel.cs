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

        public RelayCommand EditContractCommand { get => new RelayCommand(EditContract); }

        void EditContract()
        {
            var vm = new ContractViewModel(SelectedContract);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                SelectedContract.Save();
                RaisePropertyChanged("SelectedContract");
            }
        }

        public RelayCommand AddStudentNameChangingAgreementCommand { get => new RelayCommand(AddStudentNameChangingAgreement); }
        
        void AddStudentNameChangingAgreement()
        {
            var agreement = new StudentNameChangingAgreement
            {
                ContractId = SelectedContract.Id
            };
            var vm = new StudentNameChangingAgreementViewModel(agreement);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                //Context.StudentNameChangingAgreements.Add(agreement);
                agreement.Save();
            }
        }


        public RelayCommand AddPriceChangingAgreementCommand { get => new RelayCommand(AddPriceChangingAgreement); }

        void AddPriceChangingAgreement()
        {
            var agreement = new PriceChangingAgreement
            {
                ContractId = SelectedContract.Id
            };
            var vm = new PriceChangingAgreementViewModel(agreement);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                //Context.PriceChangingAgreements.Add(agreement);
                agreement.Save();
            }
        }


        public RelayCommand AddContractTerminationAgreementCommand { get => new RelayCommand(AddContractTerminationAgreement); }

        void AddContractTerminationAgreement()
        {
            var agreement = new ContractTerminationAgreement
            {
                ContractId = SelectedContract.Id
            };
            var vm = new ContractTerminationAgreementViewModel(agreement);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                //Context.ContractTerminationAgreements.Add(agreement);
                agreement.Save();
                SelectedContract.IsActive = false;
                SelectedContract.Save();
                RaisePropertyChanged("SelectedContract");
            }
        }


        public RelayCommand AddContractTerminationWithObligationAgreementCommand { get => new RelayCommand(AddContractTerminationWithObligationAgreement); }

        void AddContractTerminationWithObligationAgreement()
        {
            var agreement = new ContractTerminationWithObligationAgreement
            {
                ContractId = SelectedContract.Id
            };
            var vm = new ContractTerminationWithObligationAgreementViewModel(agreement);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                //Context.ContractTerminationWithObligationAgreements.Add(agreement);
                agreement.Save();
                SelectedContract.IsActive = false;
                SelectedContract.Save();
                RaisePropertyChanged("SelectedContract");
            }
        }

        public RelayCommand PrintContractCommand { get => new RelayCommand(PrintContract); }

        void PrintContract()
        {
            var doc = new Documents.ContractDocument(SelectedContract);
            ViewService.ViewInvoker.ShowDocument(doc);
        }


        public RelayCommand AddContragentChangingAgreementCommand { get => new RelayCommand(AddContragentChangingAgreement); }

        void AddContragentChangingAgreement()
        {
            var agreement = new ContragentChangingAgreement()
            {
                Contract = SelectedContract,
                OldContragent = SelectedContract.Contragent
            };
            var vm = new ContragentChangingAgreementViewModel(agreement);
            if (ViewService.ViewInvoker.ShowEditorWindow(vm))
            {
                if (agreement.NewContragentId != -1)
                {
                    agreement.NewContragent.Save();
                    agreement.NewContragentId = agreement.NewContragent.Id;
                    agreement.Save();
                }
            }
        }

    }
}
