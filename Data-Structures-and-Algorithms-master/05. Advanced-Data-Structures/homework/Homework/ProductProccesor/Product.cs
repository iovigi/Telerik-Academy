namespace ProductProccesor
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("Name:{0},Price:{1}", this.Name, this.Price);
        }
    }
}
