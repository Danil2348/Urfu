using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Models.Enum;
using Urfu.Service;

namespace Urfu.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EducationalProgramController : ControllerBase // контроллер ОП
    { 
        private readonly IEducationalProgramService _educationalProgramService;

        public EducationalProgramController(IEducationalProgramService educationalProgramService) // подключение сервиса ОП
        {
            _educationalProgramService = educationalProgramService;
        }
        
        [HttpGet]
        
        public IActionResult GetEducationPrograms() // метод реализующий запрос на получение списка ОП
        {
            var educationalPrograms = _educationalProgramService.GetEducationPrograms(); // получение списка ОП
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState); 
            return Ok(educationalPrograms); // возвращение списка ОП
        }

        [HttpGet("{uuid}")]
        public IActionResult GetEducationalProgram(Guid uuid) // метод реализующий запрос на получение ОП по индефикатору
        {
            if (!_educationalProgramService.EducationProgramExists(uuid)) // проверка существует ли такой ОП
                return NotFound();
            var educationalProgram = _educationalProgramService.GetEducationProgram(uuid); // получение ОП по индефикатору
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            return Ok(educationalProgram); // возвращение ОП
        }

        [HttpGet("{uuid}/modules")]
        public IActionResult GetModulesFromEducationalProgram(Guid uuid) // метод реализующий запрос на получение списка модулей связанных с ОП с данным индефикатором
        {
            var modules = _educationalProgramService.GetModulesFromEducationalProgram(uuid); // получение списка модулей связанных с ОП с данным индефикатором
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            return Ok(modules); // возвращение списка модулей
        }

        [HttpDelete("{uuid}")]
        public IActionResult DeleteEducationalProgram(Guid uuid) // метод реализующий запрос на удаление ОП
        {
            if (!_educationalProgramService.EducationProgramExists(uuid)) // проверка существует ли такой ОП
                return NotFound();
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if (!_educationalProgramService.DeleteEducationalProgram(uuid)) // проверка результата удаления ОП
            {
                ModelState.AddModelError("", "что то пошло нет ак при удалении программы");
                return StatusCode(500, ModelState);
            }
            return NoContent(); // возвращение результата
        }

        [HttpPost]
        public IActionResult CreateEducationalProgram(EducationalProgramAddDto educationalProgramAddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuidM) // метод реализующий запрос на создание нового ОП
        {
            if (educationalProgramAddDto == null) // проверка что полученый EducationalProgramAddDto не пустой
                return BadRequest(ModelState);
            var educationalProgram = _educationalProgramService.GetEducationPrograms().Where(ep => ep.title.Trim().ToUpper() == educationalProgramAddDto.title.TrimEnd().ToUpper()).FirstOrDefault(); // по содержимому EducationalProgramAddDto поиск модуля в бд
            if (educationalProgram != null) // проверка что такого ОП не существует
            {
                ModelState.AddModelError("", "данная программа уже существует");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState);
            if (!_educationalProgramService.CreateEducationalProgram(educationalProgramAddDto, level, standart, uuidIn, uuidHe, uuidM)) // проверка результата создания ОП
            {
                ModelState.AddModelError("", "что то пошло не так при сохранении");
            }
            return Ok("Программа успешно добавлена"); // возвращение результата
        }

        [HttpPut("uuid")]
        public IActionResult UpdateEdu8cationalProgram(EducationalProgramAddDto educationalProgramAddDto, Level level, Standart standart, Guid uuidIn, Guid uuidHe, Guid uuid) // метод реализующий запрос на обновление содержимого ОП
        { 
            if (educationalProgramAddDto == null) // проверка что полученный EducationalProgramAddDto не пустой
                return BadRequest(ModelState);
            if (!_educationalProgramService.EducationProgramExists(uuid))  // проверка существует ли такой ОП
                return NotFound();
            if (!ModelState.IsValid) // проверка ошибки валидации
                return BadRequest(ModelState); 
            if (!_educationalProgramService.UpdateEducationalProgram(educationalProgramAddDto, level, standart, uuidIn, uuidHe, uuid)) // проверка результата обновления содержимого ОП
            {
                ModelState.AddModelError("", "что то пошло не так при обновлении содержимого");
                return StatusCode(500, ModelState);
            }
            return NoContent(); // возвращение результата

        }
    }
}
