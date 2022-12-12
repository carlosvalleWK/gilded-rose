namespace GildedRose.Console.Domain.Entities
{
    public partial class Item
    {      
        //Se podría implementar una interfaz e inyectar por dependencias en vez de hacerlo estático, pero para este caso puede ser excesivo.

        /// <summary>
        /// Factory that creates an item.
        /// </summary>
        /// <param name="name">Items Name.</param>
        /// <param name="sellIn">Items SellIn value.</param>
        /// <param name="quality">Items Quality.</param>
        /// <returns></returns>
        public static Item Create(string name, int sellIn, int quality)
        {
            var item = new Item()
            {
                Name = name,
                SellIn = sellIn
            };

            item.Quality = quality;//Así si quality > 50 o < 0 se ajusta correctamente

            return item;
        }
    }
}