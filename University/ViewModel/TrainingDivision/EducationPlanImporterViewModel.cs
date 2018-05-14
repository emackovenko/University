using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace University.ViewModel.TrainingDivision
{
    public class EducationPlanImporterViewModel: ViewModelBase
    {
        public EducationPlanImporterViewModel()
        {
            AddingObectsPermission = true;
            OpenPlanEditorPermission = true;
        }

        #region View props

        public string PlanFileName { get; set; }

        public bool AddingObectsPermission { get; set; }

        public bool OpenPlanEditorPermission { get; set; }
        
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

        public RelayCommand ImportCommand { get => new RelayCommand(Import); }

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

        void Import()
        {

        }

        #region Inner logic

        bool ValidateFileByScheme()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Checks

        bool CanImport()
        {
            // проверка на наличие файла
            if (!File.Exists(PlanFileName))
            {
                return false;
            }

            // проверка на соответствие формату плана ВО или СПО


            return false;
        }

        #endregion

        #endregion
    }
}
