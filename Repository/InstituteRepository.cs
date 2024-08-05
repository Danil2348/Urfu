using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Models;

namespace Urfu.Repository
{
    public class InstituteRepository: IInstituteRepository // класс реализующий интерфейс хранилища институтов
    {
        private readonly DataContext _context;

        public InstituteRepository(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public Institute GetInstitute(Guid uuid) // реализация метода получения интитута по индефикатору
        {
            return _context.Institutes.Where(i => i.uuid == uuid).FirstOrDefault(); // находим и возращаем первый институт по данному индефикатору
        }

        public bool InstituteExists(Guid uuid) // реализация метода получения булевского значения по интефикатору
        {
            return _context.Institutes.Any(i => i.uuid == uuid); // проверяем есть ли институт с данным индефикатором и возращаем булевское значение
        }
    }
}
