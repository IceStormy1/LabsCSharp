using System;

namespace LabsCSharp.Lab2
{
    public class Square : Figure
    {
        public Square()
        {
            if (!Height.Equals(Width))
                throw new Exception();

            if (Height < 0 || Width < 0)
                throw new Exception();
        }

        public override double GetArea()
        {
            return Height * Height;
        }
    }
}
