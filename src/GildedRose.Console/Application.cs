using GildedRose.Console.Contracts;
using GildedRose.Console.QualityUpdateStrategies;
using GildedRose.Console.Services;
using System.Collections.Generic;

namespace GildedRose.Console
{
    internal class Application
    {
        private IItemUpdater itemUpdateService;
        private IItemRepository itemRepository;

        private Application()
        {

        }

        /// <summary>
        /// Sets up the dependency injection for the Application.
        /// </summary>
        /// <returns>The application with all dependencies wired up.</returns>
        public static Application WireUpIocAndGetApplication()
        {
            // Strategies
            ICollection<IQualityUpdateStrategy> updateStrategies = new List<IQualityUpdateStrategy>()
            {
                new DefaultStrategy(),
                new AgedBrieStrategy()
            };

            var app = new Application();

            //Repository
            app.itemRepository = new HardCodedItemRepository();

            //Services
            /*
             * -Si la constante puede cambiar habría que moverla al App.config
             * -Si la constante varía, o puede variar en el futuro, en función del producto
             * habría que implementar el mismo patrón que para la calidad.
             * -Si va a ser siempre fija se podría dejar dentro de la propia clase Item.
             * -(La dejo aquí por las dudas, ya que permite un poco más de flexibilidad)
             */
            app.itemUpdateService = new ItemUpdaterService(updateStrategies, 1.9M);

            return app;
        }

        /// <summary>
        /// Loads items, updates them, and saves the updated items.
        /// </summary>
        public void StartUpdate()
        {
            var items = itemRepository.GetAll();

            itemUpdateService.Update(items);

            itemRepository.SaveAll(items);
        }
    }
}