using System;

namespace LabsCSharp.Lab2
{
    public class RegularPentagon : IFigure
    {
        public double A { get; set; }

        public RegularPentagon()
        {
            if (A < 0)
                throw new Exception();
        }

        public double GetArea()
        {
            return Math.Pow(A, 2) / 4 * Math.Sqrt(25 + 10 * Math.Sqrt(5));
        }
    }
}
