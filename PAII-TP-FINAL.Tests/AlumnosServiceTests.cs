using Data.Entities;
using PAII_TP_Final.Services;

namespace PAII_TP_FINAL.Tests
{
    public class AlumnosServiceTests
    {
        private readonly TestDbContextFactory dbContextFactory = new();

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudents()
        {
            // Arrange
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var service = new AlumnosService(dbContext);

                // Act
                var students = await service.GetAllStudentsAsync();

                // Assert
                Assert.NotNull(students);
            }
        }

        [Fact]
        public async Task GetStudentByIdAsync_ExistingStudent_ReturnsStudent()
        {
            // Arrange
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var service = new AlumnosService(dbContext);
                var alumno = new Alumnos
                {
                    Id = 1003,
                    Nombre = "John",
                    Apellido = "Doe",
                    NumIdentificacion = 35987456,
                    FechaNacimiento = new DateTime(1990, 5, 15),
                    Direccion = "123 Calle Principal",
                    Telefono = "555-123-4567",
                    CorreoElectronico = "sergio@gmail.com",
                    Carrera = "Informática",
                    Promedio = 90,
                    FechaIngreso = new DateTime(2020, 9, 1)
                };
                dbContext.Alumnos.Add(alumno);
                await dbContext.SaveChangesAsync();

                // Act
                var result = await service.GetStudentByIdAsync(1003);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("John", result.Nombre);
            }
        }

        [Fact]
        public async Task UpdateStudentAsync_NonExistingStudent_ReturnsFalse()
        {
            // Arrange
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                // Create an instance of the service
                var service = new AlumnosService(dbContext);

                // Create a non-existing student
                var updatedStudent = new Alumnos { Id = 1, Nombre = "Updated John" };

                // Act
                var result = await service.UpdateStudentAsync(1, updatedStudent);

                // Assert
                Assert.False(result);
            }
        }

        [Fact]
        public async Task DeleteStudentAsync_NonExistingStudent_ReturnsFalse()
        {
            // Arrange
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                // Create an instance of the service
                var service = new AlumnosService(dbContext);

                // Act
                var result = await service.DeleteStudentAsync(1);

                // Assert
                Assert.False(result);
            }
        }

        [Fact]
        public async Task CreateStudentAsync_WithValidInput_ShouldReturnAlumno()
        {
            // Arrange
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var service = new AlumnosService(dbContext);
                var alumno = new Alumnos
                {
                    Id = 1002,
                    Nombre = "Francisco",
                    Apellido = "Funes",
                    NumIdentificacion = 35324183,
                    FechaNacimiento = new DateTime(1990, 5, 15),
                    Direccion = "123 Calle Principal",
                    Telefono = "555-123-4567",
                    CorreoElectronico = "juan.perez@email.com",
                    Carrera = "Informática",
                    Promedio = 90,
                    FechaIngreso = new DateTime(2020, 9, 1)
                };

                // Act
                var result = await service.CreateStudentAsync(alumno);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(alumno, result);
            }
        }
    }
}