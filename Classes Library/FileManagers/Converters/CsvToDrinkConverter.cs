using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FileManagers.Converters
{
    public static class CsvToDrinkConverter
    {
        public static List<Drink> Convert(string fileContent)
        {
            var drinks = new List<Drink>();
            var fileAsStrArr = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var fileHeaders = fileAsStrArr[0].Split(';');

            for (var i = 1; i < fileAsStrArr.Length; i++)
            {
                var args = fileAsStrArr[i].Split(';');
                var id = int.Parse(args[Array.IndexOf(fileHeaders, "id")]);
                var price = float.Parse(args[Array.IndexOf(fileHeaders, "price")], CultureInfo.InvariantCulture);
                var name = args[Array.IndexOf(fileHeaders, "name")];
                var size = int.Parse(args[Array.IndexOf(fileHeaders, "size")]);
                var sugar = args[Array.IndexOf(fileHeaders, "sugar")] == "1";

                drinks.Add(new Drink(id, price, name, size, sugar));
            }

            return drinks;
        }
    }
}
