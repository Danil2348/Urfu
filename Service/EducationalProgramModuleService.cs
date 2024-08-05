using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;
using Urfu.Repository;

namespace Urfu.Service
{
    public class EducationalProgramModuleService: IEducationalProgramModuleService // класс реализующий интерфейс сервиса привязки модуля с ОП
    {
        private readonly IEducationalProgramModuleRepository _educationalProgramModuleRepository;
        private readonly IEducationalProgramRepository _educationalProgramRepository;
        private readonly IModuleRepository _moduleRepository;

        public EducationalProgramModuleService(IEducationalProgramModuleRepository educationalProgramModuleRepository, IEducationalProgramRepository educationalProgramRepository, IModuleRepository moduleRepository) // подключение хранилища привязки модуля с ОП, хранилища ОП, хранилища модулей
        {
            _educationalProgramModuleRepository = educationalProgramModuleRepository;
            _educationalProgramRepository = educationalProgramRepository;
            _moduleRepository = moduleRepository;
        }

        public bool CreateEducationalProgramModule(Guid uuidM, Guid uuidEP) // реализация метода создания новой привязки модуля с ОП
        {
            if (!_educationalProgramRepository.EducationProgramExists(uuidEP) ||
                !_moduleRepository.ModuleExists(uuidM)) // проверка существования ОП и модуля
                return false;
            var educationalProgramModule = new EducationProgramModule // создание новой привязки модуля с ОП
            {
                EducationalProgram = _educationalProgramRepository.GetEducationalProgram(uuidEP),
                Module = _moduleRepository.GetModule(uuidM)
            };
            return _educationalProgramModuleRepository.CreateEducationalProgramModule(educationalProgramModule); // возвращение результата добавления новой привязки модуля с ОП
        }

        public bool EducationalProgramModuleAny(Guid uuidM, Guid uuidEP) // реализация метода поверки существующей привязки модуля с ОП
        {
            return _educationalProgramModuleRepository.GetEducationalProgramModules().Any(epm => epm.EducationProgramId == uuidEP && epm.ModuleId == uuidM); // возращение булевского значения в зависимости существования привязки модуля с ОП
        }
    }
}
