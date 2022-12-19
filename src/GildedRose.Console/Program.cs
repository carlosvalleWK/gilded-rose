using GildedRose.Business;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Bienvenido");
            System.Console.WriteLine("1. Presiona ENTER para degradar.\n2. Persiona ESC para salir\n");

            ConsoleKeyInfo consoleKey = System.Console.ReadKey();
            ProductManagement productManagement = new ProductManagement();

            while (consoleKey.Key != ConsoleKey.Escape) {

                productManagement.UpdateEndOfDay();

                consoleKey = System.Console.ReadKey();
            }
        }
    }
}
