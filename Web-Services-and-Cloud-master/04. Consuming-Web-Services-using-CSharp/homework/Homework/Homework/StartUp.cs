namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Linq;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        { 
            Console.WriteLine("Please input title, which you search(for all empty string).");
            string title = Console.ReadLine();

            Console.WriteLine("Please input count of post?");

            int count = 0;

            while(!int.TryParse(Console.ReadLine(),out count))
            {
                Console.WriteLine("Please put valid count.");
            }

            WebClient client = new WebClient();
            var jsonContent = client.DownloadString("http://jsonplaceholder.typicode.com/posts");

            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(jsonContent)
                .Where(x=> x.title.ToLower().Contains(title.ToLower()))
                .Take(count);

            foreach(var post in posts)
            {
                Console.WriteLine(post);
            }
        }
    }
}
