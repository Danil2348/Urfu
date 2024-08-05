using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models
{
    public class Institute // институт
    {
        [Key]
        public Guid uuid { get; set; } // индефикатор
        public string title { get; set; } // название
        public ICollection<EducationalProgram> EducationalPrograms { get; set; } // список ОП
        public Institute()
        {
            uuid = Guid.NewGuid();
        }
    }
}
