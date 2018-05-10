using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.University;
using University.ViewService;

namespace University.ViewModel.TrainingDivision
{
    public class EducationPlanListViewModel: ViewModelBase
    {
        #region View props

        public ObservableCollection<EducationPlan> Plans
        {
            get => new ObservableCollection<EducationPlan>(Session.Data.EducationPlans.OrderByDescending(ep => ep.Year));
        }

        public EducationPlan SelectedPlan { get; set; }

        #endregion

        #region Logic

        #region Commands

        public RelayCommand ImportFromXmlCommand
        {
            get => new RelayCommand(ImportFromXml);
        }

        #endregion

        #region Methods

        void ImportFromXml()
        {
            var vm = new EducationPlanImporterViewModel();
            ViewInvoker.ShowSimpleWindow(vm);
        }

        #region Inner logic

        #endregion

        #endregion

        #region Checks

        #endregion

        #endregion
    }
}
