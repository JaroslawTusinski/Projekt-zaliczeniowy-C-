using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.ConsoleManagers
{
    public static class ConsoleWriter
    {
        public static void DisplayProductList<T>(string message, List<T> products) where T : Product
        {
            Console.WriteLine(message);

            foreach (var product in products)
                Console.WriteLine(product.ToStringAsListElement());
        }
    }
}
