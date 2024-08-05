using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Models;
using Urfu.Repository;
using Urfu.Helper;
using Urfu.Models.Enum;

namespace Urfu.Service
{
    public class EducationalProgramService: IEducationalProgramService // // класс реализующий интерфейс сервиса ОП
    {
        private readonly IEducationalProgramRepository _educationProgramRepository;
        private readonly IMapper _mapper;
        private readonly IInstituteRepository _instituteRepository;
        private readonly IHeadRepository _headRepository;
        private readonly IModuleRepository _moduleRepository;

        public EducationalProgramService(IEducationalProgramRepository educationProgramRepository, IMapper mapper, IInstituteRepository instituteRepository, IHeadRepository headRepository, IModuleRepository moduleRepository) // подключение сервиса ОП, mapper, хранилища институтов, хранилища ответственных лиц, хранилища модулей
        {
            _educationProgramRepository = educationProgramRepository;
            _mapper = mapper;
            _instituteRepository = instituteRepository;
            _headRepository = headRepository;
            _moduleRepository = moduleRepository;
        }

        public bool CreateEducationalProgram(EducationalProgramAddDto educationalProgramAddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuidM) // реализация метода добавления нового ОП
        {
            if (!_instituteRepository.InstituteExists(uuidIn) ||
               !_headRepository.HeadExists(uuidHe) ||
               !_moduleRepository.ModuleExists(uuidM)) // проверка существует ли данный институ, ответсвенное лицо и модуль
                return false;
            var educationalProgram = _mapper.Map<EducationalProgram>(educationalProgramAddDto); // преобразование EducationalProgramAddDto в EducationalProgram
            educationalProgram.level = level; // указание уровня обучения 
            educationalProgram.standart = standart; // указание стандарта обучения
            educationalProgram.institute = _instituteRepository.GetInstitute(uuidIn); // указание института
            educationalProgram.head = _headRepository.GetHead(uuidHe); // указание ответсвеннго лица
            return _educationProgramRepository.CreateEducationalProgram(educationalProgram, uuidM); // возвращение результата добавления ОП
        }

        public bool DeleteEducationalProgram(Guid uuid) // реализация метода удаления ОП
        {
            return _educationProgramRepository.DeleteEducationalProgram(_educationProgramRepository.GetEducationalProgram(uuid)); // возвращение результата удаления ОП
        }

        public bool EducationProgramExists(Guid uuid) // метод получения булевского значения по интефикатору
        {
            return _educationProgramRepository.EducationProgramExists(uuid);  // получение результата проверки существования данного ОП
        }

        public EducationalProgramDto GetEducationProgram(Guid uuid) // реализация метода получения ОП по индефикатору
        {
            var educationalProgram = _educationProgramRepository.GetEducationalProgram(uuid); // нахождение ОП по индефикатору
            var educationalProgramDto = _mapper.Map<EducationalProgramDto>(educationalProgram); // преобразование EducationalProgram в EducationalProgramDto
            educationalProgramDto.level = educationalProgram.level.GetDescription(); // указания названия уровня обучения, взятое из его описания
            educationalProgramDto.standart = educationalProgram.standart.GetDescription(); // указания названия стандарта обучения, взятое из его описания
            educationalProgramDto.institute = _instituteRepository.GetInstitute(educationalProgram.intstituteId).title; // указания название института
            educationalProgramDto.head =_headRepository.GetHead(educationalProgram.headId).fullname; // указания полного имени ответсвенного лица
            return educationalProgramDto; // возвращение полученного ОП
        }

        public ICollection<EducationalProgramDto> GetEducationPrograms() // реализация метода получения списка ОП
        {
            var educationalProgram = _educationProgramRepository.GetEducationalPrograms().ToList(); // получение списка ОП
            var educationalProgramDto= _mapper.Map<ICollection<EducationalProgramDto>>(educationalProgram).ToList(); // преобразование списка ОП из EducationalProgram в EducationalProgramDto 
            for (int i = 0; i < educationalProgramDto.Count; i++)
            {
                educationalProgramDto[i].level = educationalProgram[i].level.GetDescription(); // для всех ОП указание названия уровня обучения, взятое из его описания
                educationalProgramDto[i].standart = educationalProgram[i].standart.GetDescription(); // для всех ОП указание названия стандарта обучения, взятое из его описания
                educationalProgramDto[i].institute = _instituteRepository.GetInstitute(educationalProgram[i].intstituteId).title; // для всех ОП указание название института
                educationalProgramDto[i].head = _headRepository.GetHead(educationalProgram[i].headId).fullname; // для всех ОП указание полного имени ответсвенного лица
            }
            return educationalProgramDto; // возвращение полученного списка ОП
        }

        public ICollection<ModuleDto> GetModulesFromEducationalProgram(Guid uuidEP) // реализация метода получения спика модулей связанных с ОП с данным индефикатором
        {
            return _mapper.Map<ICollection<ModuleDto>>(_educationProgramRepository.GetModulesFromEducationalProgram(uuidEP)); // преобразование списка модулей из Module в ModuleDto связанных с ОП с данным индефикатором
        }

        public bool UpdateEducationalProgram(EducationalProgramAddDto educationalProgramAddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuid) // реализация метода обновления содержимого ОП
        {
            if (!_instituteRepository.InstituteExists(uuidIn) ||
               !_headRepository.HeadExists(uuidHe)) // проверка существования данного института и ответсвенного лица
                return false;
            var educationalProgram = _mapper.Map<EducationalProgram>(educationalProgramAddDto); // преобразование EducationalProgramAddDto в EducationalProgram
            educationalProgram.uuid = uuid; // указание индефикатора
            educationalProgram.level = level; // указание уровня обучения 
            educationalProgram.standart = standart; // указание стандарта обучения 
            educationalProgram.institute = _instituteRepository.GetInstitute(uuidIn); // указание института 
            educationalProgram.head = _headRepository.GetHead(uuidHe); // указание ответственного лица
            return _educationProgramRepository.UpdateEducationalProgram(educationalProgram); // возвращение результата обновления ОП
        }
    }
}
