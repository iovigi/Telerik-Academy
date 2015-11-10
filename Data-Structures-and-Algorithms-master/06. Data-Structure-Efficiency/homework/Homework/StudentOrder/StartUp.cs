
using System;
using System.Linq;

namespace StudentOrder
{
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<Fullname>> courseDictionary = new SortedDictionary<string, SortedSet<Fullname>>();

            using (FileStream fs = new FileStream("students.txt", FileMode.Open))
            {
                StreamReader reader = new StreamReader(fs);

                while (!reader.EndOfStream)
                {
                  var lineItems =  reader.ReadLine().Split('|').Select(x => x.Trim()).ToArray();

                    SortedSet<Fullname> students;

                    if (!courseDictionary.TryGetValue(lineItems[2], out students))
                    {
                        students = new SortedSet<Fullname>();

                        courseDictionary.Add(lineItems[2], students);
                    }

                    students.Add(new Fullname()
                    {
                        FirstName = lineItems[0],
                        LastName = lineItems[1]
                    });
                }
            }

            foreach (var course in courseDictionary)
            {
                Console.WriteLine("{0}:{1}", course.Key, string.Join(",", course.Value));
            }
        }
    }
}
