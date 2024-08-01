using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Person
    {
        public String Name { get; set; }
        public String LastName { get; set;}
        public DateTime BirthDay { get; set;}

        public void StartWork(string task)
        {
            Console.WriteLine($"Emploee - {Name} do this task: {task}");
        }
    }

    public delegate void WorkDelegate(string task);  
    public class MainManager
    {
        SortedList<int, WorkDelegate> sortedEvents = new SortedList<int, WorkDelegate>();
        Random  random = new Random();

        public event WorkDelegate WorkEvent
        {
            add
            {
                for (int key; ;)
                {
                    key = random.Next();
                    if (!sortedEvents.ContainsKey(key))
                    {
                        sortedEvents.Add(key, value);
                        break;
                    }
                }
            }
            remove
            {
                sortedEvents.RemoveAt(sortedEvents.IndexOfValue(value));
            }
        }
        public void StartWork(string task)
        {
            foreach (var item in sortedEvents.Keys)
            {
                if (sortedEvents[item] != null)
                {
                    sortedEvents[item](task);
                }
            }
            //if(WorkEvent != null)
            //{
            //    WorkEvent(task);
            //}

        }
    }
    
    internal class Program
    {
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

            MainManager mainManager = new MainManager();
            foreach (Person item in list)
            {
                mainManager.WorkEvent += item.StartWork;
            }


            Person person = new Person { Name = "Михаил", LastName = "Добров", BirthDay = new DateTime(2005, 3, 8) };
            mainManager.WorkEvent += person.StartWork;

            Console.WriteLine("Send task 1 to all employeers");
            mainManager.StartWork($"Task №1");

            mainManager.WorkEvent -= person.StartWork;

            Console.WriteLine("\nSend task 2 to all employeers IN LIST");
            mainManager.StartWork($"Task №2");

            Console.ReadKey();
        }
    }
}
