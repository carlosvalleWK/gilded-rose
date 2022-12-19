using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services.Console
{
    public interface IConsoleService
    {
        void ShowProducts(IList<Product> products);
    }
}
