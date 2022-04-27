using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FoodModels
{
    public class Drink : Product
    {
        public int Size { get; }
        public string Sugar { get; }

        public Drink(int id, float price, string name, int size, bool sugar) : base(id, price, name)
        {
            Size = size;
            Sugar = sugar ? string.Empty : "SUGARFREE";
        }

        public override string ToStringAsInfoElement()
        {
            return base.ToStringAsInfoElement() + $", {Size}ml" + (Sugar == string.Empty ? string.Empty : $", {Sugar}");
        }
    }
}
