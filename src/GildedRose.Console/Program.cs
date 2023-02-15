using GildedRose.Business;
using GildedRose.Business.Interfaces;
using GildedRose.Repository;
using GildedRose.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProcess, Process>()
                .AddSingleton<IItemsRepository, ItemsRepository>()
                .BuildServiceProvider();

            var proc = serviceProvider.GetService<IProcess>();
            proc.UpdateAll();

            System.Console.ReadKey();
        }
    }
}
