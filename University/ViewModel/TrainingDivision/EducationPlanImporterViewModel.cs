using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using ResourceLibrary.Properties;
using Data.University;
using System.Collections.ObjectModel;

namespace University.ViewModel.TrainingDivision
{
    public class EducationPlanImporterViewModel: ViewModelBase
    {

        public EducationPlanImporterViewModel()
        {
            AddingObectsPermission = true;
            OpenPlanEditorPermission = true;
            Plan = new EducationPlan();
        }

        #region View props

        public EducationPlan Plan { get; set; }

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

        #region Collections

        public ObservableCollection<Faculty> Faculties
        {
            get => new ObservableCollection<Faculty>(Session.Data.Faculties.ToList());
        }

        public ObservableCollection<Direction> Directions
        {
            get => new ObservableCollection<Direction>(Session.Data.Directions.ToList());
        }

        public ObservableCollection<Cathedra> Cathedras
        {
            get => new ObservableCollection<Cathedra>(Session.Data.Cathedras.ToList());
        }

        public ObservableCollection<EducationForm> EducationForms
        {
            get => new ObservableCollection<EducationForm>(Session.Data.EducationForms.ToList());
        }

        public ObservableCollection<EducationProgramType> EducationProgramTypes
        {
            get => new ObservableCollection<EducationProgramType>(Session.Data.EducationProgramTypes.ToList());
        }





        #endregion

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
            _logText.Clear();
            if (!CanImport())
            {
                return;
            }

            // загрузить файл
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(PlanFileName);

            // шарим узел Документ
            var docNode = xmlDoc.SelectSingleNode("Документ");
            var planNode = docNode.SelectSingleNode("План");
            var titleNode = planNode.SelectSingleNode("Титул");

            // Если имя еще пустое, взять его из документа
            if (string.IsNullOrWhiteSpace(Plan.Name))
            {
                Plan.Name = titleNode.Attributes["ИмяПлана"].Value;
            }



            RaisePropertyChanged("Plan");
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
                Log = "Файл не существует или защищен от чтения.";
                return false;
            }

            // проверка на соответствие формату плана ВО или СПО
            try
            {
                var xmlDoc = XDocument.Load(PlanFileName);
                var xmlSchema = new XmlSchemaSet();
                xmlSchema.Add(null, Extractor.ExtractSchema(Resources.EducationPlanCustomScheme));
                xmlDoc.Validate(xmlSchema, null);
                Log = "Файл соответствует схеме.";
                return true;
            }
            catch (Exception)
            {
                Log = "Файл не соотвествует схеме.";
                return false;
            }
        }

        #endregion

        #endregion
    }
}
