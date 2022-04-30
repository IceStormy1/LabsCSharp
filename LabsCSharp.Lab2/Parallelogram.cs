using System;

namespace LabsCSharp.Lab2
{
    public class Parallelogram : IFigure
    {
        public double A { get; set; }
        public double H { get; set; }

        public Parallelogram()
        {
            if (A < 0 || H < 0)
                throw new Exception();
        }

        public double GetArea()
        {
            return A * H;
        }
    }
}
