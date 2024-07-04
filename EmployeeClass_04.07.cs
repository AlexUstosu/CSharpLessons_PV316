using System;


namespace ConsoleApp1
{
    class Employee
    {
        public string FIO { get; set; }
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
            FIO = "Иванов Иван Иванович";
            Salary = 128000.56D;
            StartYear = new DateTime(2000, 12, 3);
        }
        public Employee(string fio, double salary, DateTime date)
        {
            FIO = fio;
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
            Console.WriteLine($"Employee: {FIO} - Salary: {Salary.ToString()}\t" +
                             $"StartYear: {StartYear.Year.ToString()}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("Емильян Федорович Петров",25369.85,new DateTime(2001,3,25)),
                new Employee("Светлана Владимировна Агапова",127333.01,new DateTime(2023,5,25)),
                new Employee("Юлия Борисовна Михеева",35600,new DateTime(2019,3,25)),
                new Employee("Андрей Вячеславович Богатько",78001.20,new DateTime(1990,3,25))
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