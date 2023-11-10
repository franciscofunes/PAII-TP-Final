using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Data.DTOs;

namespace PAII_TP_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InscripcionesController : ControllerBase
    {
        private readonly IInscripcionesService _inscripcionesService;

        public InscripcionesController(IInscripcionesService inscripcionesService)
        {
            _inscripcionesService = inscripcionesService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InscripcionDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllInscripcionesAsync()
        {
            try
            {
                var inscripciones = await _inscripcionesService.GetAllInscripcionesAsync();

                return Ok(inscripciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{inscripcionId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InscripcionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInscripcionByIdAsync(int inscripcionId)
        {
            try
            {
                var inscripcion = await _inscripcionesService.GetInscripcionByIdAsync(inscripcionId);

                if (inscripcion == null)
                {
                    return NotFound($"No se encontró la inscripción con ID {inscripcionId}.");
                }

                return Ok(inscripcion);
            }
            catch (ArgumentException ex) when (ex.ParamName == nameof(inscripcionId))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Inscripcion))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] Inscripcion inscripcion)
        {
            if (inscripcion == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdInscripcion = await _inscripcionesService.CreateInscripcionAsync(inscripcion);

                if (createdInscripcion != null)
                {
                    return Created($"/api/inscripciones/{createdInscripcion.Id}", new { id = createdInscripcion.Id });
                }

                return BadRequest("La creación de inscripción falló.");
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("El ID del Alumno no existe en la base de datos."))
                {
                    return BadRequest("El ID del Alumno no existe en la base de datos Alumnos.");
                }
                else if (ex.Message.Contains("Ya existe una inscripción para este Alumno."))
                {
                    return BadRequest("El AlumnoId ya está asociado a una inscripción existente.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("{inscripcionId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InscripcionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateInscripcionAsync(int inscripcionId, [FromBody] Inscripcion inscripcion)
        {
            try
            {
                var updatedInscripcion = await _inscripcionesService.UpdateInscripcionAsync(inscripcionId, inscripcion);

                if (updatedInscripcion == null)
                {
                    return NotFound($"No se encontró la inscripción con ID {inscripcionId}.");
                }

                return Ok(updatedInscripcion);
            }
            catch (ArgumentException ex)
            {
                // Handle the specific exception for inscripción not found
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
