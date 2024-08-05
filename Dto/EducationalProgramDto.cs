using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;
using Urfu.Models.Enum;

namespace Urfu.Dto
{
    public class EducationalProgramDto // ОП для вывода 
    {
        public Guid uuid { get; set; } // индефикатор
        public string title { get; set; } // название
        public string cycher { get; set; } // шифр
        public string level { get; set; } // название уровня обучения
        public string standart { get; set; } // название стандарта обучения
        public string institute { get; set; } // название интситута
        public string head { get; set; } // полное имя ответственного лица
        public string accreditationTime { get; set; } // дата следующей аккредитации
    }
}
