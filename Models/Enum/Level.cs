using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models.Enum
{
    public enum Level //список уровней обучения
    {
        [Description("Бакалавр")]
        Bachelor,

        [Description("Прикладной бакалавриат")]
        AppliedBachelor,

        [Description("Специалист")]
        Specialist,

        [Description("Магистр")]
        Master,

        [Description("Аспирант")]
        Postgraduate
    }
}
