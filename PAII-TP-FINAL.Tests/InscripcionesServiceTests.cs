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
    }
}
