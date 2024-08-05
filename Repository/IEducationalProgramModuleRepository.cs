using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IEducationalProgramModuleRepository // интерфейс хранилища привязки модуля с ОП
    { 
        ICollection<EducationProgramModule> GetEducationalProgramModules(); // метод получения списка привязок модуля с ОП
        bool CreateEducationalProgramModule(EducationProgramModule educationProgramModule); // добавление новой привязки модуля с ОП
        bool Save(); // метод сохрание данных
    }
}
