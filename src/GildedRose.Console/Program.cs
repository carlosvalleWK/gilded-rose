using GildedRose.Console.DataAccessLayer;
using GildedRose.Console.DI;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var serviceProvider = ServiceCollectionExtension.AddServices(new ServiceCollection());
                var process = new GildedRoseProcess(serviceProvider.GetService<IArticlesRepository>());
                process.RunGildedRoseProcess();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"There was an error executing Gilded Rose Process :: {ex.Message}");
            }
            finally
            {
                System.Console.ReadKey();
            }
        }
    }
}
