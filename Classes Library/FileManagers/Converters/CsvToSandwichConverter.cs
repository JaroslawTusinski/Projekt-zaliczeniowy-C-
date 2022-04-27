using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FileManagers.Converters
{
    public static class CsvToSandwichConverter
    {
        public static List<Sandwich> Convert(string fileContent)
        {
            var sandwiches = new List<Sandwich>();
            var fileAsStrArr = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var fileHeaders = fileAsStrArr[0].Split(';');

            for (var i = 1; i < fileAsStrArr.Length; i++)
            {
                var args = fileAsStrArr[i].Split(';');
                var id = int.Parse(args[Array.IndexOf(fileHeaders, "id")]);
                var price = float.Parse(args[Array.IndexOf(fileHeaders, "price")], CultureInfo.InvariantCulture);
                var name = args[Array.IndexOf(fileHeaders, "name")];
                var weight = int.Parse(args[Array.IndexOf(fileHeaders, "weight")]);
                var vege = args[Array.IndexOf(fileHeaders, "vege")] == "1";

                sandwiches.Add(new Sandwich(id, price, name, weight, vege));
            }

            return sandwiches;
        }
    }
}
