using GildedRose.Console.Entities;
using System.Collections.Generic;

namespace GildedRose.Console.Services.Quality
{
    public interface IOldQualityService
    {
        IList<Product> UpdateQualityOldProcess();
    }
}