using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Models;

namespace Urfu.Repository
{
    public class HeadRepository : IHeadRepository // класс реализующий интерфейс хранилища ответственных лиц
    {
        private readonly DataContext _context;

        public HeadRepository(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public Head GetHead(Guid uuid) // реализация метода получения ответственного лица по индефикатору
        {
            return _context.Heads.Where(h => h.uuid == uuid).FirstOrDefault(); // находим и возращаем первое ответственное лицо по данному индефикатору
        }

        public bool HeadExists(Guid uuid) // реализация метода получения булевского значения по интефикатору
        {
            return _context.Heads.Any(h => h.uuid == uuid); // проверяем есть ли ответственное лицо с данным индефикатором и возращаем булевское значение
        }
    }
}
