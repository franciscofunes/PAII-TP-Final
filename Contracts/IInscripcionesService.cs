using Data.DTOs;
using Data.Entities;

public interface IInscripcionesService
    {
        Task<Inscripcion> CreateInscripcionAsync(Inscripcion inscripcion);

        Task<List<InscripcionDTO>> GetAllInscripcionesAsync();

        Task<InscripcionDTO> GetInscripcionByIdAsync(int inscripcionId);
    }