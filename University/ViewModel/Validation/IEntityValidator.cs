using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.ViewModel.Validation
{
    public interface IEntityValidator
    {
        bool IsValid { get; }

        string GetEntityErrors();
    }
}
