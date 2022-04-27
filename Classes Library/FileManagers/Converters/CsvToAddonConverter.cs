using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FileManagers.Converters
{
    public static class CsvToAddonConverter
    {
        public static List<Addon> Convert(string fileContent)
        {
            var addons = new List<Addon>();
            var fileAsStrArr = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var fileHeaders = fileAsStrArr[0].Split(';');

            for (var i = 1; i < fileAsStrArr.Length; i++)
            {
                var args = fileAsStrArr[i].Split(';');
                var id = int.Parse(args[Array.IndexOf(fileHeaders, "id")]);
                var price = float.Parse(args[Array.IndexOf(fileHeaders, "price")], CultureInfo.InvariantCulture);
                var name = args[Array.IndexOf(fileHeaders, "name")];
                var volume = int.Parse(args[Array.IndexOf(fileHeaders, "volume")]);
                var sauce = args[Array.IndexOf(fileHeaders, "sauce")] == "1";

                addons.Add(new Addon(id, price, name, volume, sauce));
            }

            return addons;
        }
    }
}
