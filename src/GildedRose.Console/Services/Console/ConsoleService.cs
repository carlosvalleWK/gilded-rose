using GildedRose.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services.Console
{
    public class ConsoleService : IConsoleService
    {
        public void ShowProducts(IList<Product> products)
        {
            foreach (var elem in products)
            {
                System.Console.WriteLine(elem.ToString());
                System.Console.WriteLine("\n");
            }

            System.Console.WriteLine("--------------");
            System.Console.WriteLine("\n");
        }
    }
}
