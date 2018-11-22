using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WorkOk;
using University.ViewService;

namespace University.ViewModel.Payline
{
    public class ContragentChangingAgreementViewModel: ViewModelBase
    {
        public ContragentChangingAgreementViewModel(ContragentChangingAgreement agreement)
        {
            Agreement = agreement;
        }

        public ContragentChangingAgreement Agreement { get; set; }

        public RelayCommand OpenNewContragentCommand { get => new RelayCommand(OpenNewContragent); }

        void OpenNewContragent()
        {
            if (Agreement.NewContragent != null)
            {
                if (Agreement.NewContragent.GetType() == typeof(PersonContragent) && Agreement.NewContragent.ContragentType == 1)
                {
                    var vm = new PersonContragentViewModel(Agreement.NewContragent as PersonContragent);
                    var agentClone = Agreement.NewContragent.Clone();
                    if (!ViewInvoker.ShowEditorWindow(vm))
                    {
                        Agreement.NewContragent.RestoreFromBackup(agentClone as Entity);
                    }
                }
                else
                {
                    var vm = new OrganizationContragentViewModel(Agreement.NewContragent as OrganizationContragent);
                    var agentClone = Agreement.NewContragent.Clone();
                    if (!ViewInvoker.ShowEditorWindow(vm))
                    {
                        Agreement.NewContragent.RestoreFromBackup(agentClone as Entity);
                    }
                }
            }
            RaisePropertyChanged("Agreement");
        }

        public RelayCommand AddPersonContragentCommand { get => new RelayCommand(AddPersonContragent); }

        void AddPersonContragent()
        {
            if (!CanChangeNewContragent())
            {
                return;
            }

            var agent = new PersonContragent();
            var vm = new PersonContragentViewModel(agent);
            if (ViewInvoker.ShowEditorWindow(vm))
            {
                Agreement.NewContragent = agent;
                Context.PersonContragents.Add(agent);
            }
            RaisePropertyChanged("Agreement");
        }

        bool CanChangeNewContragent()
        {
            if (Agreement.NewContragent == null)
            {
                return true;
            }
            string str = "Это действие приведет к замене текущего значения на новое. Продолжить?";
            return (Messenger.YesNoMessage(str) == System.Windows.MessageBoxResult.Yes);
        }
    }
}
