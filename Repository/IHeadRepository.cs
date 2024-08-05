using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IHeadRepository // интерфейс хранилища ответственных лиц
    {
        Head GetHead(Guid uuid); // метод получения ответственного лица по индефикатору
        bool HeadExists(Guid uuid); // метод получения булевского значения по интефикатору
    }
}
