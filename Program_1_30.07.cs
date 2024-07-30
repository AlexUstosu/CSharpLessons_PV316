using System;

namespace ConsoleApp1
{
    public partial class MathsOperations
    {
        public int Summ(int num1, int num2)
        {
            return num1;
        }
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Substract(double num1, double num2)
        {
            return num1 - num2;
        }
        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public delegate double MyDelegate(double a, double b);
    internal class Program
    {
        static void Main(string[] args)
        {
            MathsOperations mathsOperations = new MathsOperations();

            MyDelegate myDelegate = mathsOperations.Add;
            myDelegate += MathsOperations.Substract;
            myDelegate += mathsOperations.Multiply;
            myDelegate += mathsOperations.Divide;

            foreach (MyDelegate item in myDelegate.GetInvocationList())
            {
                try
                {
                    Console.WriteLine($"Result = {item(15.3, 8.1)}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }



            string expr = Console.ReadLine();

            char choice = 'a';
            foreach (char item in expr)
            {
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    choice = item;
                    break;
                }
            }
            try
            {
                List<string> strings = new List<string>(expr.Split(choice));



                switch (choice)
                {
                    case '+':
                        myDelegate = mathsOperations.Add;
                        break;
                    case '-':
                        myDelegate = MathsOperations.Substract;
                        break;
                    case '*':
                        myDelegate = mathsOperations.Multiply;
                        break;
                    case '/':
                        myDelegate = mathsOperations.Divide;
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                double result = myDelegate(double.Parse(strings[0]), double.Parse(strings[1]));
                Console.WriteLine($"Result = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.ReadKey();

        }
    }

}
