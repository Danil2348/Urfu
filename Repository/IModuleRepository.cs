using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IModuleRepository // интерфейс хранилища модулей
    {
        ICollection<Module> GetModules(); // метод получения списка модулей
        Module GetModule(Guid uuid); // метод получения модуля по индефикатору
        bool ModuleExists(Guid uuid); // метод получения булевского значения по интефикатору
        bool CreateModule(Module module, Guid uuidEP); // метод добавления нового модуля и создания привязки его с ОП
        bool UpdateModule(Module module); // метод обновления содержимого модуля
        bool DeleteModule(Module module); // метод удаления модуля
        bool Save(); // метод сохрание данных
    }
}
