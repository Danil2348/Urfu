using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models
{
    public class Head // ответсвенное лицо 
    {
        [Key]
        public Guid uuid { get; set; } // индефикатор
        public string fullname { get; set; } // полное имя
        public ICollection<EducationalProgram> EducationalPrograms { get; set; } // список ОП
        public Head()
        {
            uuid = Guid.NewGuid();
        }
    }
}
