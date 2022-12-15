using GildedRose.API;
using GildedRose.Model.Model;
using System.Xml.Linq;

namespace GildedRoseAPI
{
    public class GildedRoseBackgroundService : BackgroundService
    {
        static bool isInitialized = false;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    if (!isInitialized)
                    {
                        Constants.ITEMS = new List<Item>
                        {
                            new Item("+5 Dexterity Vest",20,false,10),
                            new Item("Aged Brie",0,true,2),
                            new Item("Elixir of the Mongoose",7,false,5)
                        };
                        isInitialized= true;
                    }
                    else
                    {
                        foreach (var item in Constants.ITEMS)
                        {
                            item.UpdateProduct(Constants.SELL_IN_VARIATION,Constants.QUALITY_VARIATON,Constants.QUALITY_PRICE_FACTOR);
                        }
                    }
                }
                catch (System.Exception ex)
                {

                    throw new Exception(ex.Message);

                }
                finally
                {
                    await Task.Delay(Constants.BACKGROUND_CHECK_PRODUCTS_TIME*3600*1000, stoppingToken);
                }
            }
        }
    }
}
