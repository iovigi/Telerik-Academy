using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class PersonFactory
    {
        public void CreatePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;

            if (age % 2 == 0)
            {
                newPerson.Name = "Батката";
                newPerson.Sex = Sex.Male;
            }
            else
            {
                newPerson.Name = "Мацето";
                newPerson.Sex = Sex.Female;
            }
        }
    }
}
