using Data.Entities;

namespace PAII_TP_Final.Contracts
{
    public interface IAlumnosService
    {
        Task<List<Alumnos>> GetAllStudentsAsync();
        Task<Alumnos?> GetStudentByIdAsync(int id);
        Task<bool> UpdateStudentAsync(int id, Alumnos updatedStudent);
        Task<Alumnos?> CreateStudentAsync(Alumnos alumno);
        Task<Alumnos?> DeleteStudentAsync(int id);
    }
}
