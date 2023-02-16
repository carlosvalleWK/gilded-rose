
using GildedRose.Console.Models;
using System;
using System.Collections.Generic;

namespace GildedRose.Console.DataAccessLayer
{
    public class ArticlesRepository : IArticlesRepository
    {
        public IEnumerable<Article> GetAllArticles()
        {
            try
            {
                return new List<Article>
                {
                    new Article {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Article {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Article {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
