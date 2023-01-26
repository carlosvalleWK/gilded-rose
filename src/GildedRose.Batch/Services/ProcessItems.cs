using GildedRose.Domain.Interfaces.Business;
using GildedRose.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GildedRose.Batch.Services
{
    public class ProcessItems : IProcessItems
    {
        private readonly IProcessQualityItems qualityItems;
        private readonly IItemGenerator qualityGenerator;

        public ProcessItems(IProcessQualityItems qualityItems, IItemGenerator qualityGenerator)
        {
            this.qualityItems = qualityItems ?? throw new ArgumentNullException(nameof(qualityItems));
            this.qualityGenerator = qualityGenerator ?? throw new ArgumentNullException(nameof(qualityGenerator));
        }
        public void Process()
        {
            Console.WriteLine("OMGHAI!");

            var items = qualityGenerator.GenerateItems();
            qualityItems.UpdateQuality(items);

            var jsonString = JsonSerializer.Serialize(items);
            Console.WriteLine(jsonString);

            Console.ReadKey();
        }
    }
}
