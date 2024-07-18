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

    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point();
            Point point2 = new Point(10, -5);

            Straight straight = new Straight(10);
            for (int i = 0; i < straight.Lenght; i++)
            {
                straight[i] = new Point(0, 15);
            }

            Plane plane = new Plane(5, 8);
            plane[0, 2] = new Point(1, 0);



            Point p3 = -point2;

            Console.WriteLine(point1++.ToString());

            Console.ReadKey();

        }
    }
}