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

    class Word
    {
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }

        public override string ToString()
        {
            return $"{Source} - {Target}";
        }
    }
    class Dictionary
    {
        Word[] words;
        public Dictionary()
        {
            words = new Word[]
            {
                new Word("sound", "звук"),
                new Word("way", "путь"),
                new Word("bullet", "пуля"),
                new Word("pull", "поятнуть"),
            };
        }
        public int Lenght { get { return words.Length; } }
        public string this[string index]
        {
            get 
            {
                Word new_word = null;
                foreach (Word item in words)
                {
                    if (item.Source == index)
                    {
                        new_word = item;
                    }
                }
                return new_word?.Target;
            }
            set 
            {
                foreach (Word item in words)
                {
                    if(item.Source == index)
                    {
                        item.Target = value;
                        break;
                    }
                }
            }
        }

        public Word this[int index]
        {
            get 
            {
                if (index >= 0 && index < words.Length)
                    return words[index];

                throw new IndexOutOfRangeException();
            }
            set 
            {
                words[index] = value;
            }
        }
    }

    class RangeOfArray
    {
        int[] array;
        public RangeOfArray(int size, int start, int end)
        {
            array = new int[size];
            Length = size;
            StartIndex = start;
            EndIndex = end;
        }

        public int Length { get; set; }
        public int StartIndex { get; set; }

        int endIndex;
        public int EndIndex 
        {
            get
            {
                return endIndex;
            }
            set 
            {
                if (value < StartIndex + Length)
                    endIndex = value;
                else
                    endIndex = StartIndex + Length;
            } 
        }

        public int this[int index]
        {
            get 
            {
                if (index >= StartIndex && index < EndIndex)
                {
                    return array[index];
                }
                return array[StartIndex];
            }
            set 
            {
                if(index >= StartIndex && index < EndIndex)
                {
                    array[index] = value;
                }
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();
            for (int i = 0; i < dictionary.Lenght; i++)
            {
                Console.WriteLine(dictionary[i]);
            }
            dictionary["way"] = "дорога";
            Console.WriteLine("\n\n");

            for (int i = 0; i < dictionary.Lenght; i++)
            {
                Console.WriteLine(dictionary[i]);
            }


            RangeOfArray rangeOfArray = new RangeOfArray(5, 9, 14);

            for (int i = rangeOfArray.StartIndex; i < rangeOfArray.EndIndex; i++)
            {
                Console.WriteLine(rangeOfArray[i]);
            }
            

            Console.ReadKey();

        }
    }
}