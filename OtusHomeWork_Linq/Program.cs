using System;
using System.Collections.Generic;
using System.Linq;

namespace OtusHomeWork_Linq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int i in list.Top(30))
            {
                Console.WriteLine(i);
            }

            var person1 = new Person { Id = 1, Age = 40 };
            var person2 = new Person { Id = 7, Age = 7 };
            var person3 = new Person { Id = 3, Age = 21 };
            var person4 = new Person { Id = 22, Age = 81 };
            var person5 = new Person { Id = 11, Age = 12 };
            var person6 = new Person { Id = 57, Age = 82 };
            var person7 = new Person { Id = 4, Age = 51 };
            var person8 = new Person { Id = 0, Age = 30 };
            var person9 = new Person { Id = 35, Age = 70 };

            var listPerson = new List<Person>
            {
                person1,
                person2,
                person3,
                person4,
                person5,
                person6,
                person7,
                person8,
                person9
            };

            foreach (Person i in listPerson.Top(30, person => person.Age))
            {
                Console.WriteLine($"ID = {i.Id} - Age = {i.Age}");
            }
        }

        public static IEnumerable<int> Top(this IEnumerable<int> collection, int percent)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Необходимо указать число от 1 до 100");
            }
            var sortList = collection.OrderByDescending(x => x);
            var value = Math.Ceiling((double)percent * Count(collection) / 100);
            return sortList.Take((int)value);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percent, Func<T, int> func)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Введите число от 1 до 100");
            }
            var sortList = collection.OrderByDescending(func);
            var range = Math.Ceiling((double)percent * Count(collection) / 100);
            return (sortList.Take((int)range));
        }

        public static int Count<T>(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (T i in collection)
            {
                count++;
            }
            return count;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }
}