using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace University.ViewModel.TrainingDivision
{
    public class EducationPlanImporterViewModel: ViewModelBase
    {
        #region View props

        public string PlanFileName { get; set; }

        StringBuilder _logText;

        public string Log
        {
            get
            {
                if (_logText == null)
                {
                    _logText = new StringBuilder();
                }
                return _logText.ToString();
            }
            set
            {
                _logText.AppendLine(value);
            }
        }

        #endregion

        #region Logic

        #region Commands

        public RelayCommand OpenFileCommand { get => new RelayCommand(OpenFile); }

        #endregion

        #region Methods

        void OpenFile()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Файлы XML (*.xml)|*.xml" + "|Все файлы (*.*)|*.* ",
                CheckFileExists = true,
                Multiselect = false
            };
            if (openDialog.ShowDialog() ?? false)
            {
                PlanFileName = openDialog.FileName;
            }
        }

        #region Inner logic

        #endregion

        #endregion

        #region Checks

        #endregion

        #endregion
    }
}
