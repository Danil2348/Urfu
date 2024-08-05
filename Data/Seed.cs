using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;
using Urfu.Models.Enum;


namespace Urfu.Data
{
    public class Seed // класс для обьявления начальных данных
    {
        private readonly DataContext _context;

        public Seed(DataContext context) // подключение контекста данных
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.EducationProgramModules.Any()) // проверка существуют ли уже данные
            {
                List<Institute> institutes = new List<Institute>() // список институтов
                {
                    new Institute{ title="Первый иститут"},
                    new Institute{ title="Второй институт"},
                    new Institute{ title="Третий институт"}
                };
                List<Head> heads = new List<Head>() // список ответсвенных лиц
                {
                    new Head{ fullname="Первый"},
                    new Head{ fullname="Второй"},
                    new Head{ fullname="Третий"}
                };
                List<EducationProgramModule> educationProgramModules = new List<EducationProgramModule>() // список привязок модулей с ОП
                {
                    new EducationProgramModule
                    {
                        EducationalProgram=new EducationalProgram // ОП
                        {
                            title="Разработка программноинформационных систем",
                            cycher="09.04.03/33.03",
                            level=Level.Master,
                            standart=Standart.SUOS,
                            institute=institutes[0],
                            head=heads[0],
                            accreditationTime=(new DateTime(2025, 03,14)).ToString("yyyy-MM-dd")
                        },
                        Module=new Module // модуль
                        {
                            title="Растровая графика",
                            type="STANDARD"
                        }
                    }
                };
                _context.Institutes.AddRange(institutes); // добавление списка интситутов
                _context.Heads.AddRange(heads); // добавление списка ответсвенных лиц
                _context.EducationProgramModules.AddRange(educationProgramModules); // добавление списка привязок модулей с ОП
                _context.SaveChanges(); // сохранение данных
            }
        }
    }
}
