using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FoodModels
{
    public class Dessert : Product
    {
        public int Weight { get; }
        public int Calories { get; }

        public Dessert(int id, float price, string name, int weight, int calories) : base(id, price, name)
        {
            Weight = weight;
            Calories = calories;
        }

        public override string ToStringAsInfoElement()
        {
            return base.ToStringAsInfoElement() + $", {Weight}g, Cal.{Calories}";
        }
    }
}
