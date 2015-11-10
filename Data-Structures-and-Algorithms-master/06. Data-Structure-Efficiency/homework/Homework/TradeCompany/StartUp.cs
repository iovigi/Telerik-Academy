using System;

namespace TradeCompany
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ArticleStore store = new ArticleStore();

            for (int i = 0; i < 1000; i++)
            {
                store.Add(new Article()
                {
                    Barcode = i.ToString(),
                    Price = i,
                    Title = i.ToString(),
                    Vendor = i.ToString()
                });
            }

            foreach (var article in store.Range(100,200))
            {
                Console.WriteLine(article.Title);
            }
        }
    }
}
