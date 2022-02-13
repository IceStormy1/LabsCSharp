using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Triangle : Figure
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Base / 2), (int)(Position.Y + Height / 2));
        }

        public override void Draw(Graphics graphics)
        {
            var points = new Point[3];

            points[0] = new Point(Position.X + 0, Position.Y + 0);
            points[1] = new Point(Position.X + 0, Position.Y + (int)Height);
            points[2] = new Point(Position.X + (int)Base, Position.Y + (int)Height);

            graphics.DrawPolygon(new Pen(Color), points);
            graphics.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
