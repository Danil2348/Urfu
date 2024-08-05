using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Models;

namespace Urfu.Repository
{
    public class EducationalProgramModuleRepository: IEducationalProgramModuleRepository // класс реализующий интерфейс хранилища привязки модуля с ОП
    {
        private readonly DataContext _context;

        public EducationalProgramModuleRepository(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public bool CreateEducationalProgramModule(EducationProgramModule educationProgramModule) // реализация метода добаления новой привязки модуля с ОП
        {
            _context.Add(educationProgramModule); // добаления новой привязки модуля с ОП
            return Save(); // возвращание результата метода сохранения
        }

        public ICollection<EducationProgramModule> GetEducationalProgramModules() // реализация метода получения списка привязок модуля с ОП
        {
            return _context.EducationProgramModules.ToList(); // возвращение  списка привязок модуля с ОП
        }

        public bool Save() // реализация метода сохрание данных
        {
            var saved = _context.SaveChanges(); // сохранение данных
            return saved > 0 ? true : false; // возвращает булевское значение в зависимости были ли сохранения успешными
        }
    }
}
