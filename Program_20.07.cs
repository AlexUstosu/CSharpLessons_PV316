using System;
using System.Collections;
using System.Globalization;
using System.Xml.Serialization;
using static System.Console;

namespace ConsoleApp1
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X - {X}\tY - {Y}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;

            return p;
        }

        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }

        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator +(int n, Point p2)
        {
            return new Point(n + p2.X, n + p2.Y);
        }
        public static Point operator +(Point p1, int n)
        {
            return new Point(p1.X + n, p1.Y + n);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X > p2.X && p1.Y > p2.Y;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }
        public static bool operator true(Point p)
        {
            return (p.X != 0 && p.Y != 0) ? true : false;
        }
        public static bool operator false(Point p)
        {
            return (p.X == 0 && p.Y == 0) ? true : false;
        }
        public static Point operator &(Point p1, Point p2)
        {
            if ((p1.X != 0 && p1.Y != 0) && (p2.X != 0 && p2.Y != 0))
                return p2;
            return new Point();
        }
        public static explicit operator int(Point p)
        {
            return p.X + p.Y;
        }

    }
    class Straight
    {
        Point[] array;

        public int Lenght { get { return array.Length; } }

        public Straight(int size)
        {
            array = new Point[size];
        }
        public Point this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];

                throw new IndexOutOfRangeException();

            }
            set
            {
                array[index] = value;
            }
        }
    }

    class Plane
    {
        private Point[,] points;

        public int Row { get; set; }
        public int Column { get; set; }

        public Plane(int rows, int columns)
        {
            Row = rows;
            Column = columns;
            points = new Point[rows, columns];
        }
        public Point this[int row, int column]
        {
            get { return points[row, column]; }
            set { points[row, column] = value;}
        }
    }


    class Triangle : ISquere
    {
        Point _p1;
        Point _p2;
        Point _p3;

        public Triangle()
        {
            _p1 = new Point();
            _p2 = new Point();
            _p3 = new Point();
        }
        public Triangle(Point p1, Point p2, Point p3) // 3 2 7 5 0 0 
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public void method()
        {

        }

        public double FindSquare()
        {
            int[,] array = new int[2, 2];
            array[0, 0] = _p1.X - _p3.X;
            array[0, 1] = _p2.X - _p3.X;
            array[1, 0] = _p1.Y - _p3.Y;
            array[1, 1] = _p2.Y - _p3.Y;

            double result = 0.5 * (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]);
            return result;
        }
    }

    class Quadrant : ISquere
    {
        Point _p1;
        Point _p2;
        Point _p3;
        Point _p4;

        public Quadrant()
        {
            _p1 = new Point();
            _p2 = new Point();
            _p3 = new Point();
            _p4 = new Point();
        }
        public Quadrant(Point p1, Point p2, Point p3, Point p4) 
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
        }

        public double FindSquare()
        {
            int[,] array = new int[2, 2];
            array[0, 0] = _p1.X - _p3.X;
            array[0, 1] = _p2.X - _p3.X;
            array[1, 0] = _p1.Y - _p3.Y;
            array[1, 1] = _p2.Y - _p3.Y;

            double result = 0.5 * (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]);
            return result;
        }
    }
    public interface ISquere
    {
        object this[int index]
        {
            get;
            set;
        }
        int MyProperty { get; set; }
        double FindSquare();
    }

    public class MyClass : ISquere
    {
        
    }


    public class MyException : ApplicationException
    {
        public DateTime TimeException { get; private set; }
        public MyException() :base("MOE ИСКЛЮЧЕНИЕ")
        {
            TimeException = DateTime.Now;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[6];
            int index = 0;
            try
            {
                for (int i = -5; i <= 6; i++)
                {
                    try
                    {
                        array[index] = 2 / i;
                        Console.WriteLine($"{array[index]}");
                        index++;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"ВЛОЖЕННОЕ ИСКЛЮЧЕНИЕ {ex.Message}");
                        throw new MyException();
                    }
                }
            }
            catch (MyException)
            {

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"ВНЕШНЕЕ ИСКЛЮЧЕНИЕ  {ex.Message}");
            }


            Triangle triangle = new Triangle(new Point(3, 2), new Point(7, 5), new Point());

            Console.WriteLine($"Square = {triangle.FindSquare()}");


            ISquere[] squere = { new Triangle(), new Quadrant() };

            ((Triangle)squere[0]).method();
            squere[1].FindSquare();


            

            Console.ReadKey();

        }
    }
}