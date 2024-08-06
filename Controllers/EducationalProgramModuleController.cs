using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Service;

namespace Urfu.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EducationalProgramModuleController : ControllerBase // контроллер привязки модуля с ОП
    {
        private readonly IEducationalProgramModuleService _educationalProgramModuleService;

        public EducationalProgramModuleController(IEducationalProgramModuleService educationalProgramModuleService) // подключение сервиса привязки модуля с ОП
        {
            _educationalProgramModuleService = educationalProgramModuleService;
        }
        [HttpPost]
        public IActionResult CreateEducationalProgramModule(Guid uuidM, Guid uuidEP) // метод реализующий запрос на добавление новой привязки модуля с ОП
        {
            if(_educationalProgramModuleService.EducationalProgramModuleAny(uuidM, uuidEP)) // проверка существует ли уже такая привязка модуля с ОП
            {
                ModelState.AddModelError("", "данная привязка уже существует");
                return StatusCode(422, ModelState);
            };
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if(!_educationalProgramModuleService.CreateEducationalProgramModule(uuidM, uuidEP)) // проверка результата сохранения привязки модуля с ОП
            {
                ModelState.AddModelError("", "что то пошло не так при сохранении");
            }
            return Ok("Привязка успешно добавлена"); 
        }
    }
}
