using GildedRose.Infrastucture.Persistence;
using GildedRose.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GildedRose.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: $"InventoryDbContext-{Guid.NewGuid()}")
                .Options;

            var inventoryDbContextFake = new InventoryDbContext(options);

            inventoryDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(inventoryDbContextFake);

            return mockUnitOfWork;
        }
    }
}
