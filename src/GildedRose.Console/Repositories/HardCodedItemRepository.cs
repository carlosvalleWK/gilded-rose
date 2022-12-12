using GildedRose.Console.Contracts;
using GildedRose.Console.Domain.Entities;
using System.Collections.Generic;

namespace GildedRose.Console
{
    //Un ejemplo sobre cómo se podría implementar un repositorio. Es necesario para facilitar la introducción de próximos artículos.
    internal class HardCodedItemRepository : IItemRepository
    {
        public ICollection<Item> GetAll()
        {
            return new List<Item>
                {
                    Item.Create( name : "+5 Dexterity Vest", sellIn : 10, quality : 20 ),
                    Item.Create( name : "Aged Brie", sellIn : 2, quality : 0 ),
                    Item.Create( name : "Elixir of the Mongoose", sellIn : 5, quality : 7 )
                };
        }

        public void SaveAll(ICollection<Item> items)
        {
            System.Console.WriteLine("Saving items in a repository.");
        }
    }
}