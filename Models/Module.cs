using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models
{
    public class Module // модуль
    {
        [Key]
        public Guid uuid { get; set; } // индефикатор
        public string title { get; set; } // название
        public string type { get; set; } // тип модуля
        public ICollection<EducationProgramModule> EducationProgramModules { get; set; } // список привязок модулей с ОП
        public Module()
        {
            uuid = Guid.NewGuid();
        }
    }
}
