using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FoodModels
{
    public class Sandwich : Product
    {
        public int Weight { get; }
        public string Vege { get; }

        public Sandwich(int id, float price, string name, int weight, bool vege): base(id, price, name)
        {
            Weight = weight;
            Vege = vege ? "VEGE" : string.Empty;
        }

        public override string ToStringAsInfoElement()
        {
            return base.ToStringAsInfoElement() + $", {Weight}g" + (Vege != string.Empty ? $", {Vege}" : string.Empty);
        }
    }
}
