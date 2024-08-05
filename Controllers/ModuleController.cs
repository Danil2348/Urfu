using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Service;

namespace Urfu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase // контроллер модулей
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService) // подключение сервиса модулей
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public IActionResult GetModules() // метод реализующий запрос на получение списка модулей
        {
            var modules = _moduleService.GetModules(); // получение списка модулей 
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            return Ok(modules); // возвращение списка модулей
        }

        [HttpGet("{uuid}")]
        public IActionResult GetModule(Guid uuid) // метод реализующий запрос на получение модуля по индефикатору
        {
            if (!_moduleService.ModuleExists(uuid)) // проверка существует ли такой модуль
                return NotFound();
            var module = _moduleService.GetModule(uuid); // получение модуля по индефикатору
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            return Ok(module); // возвращение модуля
        }

        [HttpDelete("{uuid}")]
        public IActionResult DeleteModule(Guid uuid) // метод реализующий запрос на удаление модуля
        {
            if (!_moduleService.ModuleExists(uuid)) // проверка существует ли такой модуль
                return NotFound();
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if (!_moduleService.DeleteModule(uuid)) // проверка результата удаления модуля
            {
                ModelState.AddModelError("", "что то пошло нет так при удалении программы");
                return StatusCode(500, ModelState);
            }
            return NoContent(); // возвращение результата
        }

        [HttpPost]
        public IActionResult CreateModule(ModuleDto moduleDto, Guid uuidEP) // метод реализующий запрос на создание нового модуля
        {
            if (moduleDto == null) // проверка что полученый ModuleDto не пустой
                return BadRequest(ModelState);
            var module = _moduleService.GetModules().Where(m => m.title.Trim().ToUpper() == moduleDto.title.TrimEnd().ToUpper()).FirstOrDefault(); // по содержимому ModuleDto поиск модуля в бд
            if (module != null) // проверка что такого модуля не существует
            {
                ModelState.AddModelError("", "данный модуль уже существует");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if (!_moduleService.CreateModule(moduleDto, uuidEP)) // проверка результата создания модуля
            {
                ModelState.AddModelError("", "что то пошло не так при сохранении");
            }
            return Ok("Модуль успешно добавлен"); // возвращение результата
        }

        [HttpPut("uuid")]
        public IActionResult UpdateModule(ModuleDto moduleDto, Guid uuid) // метод реализующий запрос на обновление содержимого модуля
        {
            if (moduleDto == null) // проверка что полученный ModuleDto не пустой
                return BadRequest(ModelState);
            if (!_moduleService.ModuleExists(uuid)) // проверка существует ли такой модуль
                return NotFound();
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if (!_moduleService.UpdateModule(moduleDto, uuid)) // проверка результата обновления содержимого модуля
            {
                ModelState.AddModelError("", "что то пошло не так при обновлении содержимого");
                return StatusCode(500, ModelState);
            }
            return NoContent(); // возвращение результата

        }
    }
}
