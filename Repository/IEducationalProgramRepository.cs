using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IEducationalProgramRepository // интерфейс хранилища ОП
    {
        ICollection<EducationalProgram> GetEducationalPrograms(); // метод получения списка ОП
        EducationalProgram GetEducationalProgram(Guid uuid); // метод получения ОП по индефикатору
        ICollection<Module> GetModulesFromEducationalProgram(Guid uuidEP); // метод получения спика модулей связанных с ОП с данным индефикатором
        bool EducationProgramExists(Guid uuid); // метод получения булевского значения по интефикатору 
        bool DeleteEducationalProgram(EducationalProgram educationalProgram); // метод удаления ОП
        bool UpdateEducationalProgram(EducationalProgram educationalProgram); // метод обновления содержимого ОП
        bool CreateEducationalProgram(EducationalProgram educationalProgram, Guid uuidM); // метод добавления нового ОП и создания привязки его с модулем
        bool Save(); // метод сохрание данных
    }
}
