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

        public static Point operator++(Point p)
        {
            p.X++;
            p.Y++;

            return p ;
        }

        public static Point operator--(Point p)
        {
            p.X--;
            p.Y--;
            return p ;
        }

        public static Point operator-(Point p)
        {
            return new Point(-p.X, -p.Y);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point();
            Point point2 = new Point(10,-5);

            Point p3 = -point2;

            Console.WriteLine(point1++.ToString());

            Console.ReadKey();

        }
    }
}