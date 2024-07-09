using System;
using System.Collections;
using System.Globalization;
using static System.Console;

namespace ConsoleApp1
{
    class Person
    {
        public string FIO { get; set; }
        public DateTime birthDay { get; set; }
        public string Address { get; set; }

        public Person()
        {
            FIO = "Иванов Иван Иванович";
            birthDay = DateTime.Now;
            Address = String.Empty;
        }
        public Person(string fio)
        {
            FIO = fio;
            birthDay = DateTime.Now;
            Address = String.Empty;
        }
        public Person(string fio, DateTime date, string address)
        {
            FIO = fio;
            birthDay = date;
            Address = address;
        }
        public string Show()
        {
            return $"ФИО: {FIO}, День рождения: {birthDay}, Адрес: {Address}";
        }
    }
    class Employee
    {
        Person Person { get; set; }
        public double Salary { get; set; }

        private DateTime startYear;
        public DateTime StartYear 
        {
            get { return startYear; } 
            set
            {
                if (value > DateTime.Now)
                    startYear = DateTime.Now;
                else
                    startYear = value;
            }
        }
        public Employee()
        {
            Person = new Person();
            Salary = 128000.56D;
            StartYear = new DateTime(2000, 12, 3);
        }
        public Employee(Person person, double salary, DateTime date)
        {
            Person = person;
            Salary = salary;
            StartYear = date;
        }
        public int CurrentSeniority()
        {
            return DateTime.Now.Year - StartYear.Year;
        }
        public int CountDaysOfSeniotity()
        {
            int years = CurrentSeniority();
            return years * 365;
        }

        public void Show()
        {
            Console.WriteLine($"Employee: {Person.Show()} - Salary: {Salary.ToString()}\t" +
                             $"StartYear: {StartYear.Year.ToString()}");
        }
    }

    class Manager : Employee
    {
        public Manager() : base()
        {
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Employee[] employees =
            {
                new Employee(new Person("Емильян Федорович Петров"),25369.85,new DateTime(2001,3,25)),
                new Employee(new Person("Светлана Владимировна Агапова"),127333.01,new DateTime(2023,5,25)),
                new Employee(new Person("Юлия Борисовна Михеева"),35600,new DateTime(2019,3,25)),
                new Employee(new Person("Андрей Вячеславович Богатько"),78001.20,new DateTime(1990,3,25))
            };

            foreach (var employee in employees)
            {
                employee.Show();
                Console.WriteLine($"Стаж: {employee.CurrentSeniority()}\t Дней: {employee.CountDaysOfSeniotity()}");

            }


            Console.ReadKey();

        }
    }
}