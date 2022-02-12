using System;

namespace LabsCSharp.Lab2
{
    public class Trapezoid : IFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }

        public Trapezoid()
        {
            if (A < 0 || B < 0 || H < 0)
                throw new Exception();
        }

        public double GetArea()
        {
            return (A + B) * H / 2;
        }
    }
}
