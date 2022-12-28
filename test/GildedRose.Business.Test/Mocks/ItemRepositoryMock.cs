using Bogus;
using GildedRose.Data.Repositories;
using GildedRose.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Business.Test.Mocks
{
    public class ItemRepositoryMock : IItemRepository
    {
        public IEnumerable<Item> GetItems() =>
            FakeItems();

        public void UpdateItems(IEnumerable<Item> items) =>
            Console.WriteLine("Updating items...");

        public IEnumerable<Item> FakeItems() =>
            Enumerable.Range(1, new Faker().Random.Int(1, 100))
                .Select(
                    i =>
                    {
                        if (new Faker().Random.Bool())
                            return (Item)FakeItem<ExpiringItem>();
                        else
                            return (Item)FakeItem<AgingItem>();
                    }
                )
                .ToList();

        public ItemType FakeItem<ItemType>() where ItemType : Item =>
            new Faker<ItemType>()
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.SellIn, f => f.Random.Number(0, 100))
                .RuleFor(i => i.Quality, f => f.Random.Number(10, 40))
                .Generate();
    }
}
