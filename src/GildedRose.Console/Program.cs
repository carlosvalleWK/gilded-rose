namespace GildedRose.Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = Application.WireUpIocAndGetApplication();

            app.StartUpdate();

            System.Console.ReadKey();
        }
    }
}