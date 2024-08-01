﻿using System;
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
        public event WorkDelegate WorkEvent;
        public void StartWork(string task)
        {
            Console.WriteLine($"MainManager:StartWork");
            if(WorkEvent != null)
            {
                WorkEvent(task);
            }
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
            foreach (var item in list)
            {
                mainManager.WorkEvent += item.StartWork;
            }

            for (int i = 0; i < 5; i++)
            {
                mainManager.StartWork($"Task {i + 1}");
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
