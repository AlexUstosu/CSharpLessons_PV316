using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;

namespace ConsoleApp1
{
    public class Person
    {
        public String Name { get; set; }
        public String LastName { get; set;}
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Name} - {LastName}";
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Job { get; set; }
    }
    static class ExtantionClass
    {
        public static int NumberWords(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = Regex.Replace(text.Trim(), @"[\s,\.]+", " ");
                return text.Split(' ').Length;
            }
            else
                return 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string str = "rftghjkop.......      fjkfbglf gh    gh   ";

            int l = str.NumberWords();

            int[] array = { 7, 88, -10, 15, 20, 130, -3, 0, 62, 51, -101 };

            IEnumerable<IGrouping<int,int>> query = from i in array group i by i % 10
                                                    into j where j.Key > 0 select j;

            string str_q = String.Empty;
            string str_k = String.Empty;
            foreach (IGrouping<int, int> group in query)
            {
                str_k += group.Key.ToString() + " ";
                foreach (var item in group)
                {
                    str_q += item.ToString() + " ";
                }
            }

            string[] text = {"Lorem ipsum dolor sit amet, consectetur ",
                "adipiscing elit, sed do eiusmod tempor incididunt ut ",
                "labore et dolore magna aliqua. Velit scelerisque in dictum ",
                "non consectetur a erat.Sit amet justo donec enim diam ",
                "vulputate.Id aliquet lectus proin nibh nisl condimentum id ",
                "venenatis a. Eget gravida cum sociis natoque penatibus et ",
                "magnis dis.Habitant morbi tristique senectus et netus et.",
                "Interdum consectetur libero id faucibus nisl tincidunt eget ",
                "nullam.Aliquam purus sit amet luctus.Fringilla ut morbi ",
                "tincidunt augue interdum velit.Neque sodales ut etiam sit." };

            IEnumerable<String> query_text = from t in text let words = t.Split(' ', ',','.')
                                             from word in words where word.Length < 6 select word;
            str_q = String.Empty;
            foreach (var item in query_text)
            {
                str_q += item.ToString() + " ";
            }



            List<Person> people = new List<Person>
            {
                new Person{Name = "Василий", LastName = "Трушевский", Id = 1},
                new Person{Name = "Антонина", LastName = "Астафьева", Id = 2},
                new Person{Name = "Савва", LastName = "Азаренков", Id = 2},
                new Person{Name = "Роман", LastName = "Островский", Id = 2},
                new Person{Name = "Георгий", LastName = "Яков", Id = 1},
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee {Id = 2, Job = "Manager"},
                new Employee {Id = 1, Job = "Programmer"},
                new Employee {Id = 3, Job = "Economist"},
            };

            var query_people = from e in employees
                                               join p in people 
                                               on e.Id equals p.Id into result
                                               from r
                                               in result
                                               select r;
            foreach (var item in query_people)
            {
                Console.WriteLine($"{item.Name} - {item.LastName}\n");
                Console.WriteLine($"Job: {employees.First(e => e.Id == item.Id).Job}");
            }

            Console.ReadKey();
        }
    }
}
