using System;
using System.Collections;
using System.Globalization;
using System.Xml.Serialization;
using static System.Console;

namespace ConsoleApp1
{
    public class Point
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
    public class StraightEnum : IEnumerator
    {
        Point[] array;              //массив точек

        int position = -1;          //инициализация позиции текущего элемента начальным значений

        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }
        public void Reset()
        {
            position = -1;
        }

        public int Lenght { get { return array.Length; } }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Point Current
        {
            get 
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException ex)
                {

                    Console.WriteLine(ex.Message);
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }

        public StraightEnum(Point[] points )
        {
            array = points;
        }
    }

    public class Straight : IEnumerable
    {
        private Point[] array;

        public Straight(int size)
        {
            array = new Point[size];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StraightEnum(array);
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
            Straight straight = new Straight(10);


            foreach (var item in straight)
            {

            }

            Console.ReadKey();

        }
    }
}