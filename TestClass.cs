using System;

namespace ConsoleApp1
{
    public class MathsOperations
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public double Substract(double num1, double num2)
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
    internal class TestClass
    {
        MathsOperations MathsOperations;
        public TestClass()
        {
            MathsOperations = new MathsOperations();
        }

        public void Test_Add()
        {
            Console.WriteLine("Testing Add method:");
            double result = 0.0;
            string flag;

            result = MathsOperations.Add(0, 0);
            flag = result == 0 ? "successfully" : "failed";
            Console.WriteLine("Test numder 1 - " + flag);


            result = MathsOperations.Add(10, 5);
            flag = result == 2 ? "successfully" : "failed";
            Console.WriteLine("Test numder 2 - " + flag);

        }
    }
}
