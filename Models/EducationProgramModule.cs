using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models
{
    public class EducationProgramModule //поле привязки ОП с модулем
    {
        public Guid EducationProgramId { get; set; } // индефикатор ОП
        public Guid ModuleId { get; set; } // индефикатор модуля
        public EducationalProgram EducationalProgram { get; set; } // ОП
        public Module Module { get; set; } // модуль
    }
}
