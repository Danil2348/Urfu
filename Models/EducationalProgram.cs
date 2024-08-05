using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models.Enum;

namespace Urfu.Models
{
    public class EducationalProgram //программа обучения
    {
        [Key]
        public Guid uuid { get; set; } //индефикатор
        public string title { get; set; } //название
        [ReadOnly(true)]
        public string status { get; set; } //статус ОП (всегда единственное значение)
        public string cycher { get; set; } //шифр
        public Level level { get; set; } //уровень обучения
        public Standart standart { get; set; } //стандарт обучения
        [ForeignKey("Institute")]
        public Guid intstituteId { get; set; } //индефикатор института
        public Institute institute { get; set; } //институт
        [ForeignKey("Head")]
        public Guid headId { get; set; } //индефикатор ответственного лица
        public Head head { get; set; } //ответственное лицо
        public string accreditationTime { get; set; } //дата следующей аккредитации
        public ICollection<EducationProgramModule> EducationProgramModules { get; set; } // список привязок модулей с ОП
        public EducationalProgram()
        {
            uuid = Guid.NewGuid();
            status = "Действующая до завершения срока освоения";
        }
    }
}
