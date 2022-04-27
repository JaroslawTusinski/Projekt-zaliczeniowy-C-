using Classes_Library.FileManagers.Converters;
using Classes_Library.FoodModels;
using System.Collections.Generic;
using System.IO;

namespace Classes_Library.FileManagers
{
    public static class Repository
    {
        public static List<Addon> GetAddons()
        {
            return CsvToAddonConverter.Convert(Resource.addon);
        }

        public static List<Dessert> GetDesserts()
        {
            return CsvToDessertConverter.Convert(Resource.dessert);
        }

        public static List<Drink> GetDrinks()
        {
            return CsvToDrinkConverter.Convert(Resource.drink);
        }

        public static List<Sandwich> GetSandwiches()
        {
            return CsvToSandwichConverter.Convert(Resource.sandwich);
        }
    }
}
