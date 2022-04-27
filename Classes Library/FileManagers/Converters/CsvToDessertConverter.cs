using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FileManagers.Converters
{
    public static class CsvToDessertConverter
    {
        public static List<Dessert> Convert(string fileContent)
        {
            var desserts = new List<Dessert>();
            var fileAsStrArr = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var fileHeaders = fileAsStrArr[0].Split(';');

            for (var i = 1; i < fileAsStrArr.Length; i++)
            {
                var args = fileAsStrArr[i].Split(';');
                var id = int.Parse(args[Array.IndexOf(fileHeaders, "id")]);
                var price = float.Parse(args[Array.IndexOf(fileHeaders, "price")], CultureInfo.InvariantCulture);
                var name = args[Array.IndexOf(fileHeaders, "name")];
                var weight = int.Parse(args[Array.IndexOf(fileHeaders, "weight")]);
                var calories = int.Parse(args[Array.IndexOf(fileHeaders, "calories")]);

                desserts.Add(new Dessert(id, price, name, weight, calories));
            }

            return desserts;
        }
    }
}
