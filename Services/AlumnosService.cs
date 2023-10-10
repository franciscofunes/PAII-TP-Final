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
        throw new ArgumentNullException(nameof(alumno));
    }

    try
    {
        // Agrega el nuevo alumno al contexto de la base de datos
        _paIIDbContext.Alumnos.Add(alumno);
        await _paIIDbContext.SaveChangesAsync();

        // Devuelve el alumno creado con su ID actualizado
        return alumno;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex}");
        // manejar errores de validación o excepciones aquí según necesidades
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
