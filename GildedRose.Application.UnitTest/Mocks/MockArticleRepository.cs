using AutoFixture;
using GildedRose.Domain;
using GildedRose.Infrastucture.Persistence;

namespace GildedRose.Application.UnitTests.Mocks
{
    public static class MockArticleRepository
    {
        public static void AddDataInventoryRepository(InventoryDbContext inventoryDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var streamers = new List<Article>();
                //fixture.CreateMany<Article>().ToList();

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 1)
                .With(tr => tr.SellIn, 0)
                .With(tr => tr.Quality, 0)
                .With(tr => tr.Price,0)
                .With(tr => tr.AgedBrie,false)
                .Create());

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 2)
                .With(tr => tr.SellIn, 0)
                .With(tr => tr.Quality, 50)
                .With(tr => tr.Price, 0)
                .With(tr => tr.AgedBrie, true)
                .Create());

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 3)
                .With(tr => tr.SellIn, 0)
                .With(tr => tr.Quality, 2)
                .With(tr => tr.Price, 0)
                .With(tr => tr.AgedBrie, false)
                .Create());

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 4)
                .With(tr => tr.SellIn, 1)
                .With(tr => tr.Quality, 49)
                .With(tr => tr.Price, 0)
                .With(tr => tr.AgedBrie, true)
                .Create());

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 5)
                .With(tr => tr.SellIn, 1)
                .With(tr => tr.Quality, 2)
                .With(tr => tr.Price, 0)
                .With(tr => tr.AgedBrie, false)
                .Create());

            streamers.Add(fixture.Build<Article>()
                .With(tr => tr.Id, 6)
                .With(tr => tr.SellIn, 1)
                .With(tr => tr.Quality, 0)
                .With(tr => tr.Price, 0)
                .With(tr => tr.AgedBrie, false)
                .Create());

            inventoryDbContextFake.Articles!.AddRange(streamers);
            inventoryDbContextFake.SaveChanges();
        }
    }
}
