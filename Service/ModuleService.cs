using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Models;
using Urfu.Repository;

namespace Urfu.Service
{
    public class ModuleService: IModuleService // класс реализующий интерфейс сервиса модулей
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;
        private readonly IEducationalProgramRepository _educationalProgramRepository;

        public ModuleService(IModuleRepository moduleService, IMapper mapper, IEducationalProgramRepository educationalProgramRepository) // подключение сервиса модулей, mapper, хранилища ОП
        {
            _moduleRepository = moduleService;
            _mapper = mapper;
            _educationalProgramRepository = educationalProgramRepository;
        }

        public bool CreateModule(ModuleDto moduleDto, Guid uuidEP) // реализация метода добавления нового модуля
        {
            if (!_educationalProgramRepository.EducationProgramExists(uuidEP)) // проверка существует ли ОП с которой будет связан модуль
                return false;
            var module = _mapper.Map<Module>(moduleDto); // преобразование ModuleDto в Module
            return _moduleRepository.CreateModule(module, uuidEP); // возвращение результата добавления нового модуля
        }

        public bool DeleteModule(Guid uuid) // реализация метода удаления модуля
        {
            return _moduleRepository.DeleteModule(_moduleRepository.GetModule(uuid)); // возвращение результата удаления модуля
        }

        public ModuleDto GetModule(Guid uuid) // реализация метода получения модуля по индефикатору
        {
            return _mapper.Map<ModuleDto>(_moduleRepository.GetModule(uuid)); // преобразование найдего модуля из Module в ModuleDto
        }

        public ICollection<ModuleDto> GetModules() // реализация метода получения списка модулей
        {
            return _mapper.Map<ICollection<ModuleDto>>(_moduleRepository.GetModules()); // преобразование списка модулей из Module в ModuleDto
        }

        public bool ModuleExists(Guid uuid) // метод получения булевского значения по интефикатору
        {
            return _moduleRepository.ModuleExists(uuid); // получение результата проверки существования данного модуля
        }

        public bool UpdateModule(ModuleDto moduleDto, Guid uuid) // реализация метода обновления содержимого модуля
        {
            var module = _mapper.Map<Module>(moduleDto); // преобразование модуля из ModuleDto в Module
            module.uuid = uuid;
            return _moduleRepository.UpdateModule(module); // возвращение результата обновления содержимого модуля
        }
    }
}
