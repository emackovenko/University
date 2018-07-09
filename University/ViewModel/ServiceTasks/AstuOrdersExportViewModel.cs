using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOk = Data.WorkOk;
using Astu = Data.Astu;

namespace University.ViewModel.ServiceTasks
{
    public class AstuOrdersExportViewModel: ViewModelBase
    {
        StringBuilder _log = new StringBuilder();

        public string Log
        {
            get
            {
                return _log.ToString();
            }
            set
            {
                _log.AppendLine(string.Empty);
                _log.AppendLine(value);
                
            }
        }


        public RelayCommand DoExportCommand { get => new RelayCommand(DoExport); }

        void DoExport()
        {
            _log.Clear();
            Log = "test";
        }

    }
}
