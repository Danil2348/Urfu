using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Dto
{
    public class ModuleDto // модуль для клиентской части
    {
        public Guid uuid { get; set; } // индефикатор
        public string title { get; set; } // название
        public string type { get; set; } // тип модуля
    }
}
