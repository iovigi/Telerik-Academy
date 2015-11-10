namespace ProductProccesor
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();
            Random rand = new Random();

            for (int i = 0; i < 500000; i++)
            {
                bag.Add(new Product()
                {
                    Name = i.ToString(),
                    Price = rand.NextDouble()
                });
            }

            for (int i = 0; i < 10000; i++)
            {
                var firstIndex = rand.Next(0, bag.Count);
                var firstProduct = bag[firstIndex];
                var secondIndex = rand.Next(0, bag.Count);
                var secondProduct = bag[secondIndex];

                if(firstProduct.Price > secondProduct.Price)
                {
                    var temp = firstProduct;
                    firstProduct = secondProduct;
                    secondProduct = firstProduct;
                }

                var products = bag.Range(firstProduct, true, secondProduct, true).Take(20);

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}
