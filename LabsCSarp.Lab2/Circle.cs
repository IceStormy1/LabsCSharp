using System;

namespace LabsCSharp.Lab2
{
    public class Circle : IFigure
    {
        public double Radius { get; set; }

        public Circle()
        {
            if (Radius < 0)
                throw new Exception();
        }

        public double GetArea()
        {
            return 2 * Math.PI * Math.Pow(Radius, 2);
        }
    }
}
