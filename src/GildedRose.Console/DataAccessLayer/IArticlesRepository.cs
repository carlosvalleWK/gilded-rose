using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.DataAccessLayer
{
    public interface IArticlesRepository
    {
        IEnumerable<Article> GetAllArticles();
    }
}
