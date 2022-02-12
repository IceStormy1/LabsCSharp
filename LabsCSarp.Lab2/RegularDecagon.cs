using System;

namespace LabsCSharp.Lab2
{
    public class RegularDecagon : IFigure
    {
        public double A { get; set; }

        public RegularDecagon()
        {
            if (A < 0)
                throw new Exception();
        }

        public double GetArea()
        {
            return 5.0 / 2.0 * Math.Pow(A, 2) * Math.Sqrt(5 + 2 * Math.Sqrt(5));
        }
    }
}
