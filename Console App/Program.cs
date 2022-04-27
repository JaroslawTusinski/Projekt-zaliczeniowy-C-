using Classes_Library.FileManagers;
using Classes_Library.FoodModels;
using Console_App.ConsoleManagers;
using System;
using System.Collections.Generic;

namespace Console_App
{
    internal class Program
    {
        private static List<Addon> _addons = Repository.GetAddons();
        private static List<Drink> _drinks = Repository.GetDrinks();
        private static List<Dessert> _desserts = Repository.GetDesserts();
        private static List<Sandwich> _sandwiches = Repository.GetSandwiches();

        static void Main(string[] args)
        {
            Console.WriteLine("Zamawiacz 2022 - wersja konsolowa\n");
            DisplayMenu();

            Console.WriteLine("\n----- Złóż zamówienie -----");
            var order = GetOrder();

            Console.WriteLine(order.ToSummaryString());
            Console.ReadKey();
        }

        private static Order GetOrder()
        {
            var sandwichesId = ConsoleReader.ReadProductId("Wybierz kanapke:", _sandwiches);
            var drinksId = ConsoleReader.ReadProductId("Wybierz napój:", _drinks);
            var dessertsId = ConsoleReader.ReadProductId("Wybierz deser:", _desserts);
            var addonsId = ConsoleReader.ReadProductId("Wybierz dodatek:", _addons);

            return new Order(
                1,
                _sandwiches.Find(p => p.Id == sandwichesId),
                _drinks.Find(p => p.Id == drinksId),
                _desserts.Find(p => p.Id == dessertsId),
                _addons.Find(p => p.Id == addonsId)
            );
        }

        private static void DisplayMenu()
        {
            ConsoleWriter.DisplayProductList("Lista kanapek:", _sandwiches);
            ConsoleWriter.DisplayProductList("Lista napoji:", _drinks);
            ConsoleWriter.DisplayProductList("Lista deserów:", _desserts);
            ConsoleWriter.DisplayProductList("Lista dodatków:", _addons);
        }

        
    }
}
