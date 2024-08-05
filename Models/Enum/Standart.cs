using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models.Enum
{
    public enum Standart //список стандартов обучения
    {
        [Description("СУОС")]
        SUOS,

        [Description("ФГОС ВО")]
        FGOS_VO,

        [Description("СУТ")]
        SUT,

        [Description("ФГОС ВПО")]
        FGOS_VPO,

        [Description("ФГОС 3++")]
        FGOS_3_plus_plus
    }
}
