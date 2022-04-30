using System;

namespace LabsCSharp.Lab2
{
    public class Rhomb : IFigure
    {
        public double A { get; set; }
        public double H { get; set; }

        public Rhomb()
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
