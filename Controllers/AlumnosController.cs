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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Alumnos>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Alumnos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Alumnos))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] Alumnos alumno)
        {
            if (alumno == null)
            {
                return BadRequest("El objeto de alumno es nulo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdAlumno = await _alumnosService.CreateStudentAsync(alumno);

                if (createdAlumno != null)
                {
                    return Created($"/api/alumnos/{createdAlumno.Id}", new { id = createdAlumno.Id });
                }
                else
                {
                    return BadRequest("El DNI ya existe en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                // Handle exceptions or other validation errors here as needed.
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _alumnosService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var success = await _alumnosService.DeleteStudentAsync(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "No se pudo eliminar el alumno.");
            }
        }
    }
}
