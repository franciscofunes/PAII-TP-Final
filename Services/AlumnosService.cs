using Data;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using PAII_TP_Final.Contracts;

namespace PAII_TP_Final.Services
{
    public class AlumnosService : IAlumnosService
    {
        private readonly PAIIDbContext _paIIDbContext;

        public AlumnosService(PAIIDbContext paIIDbContext)
        {
            _paIIDbContext = paIIDbContext;
        }

        public async Task<List<Alumnos>> GetAllStudentsAsync()
        {
            return await _paIIDbContext.Alumnos.ToListAsync();
        }

        public async Task<Alumnos?> GetStudentByIdAsync(int id)
        {
            return await _paIIDbContext.Alumnos.FirstOrDefaultAsync(alumno => alumno.Id == id);
        }

        public async Task<bool> UpdateStudentAsync(int id, Alumnos updatedStudent)
        {
            var existingStudent = await _paIIDbContext.Alumnos.FirstOrDefaultAsync(alumno => alumno.Id == id);

            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.Nombre = updatedStudent.Nombre;
            existingStudent.Apellido = updatedStudent.Apellido;
            existingStudent.NumIdentificacion = updatedStudent.NumIdentificacion;
            existingStudent.FechaNacimiento = updatedStudent.FechaNacimiento;
            existingStudent.Direccion = updatedStudent.Direccion;
            existingStudent.Telefono = updatedStudent.Telefono;
            existingStudent.CorreoElectronico = updatedStudent.CorreoElectronico;
            existingStudent.Carrera = updatedStudent.Carrera;
            existingStudent.Promedio = updatedStudent.Promedio;
            existingStudent.FechaIngreso = updatedStudent.FechaIngreso;

            try
            {
                await _paIIDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return false;
            }
        }

        public async Task<Alumnos?> CreateStudentAsync(Alumnos alumno)
        {
            if (alumno == null)
            {
                throw new ArgumentNullException(nameof(alumno), "El objeto de alumno es nulo.");
            }

            if (await _paIIDbContext.Alumnos.AnyAsync(a => a.NumIdentificacion == alumno.NumIdentificacion))
            {
                return null;
            }

            try
            {
                _paIIDbContext.Alumnos.Add(alumno);
                await _paIIDbContext.SaveChangesAsync();

                return alumno;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");

                return null;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var existingStudent = await _paIIDbContext.Alumnos.FirstOrDefaultAsync(alumno => alumno.Id == id);

            if (existingStudent == null)
            {
                return false;
            }

            _paIIDbContext.Alumnos.Remove(existingStudent);

            try
            {
                await _paIIDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return false;
            }
        }

    }
}
