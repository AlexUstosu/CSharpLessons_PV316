using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Console;

namespace ConsoleApp1
{
    public class Person
    {
        public String Name { get; set; }
        public String LastName { get; set;}
        public DateTime BirthDay { get; set;}

    }
    internal class Program
    {


        public delegate string VoidDelegate();

        public static void FullName(Person person)
        {
            Console.WriteLine( $"{person.Name} - {person.LastName}");
        }
        //Predicate<int> IsPredicate = (int x) => x > 0; //Predicate<T>
        //IsPredicate(8);
        public static bool OnWinter( Person person )
        {
            return person.BirthDay.Month == 12 || person.BirthDay.Month >= 1
                && person.BirthDay.Month < 3;
        }

        //Func<int, int, string> new_string = (a, b) => $"{a}{b}";    //Func<TResult>
        //new_string(2, 3);
        public string method(int a, int b)
        {
            return $"{a}{b}";
        }
        public static string method()
        {
            return $"\t";
        }
        public static string method3()
        {
            return $"\t";
        }
        public static int SortBD(Person person1, Person person2) 
        {
           return person1.BirthDay.CompareTo(person2.BirthDay);
        }
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>
            {
            new Person{Name = "Василий", LastName = "Трушевский", BirthDay = new DateTime(1968,10,12)},
            new Person{Name = "Антонина", LastName = "Астафьева", BirthDay = new DateTime(1983,6,2)},
            new Person{Name = "Савва", LastName = "Азаренков", BirthDay = new DateTime(1977,5,16)},
            new Person{Name = "Роман", LastName = "Островский", BirthDay = new DateTime(2000,3,12)},
            new Person{Name = "Георгий", LastName = "Яков", BirthDay = new DateTime(1971,12,5)},
            };

            Console.WriteLine("Employeers:");

            List<Person> peopleOnWinter = list.FindAll(OnWinter);

            list.ForEach(FullName);         //Action<T>
            Action<int> action = (int s) => Console.WriteLine(s);
            action(6);


            list.Sort(SortBD);              //Comparision<T>

            Comparison<int> comparison = (int x, int y) => y > x ? -1 : 1;
            comparison(8, 7);




            //1 шаг
            VoidDelegate voidDelegate1 = new VoidDelegate(method);

            //2 шаг
            VoidDelegate voidDelegate2 = method;

            //3 шаг
            voidDelegate2 += method3;

            //4 шаг
            VoidDelegate voidDelegate = delegate()
            {
                String str = "Anonimus Method";
                return str;
            };
            voidDelegate();

            //5 шаг 
            VoidDelegate lazyDelegate = () => { return "Lazy lambda method"; };
            lazyDelegate();







            auto a = [](int a, int b)
            {
                return a + b;
            }



            []() noexept { throw 20; }();



            Console.ReadKey();
        }
    }
}
