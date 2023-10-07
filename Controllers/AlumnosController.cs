using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using PAII_TP_Final.Contracts;

namespace PAII_TP_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnosService _alumnosService;

        public AlumnosController(IAlumnosService alumnosService)
        {
            _alumnosService = alumnosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var alumnos = await _alumnosService.GetAllStudentsAsync();

            if (alumnos.Count == 0)
            {
                return NoContent();
            }

            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _alumnosService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Alumnos updatedStudent)
        {
            var success = await _alumnosService.UpdateStudentAsync(id, updatedStudent);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
