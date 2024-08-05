using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IInstituteRepository // интерфейс хранилища институтов
    {
        Institute GetInstitute(Guid uuid); // метод получения интитута по индефикатору
        bool InstituteExists(Guid uuid); // метод получения булевского значения по интефикатору
    }
}
