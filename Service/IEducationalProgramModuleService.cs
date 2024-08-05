using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Service
{
    public interface IEducationalProgramModuleService // интерфейс сервиса привязки модуля с ОП
    {
        bool EducationalProgramModuleAny(Guid uuidM, Guid uuidEP); // метод поверки существующей привязки модуля с ОП
        bool CreateEducationalProgramModule(Guid uuidM, Guid uuidEP); // создания новой привязки модуля с ОП
    }
}
