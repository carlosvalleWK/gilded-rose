using GildedRose.Console.Entities;
using GildedRose.Console.Services.Console;
using GildedRose.Console.Services.Quality;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GildedRose.Console.Services.Application
{
    public class Application : IApplication
    {
        private readonly IQualityService _qualityService;
        private readonly IOldQualityService _oldQualityService;
        private readonly IConsoleService _consoleService;

        public Application(IQualityService qualityService, IOldQualityService oldQualityService, IConsoleService consoleService)
        {
            _qualityService = qualityService;
            _oldQualityService = oldQualityService;
            _consoleService = consoleService;
        }

        public void Run()
        {
            System.Console.WriteLine("GildedRose App \n");

            for (var i = 0; i < 4; i++)
            {
                _consoleService.ShowProducts(_qualityService.UpdateQuality());

                _consoleService.ShowProducts(_oldQualityService.UpdateQualityOldProcess());
            }

            System.Console.ReadKey();
        }
    }
}
