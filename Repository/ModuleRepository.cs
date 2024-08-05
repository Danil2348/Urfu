using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Models;

namespace Urfu.Repository
{
    public class ModuleRepository: IModuleRepository // класс реализующий интерфейс хранилища модулей
    {
        private readonly DataContext _context;

        public ModuleRepository(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public bool CreateModule(Module module, Guid uuidEP) // реализация метода добавления нового модуля и создания привязки его с ОП
        {
            var educationalProgramModule = new EducationProgramModule // привязка нового модуля с ОП найденым по индефикатору
            {
                Module = module,
                EducationalProgram = _context.EducationalPrograms.Where(ep => ep.uuid == uuidEP).FirstOrDefault()
            };
            _context.Add(module); // добавление нового модуля
            _context.Add(educationalProgramModule); // добавление новой привязки модуля с ОП
            return Save(); // возвращание результата метода сохранения
        }

        public bool DeleteModule(Module module) // реализация метода удаления модуля
        {
            _context.Remove(module); // удаления модуля
            return Save(); // возвращание результата метода сохранения
        }

        public Module GetModule(Guid uuid) // реализация метода получения модуля по индефикатору
        {
            return _context.Modules.Where(m => m.uuid == uuid).FirstOrDefault(); // находим и возращаем первый модуль по данному индефикатору
        }

        public ICollection<Module> GetModules() // реализация метода получения списка модулей
        {
            return _context.Modules.ToList(); // возрвращаем список модулей
        }

        public bool ModuleExists(Guid uuid) // реализация метода получения булевского значения по интефикатору
        {
            return _context.Modules.Any(m => m.uuid == uuid); // проверяем есть ли модуль с данным индефикатором и возращаем булевское значение
        }

        public bool Save() // реализация метода сохрание данных
        {
            var saved = _context.SaveChanges(); // сохранение данных
            return saved > 0 ? true : false; // возвращает булевское значение в зависимости были ли сохранения успешными
        }

        public bool UpdateModule(Module module) // реализация метода обновления содержимого модуля
        {
            _context.Update(module); // обновление содержимого модуля
            return Save(); // возвращание результата метода сохранения
        }
    }
}
