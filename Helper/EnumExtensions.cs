using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Urfu.Models.Enum;

namespace Urfu.Helper
{
    public static class EnumExtensions // класс для работы с enum
    {
        public static string GetDescription(this Enum value) // метод для получения из значения enum, его описания
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : value.ToString(); // если описание есть возвращает его в противном случае само значение
        }
    }
}
