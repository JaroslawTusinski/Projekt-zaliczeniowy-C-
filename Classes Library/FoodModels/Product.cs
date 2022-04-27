namespace Classes_Library.FoodModels
{
    public abstract class Product
    {
        public int Id { get; }
        public string Name { get; }
        public float Price { get; }

        public Product(int id, float price, string name)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual string ToStringAsInfoElement()
        {
            return $"{Name}, {Price.ToString("N2")}PLN";
        }

        public virtual string ToStringAsListElement()
        {
            return $"{Id}\t" + ToStringAsInfoElement();
        }
    }
}
