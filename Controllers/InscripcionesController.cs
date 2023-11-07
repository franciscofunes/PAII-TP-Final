using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using System;
using System.Threading.Tasks;

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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
