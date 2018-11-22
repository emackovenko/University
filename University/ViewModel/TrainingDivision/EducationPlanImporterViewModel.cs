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
using Microsoft.EntityFrameworkCore;

namespace University.ViewModel.TrainingDivision
{
    public class EducationPlanImporterViewModel: ViewModelBase
    {

        public EducationPlanImporterViewModel()
        {
            AddingObectsPermission = true;
            OpenPlanEditorPermission = true;
            Plan = new EducationPlan();
            Session.Data.EducationPlans.Add(Plan);
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

            // дергаем циклы
            var cycleNodes = titleNode.SelectSingleNode("АтрибутыЦикловНов").SelectNodes("Цикл");
            foreach (XmlNode cycle in cycleNodes)
            {
                if (string.IsNullOrWhiteSpace(cycle.Attributes["Аббревиатура"]?.Value))
                {
                    continue;
                }

                // Если такого цикла нет в  БД, то создаем
                if (Session.Data.DisciplineCycles.Where(dc => dc.Name == cycle.Attributes["Название"].Value).Count() == 0)
                {
                    var newCycle = new DisciplineCycle
                    {
                        Code = cycle.Attributes["Аббревиатура"].Value,
                        Name = cycle.Attributes["Название"].Value
                    };
                    Session.Data.DisciplineCycles.Add(newCycle);
                    Log = string.Format("Добавлен цикл дисциплин \"{0} - {1}\"",
                        newCycle.Code, newCycle.Name);
                }
            }

            // тянем компетенции
            var competenceNodes = planNode.SelectSingleNode("Компетенции").SelectNodes("Строка");
            foreach (XmlNode comp in competenceNodes)
            {
                if (string.IsNullOrWhiteSpace(comp.Attributes["Индекс"]?.Value))
                {
                    continue;
                }
                if (Session.Data.EducationCompetences.Where(ec => ec.Name == comp.Attributes["Содержание"].Value).Count() == 0)
                {
                    var newComp = new EducationCompetence
                    {
                        Code = comp.Attributes["Индекс"].Value,
                        Name = comp.Attributes["Содержание"].Value
                    };
                    Session.Data.EducationCompetences.Add(newComp);
                    Log = string.Format("Добавлена компетенция {0}", newComp.Code);
                }
            }

            // тащим дисциплины
            var disciplineNodes = planNode.SelectSingleNode("СтрокиПлана").SelectNodes("Строка");
            foreach (XmlNode discipline in disciplineNodes)
            {
                HandleDisciplineXmlNode(discipline);
            }


            RaisePropertyChanged("Plan");
        }

        #region Inner logic

        void HandleDisciplineXmlNode(XmlNode node)
        {
            // Если таковой нет в БД, то добавляем
            var discipline = Session.Data.Disciplines.FirstOrDefault(d => d.Name == node.Attributes["Дис"].Value);
            if (discipline == null)
            {
                discipline = new Discipline
                {
                    Name = node.Attributes["Дис"].Value
                };
                Session.Data.Disciplines.Add(discipline);
                Log = string.Format("Добавлена дисциплина \"{0}\"", discipline.Name);
            }

            string index = node.Attributes["ИдетификаторДисциплины"].Value;

            // создаем элемент учплана
            var planItem = new EducationPlanItem
            {
                Discipline = discipline,
                Cycle = GetCycleByIndex(index),
                Code = index
            };

            Plan.Items.Add(planItem);
            Log = string.Format("Создан элемент учебного плана \"{0} - {1}\"", planItem.Code, planItem.Discipline.Name);

            // тянем графики
            var semesterNodes = node.SelectNodes("Сем");
            foreach (XmlNode semestre in semesterNodes)
            {
                var graphicItem = new EducationPlanGraphic
                {
                    SemesterNo = int.Parse(semestre.Attributes["Ном"].Value),
                    // контроль
                    CreditTest = semestre.Attributes["Зач"]?.Value == "1",
                    DiffCreditTest = semestre.Attributes["ЗачОц"]?.Value == "1",
                    ExaminationTest = semestre.Attributes["Экз"]?.Value == "1",
                    CourseWorkTest = semestre.Attributes["КР"]?.Value == "1",
                    SettlementWorkTest = semestre.Attributes["РГР"]?.Value == "1",
                };



                // часы
                if(double.TryParse(semestre.Attributes["ЗЕТ"]?.Value.Replace('.', ',') ?? semestre.Attributes["ПроектЗЕТ"]?.Value.Replace('.', ','), out double zet))
                {
                    graphicItem.Zet = zet;
                }
                else
                {
                    graphicItem.Zet = 0.0;
                }


                if (int.TryParse(semestre.Attributes["Лек"]?.Value, out int lectionH))
                {
                    graphicItem.LectionHours = lectionH;
                }
                else
                {
                    graphicItem.LectionHours = 0;
                }

                if(int.TryParse(semestre.Attributes["Пр"]?.Value, out int practiceH))
                {
                    graphicItem.PracticeHours = practiceH;
                }
                else
                {
                    graphicItem.PracticeHours = 0;
                }

                if(int.TryParse(semestre.Attributes["Лаб"]?.Value, out int labH))
                {
                    graphicItem.LaboratoryHours = labH;
                }
                else
                {
                    graphicItem.LaboratoryHours = 0;
                }

                if(int.TryParse(semestre.Attributes["СРС"]?.Value, out int independentH))
                {
                    graphicItem.IndependentWorkHours = independentH;
                }
                else
                {
                    graphicItem.IndependentWorkHours = 0;
                }

                planItem.Graphics.Add(graphicItem);
                Log = string.Format("\t Для элемента добавлена информация: {0} семестр", graphicItem.SemesterNo);
            }
        }

        private EducationPlanCompoment GetComponentByIndex(string index)
        {
            string code = index.Split('.')[1];
            return Session.Data.EducationPlanCompoments.FirstOrDefault(dc => dc.Code == code);
        }

        private DisciplineCycle GetCycleByIndex(string index)
        {
            string code = index.Split('.')[0];
            return Session.Data.DisciplineCycles.FirstOrDefault(dc => dc.Code == code);
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
