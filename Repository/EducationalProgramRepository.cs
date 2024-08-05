using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Models;

namespace Urfu.Repository
{
    public class EducationalProgramRepository: IEducationalProgramRepository // класс реализующий интерфейс хранилища ОП
    {
        private readonly DataContext _context;

        public EducationalProgramRepository(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public bool CreateEducationalProgram(EducationalProgram educationalProgram, Guid uuidM) // реализация метода добавления нового ОП и создания привязки его с модулем
        {
            var educationalProgramModule = new EducationProgramModule // привязка нового ОП с модулем найденым по индефикатору
            {
                EducationalProgram = educationalProgram,
                Module = _context.Modules.Where(m => m.uuid == uuidM).FirstOrDefault()
            };
            _context.Add(educationalProgramModule); // добавление новой привязки модуля с ОП
            _context.Add(educationalProgram); // добавление нового ОП
            return Save(); // возвращание результата метода сохранения
        }

        public bool DeleteEducationalProgram(EducationalProgram educationalProgram) // реализация метода удаления ОП
        {
            _context.Remove(educationalProgram); // удаления ОП
            return Save(); // возвращание результата метода сохранения
        }

        public bool EducationProgramExists(Guid uuid) // реализация метода получения булевского значения по интефикатору
        {
            return _context.EducationalPrograms.Any(em => em.uuid == uuid); // проверяем есть ли ОП с данным индефикатором и возращаем булевское значение
        }

        public EducationalProgram GetEducationalProgram(Guid uuid) // реализация метода получения ОП по индефикатору
        {
            return _context.EducationalPrograms.Where(em => em.uuid == uuid).FirstOrDefault();  // находим и возращаем первый ОП по данному индефикатору
        }

        public ICollection<EducationalProgram> GetEducationalPrograms() // реализация метода получения списка ОП
        {
            return _context.EducationalPrograms.ToList(); // возрвращаем список модулей ОП
        }

        public ICollection<Module> GetModulesFromEducationalProgram(Guid uuidEP) // реализация метода получения спика модулей связанных с ОП с данным индефикатором
        {
            return _context.EducationProgramModules.Where(epm => epm.EducationProgramId == uuidEP).Select(m => m.Module).ToList(); // возвращаем полученый список модулей связанных с ОП с данным индефикатором
        }

        public bool Save() // реализация метода сохрание данных
        {
            var saved=_context.SaveChanges(); // сохранение данных
            return saved > 0 ? true : false; // возвращает булевское значение в зависимости были ли сохранения успешными
        }

        public bool UpdateEducationalProgram(EducationalProgram educationalProgram)  // реализация метода обновления содержимого модуля
        {
            _context.Update(educationalProgram); // обновление содержимого модуля
            return Save(); // возвращание результата метода сохранения
        }
    }
}
