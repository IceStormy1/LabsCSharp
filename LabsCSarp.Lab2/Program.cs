using System;

namespace LabsCSharp.Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 1");
            Console.WriteLine("Выполнил - Толмачев Михаил Евгеньевич ВИС-32\n");

            #region Ex1
            var firstRectangle = new Rectangle()
            {
                Height = 20,
                Width = 30,
                Name = "A"
            };

            var secondtRectangle = new Rectangle()
            {
                Height = 50,
                Width = 110,
                Name = "A"
            };

            Console.WriteLine($"Area {firstRectangle.Name}: {firstRectangle.GetArea()}");
            Console.WriteLine($"Area {secondtRectangle.Name}: {secondtRectangle.GetArea()}");
            Console.WriteLine();
            #endregion

            var circle = new Circle
            {
                Radius = 5
            };
            PrintArea(circle);

            var parallelogram = new Parallelogram
            {
                A = 20,
                H = 25
            };
            PrintArea(parallelogram);

            var regularDecagon = new RegularDecagon
            {
                A = 10
            };
           PrintArea(regularDecagon);

            var regularPentagon = new RegularPentagon
            {
                A = 17
            };
            PrintArea(regularPentagon);

            var rhomb = new Rhomb
            {
                A = 20,
                H = 25
            };
            PrintArea(rhomb);

            var square = new Square
            {
                Height = 5,
                Width = 5
            };
            PrintArea(square);

            var trapezouid = new Trapezoid
            {
                A = 7,
                B = 10,
                H = 15
            };
            PrintArea(trapezouid);
        }

        private static void PrintArea<T>(T figure) where T : class, IFigure 
        {
            Console.WriteLine($"The area {typeof(T).Name} is equal {figure.GetArea()}");
        }
    }
}
