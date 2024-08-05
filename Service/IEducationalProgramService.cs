using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Models;
using Urfu.Models.Enum;

namespace Urfu.Service
{
    public interface IEducationalProgramService // интерфейс сервиса ОП
    {
        ICollection<EducationalProgramDto> GetEducationPrograms(); // метод получения списка ОП
        EducationalProgramDto GetEducationProgram(Guid uuid); // метод получения ОП по индефикатору
        ICollection<ModuleDto> GetModulesFromEducationalProgram(Guid uuidEP); // метод получения спика модулей связанных с ОП с данным индефикатором
        bool EducationProgramExists(Guid uuid); // метод получения булевского значения по интефикатору 
        bool CreateEducationalProgram(EducationalProgramAddDto educationalProgramaddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuidM); // метод добавления нового ОП и создания привязки его с модулем
        bool UpdateEducationalProgram(EducationalProgramAddDto educationalProgramAddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuid); // метод обновления содержимого ОП
        bool DeleteEducationalProgram(Guid uuid); // метод удаления ОП

    }
}
