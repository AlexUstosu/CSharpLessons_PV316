using System;

namespace ConsoleApp1
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;

        }
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public string Show()
        {
            return $"X = {this.X}, Y = {this.Y}, Z = {this.Z}\t";
        }
    }
    class Triangle
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public Triangle()
        {
            Point1 = new Point(0, 0, 0);
            Point2 = new Point(1, 2, 3);
            Point3 = new Point(5, 1, 6);
        }
        public void Show()
        {
            Console.WriteLine($"Triangle: {Point1.Show()},  {Point2.Show()}, {Point3.Show()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            triangle.Show();

            triangle.Point1.Y = 15;
            triangle.Point1.Z = 100;


            triangle.Point2 = new Point(2, 8, 9);

            Point newPoint = triangle.Point3;

            Console.WriteLine(newPoint.Show());
            triangle.Show();

            Point p1 = null;
            int? new_x = p1?.X;     //nullable type int переменной
                                    //new_x при условии, что p1 не равно NULL
                                    //возмет значение свойства X

            Point p2 = null;                    //стандартный механизм проверки 
            if (p2 == null)                     //переменной reference-type 
                p2 = new Point(0, 0, 0);        //на NULL 

            Point p3 = null;
            p3 = p3 ?? new Point(0, 0, 0);      //Упрощенная модель проверки 
                                                //переменной reference-type 
                                                //на NULL


            Console.ReadKey();

        }
    }
}

