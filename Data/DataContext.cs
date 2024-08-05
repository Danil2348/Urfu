using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) // передача настроек контекста.
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        public DbSet<EducationalProgram> EducationalPrograms { get; set; } // сопоставление колекции ОП с таблицей ОП
        public DbSet<EducationProgramModule> EducationProgramModules { get; set; } // сопоставление колекции привязки модуля с ОП с таблицей привязок модулей с ОП
        public DbSet<Head> Heads { get; set; } // сопоставление колекции ответственных лиц с таблицей ответсвенных лиц
        public DbSet<Institute> Institutes { get; set; } // сопоставление колекции институтов с таблицей институтов
        public DbSet<Module> Modules { get; set; } // сопоставление колекции модулей с таблицей модулей

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EducationProgramModule>() // назначение составного ключа
                .HasKey(em => new { em.EducationProgramId, em.ModuleId }); 
            builder.Entity<EducationProgramModule>() // создание связи с таблицей модули один ко многим
                .HasOne(m => m.Module)
                .WithMany(em => em.EducationProgramModules)
                .HasForeignKey(e => e.EducationProgramId);
            builder.Entity<EducationProgramModule>() // создание связи с таблицей ОП один ко многим
                .HasOne(e => e.EducationalProgram)
                .WithMany(em => em.EducationProgramModules)
                .HasForeignKey(m => m.ModuleId);

            builder.Entity<EducationalProgram>() // создание связи с таблицей интитуты один ко многим
                .HasOne(e => e.institute)
                .WithMany(i => i.EducationalPrograms)
                .HasForeignKey(e => e.intstituteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EducationalProgram>() // создание связи с таблицей ответсвекнных лиц  один ко многим
                .HasOne(e => e.head)
                .WithMany(h => h.EducationalPrograms)
                .HasForeignKey(e => e.headId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
