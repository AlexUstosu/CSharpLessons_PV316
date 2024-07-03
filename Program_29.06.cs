using System;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{
    class MyClass
    {
        void Method(MyClass obj)
        {
            Method(this);
        }
    }
    class Point
    {
        int _x;
        int _y;
        public int _z;

        static string quarter;

        readonly int _a;
        static Point()
        {
            quarter = string.Empty;
        }
        public Point(int x, int y, int z, int a) 
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public Point(int a): this(10,10,10,10)
        {
            this._a = a;
        }
        public Point()
        {
            _x = 5;
            _y = 1;
            _z = 2;
        }
        public bool IncreaseX(in int x)
        {
            _x *= x;
            return true;
        }
    }
    internal class Program
    {
        enum Mounth : ulong { January = 1, February, March, April = 1, May, June, July };
        static void Main(string[] args)
        {
            int x = 100;
            Point point = new Point();
            point.IncreaseX(x);

            x -= 50;
            
            Console.ReadKey();

        }
    }
}