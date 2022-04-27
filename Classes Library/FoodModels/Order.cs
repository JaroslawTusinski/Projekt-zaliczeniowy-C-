using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Library.FoodModels
{
    public class Order
    {
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                CalcPrice();
            }
        }
        private DateTime _dateTime;
        public Sandwich Sandwich
        {
            get => _sandwich;
            set
            {
                _sandwich = value;
                CalcPrice();
            }
        }
        public Sandwich _sandwich;
        public Dessert Dessert
        {
            get => _dessert;
            set
            {
                _dessert = value;
                CalcPrice();
            }
        }
        public Dessert _dessert;
        public Drink Drink
        {
            get => _drink;
            set
            {
                _drink = value;
                CalcPrice();
            }
        }
        public Drink _drink;
        public Addon Addon
        {
            get => _addon;
            set
            {
                _addon = value;
                CalcPrice();
            }
        }        
        public Addon _addon;
        public float Price { get; private set; }
        public string Id { get; }

        public Order(int id, Sandwich sandwich = null, Drink drink = null, Dessert dessert = null, Addon addon = null)
        {
            _dateTime = DateTime.Now;
            _sandwich = sandwich;
            _dessert = dessert;
            _drink = drink;
            _addon = addon;
            Id = id > 9 ? id.ToString() : $"0{id}";
            CalcPrice();
        }

        public string ToSummaryString()
        {
            var sb = new StringBuilder("Podsumowanie zamówienia:");
            if (_sandwich != null) sb.Append($"\nKanapka: {_sandwich.ToStringAsInfoElement()}");
            if (_drink != null) sb.Append($"\nNapój: {_drink.ToStringAsInfoElement()}");
            if (_dessert != null) sb.Append($"\nDeser: {_dessert.ToStringAsInfoElement()}");
            if (_addon != null) sb.Append($"\n{_addon.ToStringAsInfoElement()}");
            
            sb.Append($"\nPodsumowanie:\nDo zapłaty razem: {Price.ToString("N2")} zł");
            return sb.ToString();
        }

        public string ToNotifyString()
        {
            return ToString($"{_dateTime.ToString("dd.MM.yyyy HH:mm:ss")}{Environment.NewLine}Cena: {Price.ToString("N2")}PLN{Environment.NewLine}");
        }

        public override string ToString()
        {
            return ToString($"{Id}, {_dateTime.ToString("HH:mm:ss")}, {Price.ToString("N2")}PLN: ");
        }

        private string ToString(string beforeProducts)
        {
            var existingProducts = new List<string>();

            if (_sandwich != null) existingProducts.Add(_sandwich.ToString());
            if (_drink != null) existingProducts.Add(_drink.ToString());
            if (_dessert != null) existingProducts.Add(_dessert.ToString());
            if (_addon != null) existingProducts.Add(_addon.ToString());

            return beforeProducts + string.Join(",", existingProducts);
        }

        private void CalcPrice()
        {
            Price = (_sandwich != null ? _sandwich.Price : 0)
                + (_dessert != null ? _dessert.Price : 0)
                + (_drink != null ? _drink.Price : 0)
                + (_addon != null ? _addon.Price : 0);
        }
    }
}
