using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;

namespace Urfu.Service
{
    public interface IModuleService // интерфейс сервиса модулей
    {
        ICollection<ModuleDto> GetModules(); // метод получения списка модулей
        ModuleDto GetModule(Guid uuid); // метод получения модуля по индефикатору
        bool CreateModule(ModuleDto moduleDto, Guid uuidEP); // метод добавления нового модуля
        bool UpdateModule(ModuleDto moduleDto, Guid uuid); // метод обновления содержимого модуля
        bool DeleteModule(Guid uuid); // метод удаления модуля
        bool ModuleExists(Guid uuid); // метод получения булевского значения по интефикатору
    }
}
