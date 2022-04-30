using System;

namespace LabsCSharp.Lab2
{
    public class Triangle : IFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle()
        {
            if (Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2)) < C)
                throw new Exception();
        }

        public double GetArea()
        {
            var halfPerimeter = (A + B + C) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
        }
    }
}
