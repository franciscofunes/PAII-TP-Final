using Data.Entities;

public interface IInscripcionesService
    {
        Task<Inscripcion> CreateInscripcionAsync(Inscripcion inscripcion);
    }
