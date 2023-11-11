using Data;
using Data.DTOs;
using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using PAII_TP_Final.Contracts;

namespace PAII_TP_FINAL.Tests
{
    public class InscripcionesServiceTests
    {
        [Fact]
        public async Task GetAllInscripcionesAsync_ShouldReturnListOfInscripcionDTO()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<PAIIDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var context = new PAIIDbContext(dbContextOptions))
            {
                var service = new InscripcionesService(context);

                // Act
                var result = await service.GetAllInscripcionesAsync();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<InscripcionDTO>>(result);
            }
        }

        [Fact]
        public async Task GetInscripcionByIdAsync_WithInvalidId_ShouldThrowArgumentException()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<PAIIDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var context = new PAIIDbContext(dbContextOptions))
            {
                var service = new InscripcionesService(context);

                // Act and Assert
                await Assert.ThrowsAsync<ArgumentException>(async () => await service.GetInscripcionByIdAsync(1));
            }
        }

        [Fact]
        public async Task DeleteInscripcionAsync_WithValidId_ShouldReturnTrue()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<PAIIDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var context = new PAIIDbContext(dbContextOptions))
            {
                var service = new InscripcionesService(context);

                var inscripcion = new Inscripcion { Id = 1, AlumnoId = 1, Detalles = "Test Details", Estado = EstadoInscripcion.Aceptada };
                context.Inscripciones.Add(inscripcion);
                await context.SaveChangesAsync();

                // Act
                var result = await service.DeleteInscripcionAsync(1);

                // Assert
                Assert.True(result);
            }
        }
    }
}
