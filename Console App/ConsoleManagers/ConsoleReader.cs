using Classes_Library.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.ConsoleManagers
{
    public static class ConsoleReader
    {
        public static int ReadProductId<T>(string message, List<T> product) where T : Product
        {
            while (true)
            {
                Console.WriteLine(message);

                try
                {
                    var index = int.Parse(Console.ReadLine());

                    if (product.FindIndex(p => p.Id == index) < 0)
                    {
                        Console.WriteLine("To nie jest prawidłowy indeks produktu");
                        continue;
                    }

                    return index;
                }
                catch (Exception)
                {
                    Console.WriteLine("To nie jest prawidłowa liczba!");
                }
            }
        }
    }
}
