using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabsCSharp.Laba3
{
    class Program
    {
        public static Figure[] figures =
        {
            new Rectangle()
            {
                Name = "Квадрат 1",
                Color = Color.DarkRed,
                Position = new Point(30, 30),
                Width = 50,
                Height = 50
            },
             new Circle()
            {
                Name = "Круг",
                Color = Color.Crimson,
                Position = new Point(70, 200),
                Radius = 50
            },
             new Triangle()
            {
                Name = "Треугольник",
                Color = Color.Crimson,
                Position = new Point (200, 100),
                Height = 50,
                Base = 50
            },
            new Rhombus()
            {
                Name = "Ромб",
                Color = Color.Crimson,
                Position = new Point (200, 200),
                FirstDiagonal = 50,
                SecondDiagonal = 40
            },
            new Square()
            {
                Name = "Квадрат",
                Color = Color.Crimson,
                Position = new Point (300, 100),
                Side = 50
            },
            new Parallelogram()
            {
                Name = "Параллелограмм",
                Color = Color.Crimson,
                Position = new Point (300, 200),
                Base = 50,
                Height = 50
            },
            new RegularPentagon()
            {
                Name = "Правильный пятиугольник",
                Color = Color.Crimson,
                Position = new Point (100, 350),
                Side = 50,
                Radius = 50
            },
            new RegularDecagon()
            {
                Name = "Правильный десятиугольник",
                Color = Color.Crimson,
                Position = new Point (250, 350),
                Side = 50,
                Radius = 50
            },
            new Trapezoid()
            {
                Name = "Трапеция",
                Color = Color.Crimson,
                Position = new Point (350, 325),
                FirstBase = 50,
                SecondBase = 30,
                Height = 50
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 3");
            Console.WriteLine("Выполнил - Толмачев Михаил Евгеньевич ВИС-32");

            #region
            //var f = new Rectangle
            //{
            //    Name = "Квадрат",
            //    Color = Color.DarkRed,
            //    Position = new Point(30, 30),
            //    Width = 50,
            //    Height = 50
            //};

            //Console.WriteLine($"Фигура: {f.Name}");
            //Console.WriteLine($"Площадь: {f.GetArea()}");
            //Console.WriteLine($"Цвет: {f.Color}");
            //Console.WriteLine($"Положение фигуры: {f.Position}");
            //Console.WriteLine($"Координаты центра: {f.GetCenter()}");
            #endregion

            var form = new Form()
            {
                Text = "Лабораторная работа #3 - Полиморфизм",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            form.Paint += PaintForm;

            Application.Run(form);
        }

        private static void PaintForm(object sender, PaintEventArgs e)
        {
            foreach (var f in figures)
                f.Draw(e.Graphics);
        }
    }
}
