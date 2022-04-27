using System.Collections.Generic;
using System.Globalization;

namespace Classes_Library.FoodModels
{
    public class Addon : Product
    {
        public int Volume { get; }
        public string Sauce { get; }

        public Addon(int id, float price, string name, int volume, bool sauce) : base(id, price, name)
        {
            Volume = volume;
            Sauce = sauce ? "EXTRA SOS" : string.Empty;
        }

        public override string ToStringAsInfoElement()
        {
            return base.ToStringAsInfoElement() + $", {Volume}g" + (Sauce != string.Empty ? $", {Sauce}" : string.Empty);
        }

        public override string ToStringAsListElement()
        {
            return $"{Id}\t" + base.ToStringAsInfoElement();
        }
    }
}
