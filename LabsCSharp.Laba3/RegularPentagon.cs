using System;
using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class RegularPentagon : Figure
    {
        public double Side { get; set; }
        public double Radius { get; set; }


        public override double GetArea()
        {
            return Side * Side / 4 * Math.Sqrt(25 + 10 * Math.Sqrt(5));
        }

        public override Point GetCenter()
        {
            return new Point(Position.X, Position.Y);
        }

        public override void Draw(Graphics graphics)
        {
            var points = new Point[5];
       
            for (int a = 0; a < 5; a++)
            {
                points[a] = new Point(
                    (int)(Position.X + Radius * (float)Math.Cos(a * 72 * Math.PI / 180f)),
                    (int)(Position.Y + Radius * (float)Math.Sin(a * 72 * Math.PI / 180f)));
            }

            graphics.DrawPolygon(new Pen(Color), points);
            graphics.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
