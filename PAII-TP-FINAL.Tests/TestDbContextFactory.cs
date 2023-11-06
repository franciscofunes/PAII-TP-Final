using Microsoft.EntityFrameworkCore;
using Data;

namespace PAII_TP_FINAL.Tests
{
    public class TestDbContextFactory
    {
        public PAIIDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PAIIDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            return new PAIIDbContext(options);
        }
    }
}