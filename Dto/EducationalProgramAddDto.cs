using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Dto
{
    public class EducationalProgramAddDto // ОП для добавления в бд
    {
        public string title { get; set; } // название
        public string cycher { get; set; } // шифр
        public string accreditationTime { get; set; } // дата следующей аккредитации
    }
}
