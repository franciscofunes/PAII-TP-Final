using Data;
using Data.DTOs;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PAII_TP_Final.Contracts
{
    public class InscripcionesService : IInscripcionesService
    {
        private readonly PAIIDbContext _paIIDbContext;

        public InscripcionesService(PAIIDbContext paIIDbContext)
        {
            _paIIDbContext = paIIDbContext;
        }

        public async Task<List<InscripcionDTO>> GetAllInscripcionesAsync()
        {
            var inscripciones = await _paIIDbContext.Inscripciones.ToListAsync();
            return inscripciones.Select(i => new InscripcionDTO
            {
                Id = i.Id,
                Detalles = i.Detalles,
                Estado = i.Estado.ToString(),
                AlumnoId = i.AlumnoId,
            }).ToList();
        }

        public async Task<InscripcionDTO> GetInscripcionByIdAsync(int inscripcionId)
        {
            var inscripcion = await _paIIDbContext.Inscripciones.FindAsync(inscripcionId);

            if (inscripcion == null)
            {
                throw new ArgumentException($"No se encontró la inscripción con ID {inscripcionId}.", nameof(inscripcionId));
            }

            return new InscripcionDTO
            {
                Id = inscripcion.Id,
                Detalles = inscripcion.Detalles,
                Estado = inscripcion.Estado.ToString(),
                AlumnoId = inscripcion.AlumnoId,
            };
        }

        public async Task<Inscripcion> CreateInscripcionAsync(Inscripcion inscripcion)
        {
            if (inscripcion == null)
            {
                throw new ArgumentNullException(nameof(inscripcion), "El objeto de inscripción es nulo.");
            }

            var alumnoExists = await _paIIDbContext.Alumnos.AnyAsync(a => a.Id == inscripcion.AlumnoId);
            if (!alumnoExists)
            {
                throw new InvalidOperationException("El ID del Alumno no existe en la base de datos.");
            }

            var existingInscripcion = await _paIIDbContext.Inscripciones
                .FirstOrDefaultAsync(i => i.AlumnoId == inscripcion.AlumnoId);

            if (existingInscripcion != null)
            {
                // If an inscripcion with the same AlumnoId already exists, you can handle it accordingly.
                throw new InvalidOperationException("Ya existe una inscripción para este Alumno.");
            }

            try
            {
                inscripcion.Estado = inscripcion.Estado;

                _paIIDbContext.Inscripciones.Add(inscripcion);
                await _paIIDbContext.SaveChangesAsync();
                return inscripcion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return new Inscripcion();
            }
        }
    }
}
