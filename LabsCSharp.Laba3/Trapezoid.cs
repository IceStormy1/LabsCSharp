using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Trapezoid : Figure
    {
        public double FirstBase { get; set; }
        public double SecondBase { get; set; }
        public double Height { get; set; }

        public override double GetArea() => (FirstBase + SecondBase) * 0.5 * Height;

        public override Point GetCenter() => new Point((int)(Position.X + FirstBase / 2), (int)(Position.Y + Height / 2));

        public override void Draw(Graphics graphics)
        {
            var points = new Point[4];

            points[3] = new Point(Position.X + 0, Position.Y + 0);
            points[2] = new Point(Position.X, Position.Y + (int)Height);
            points[1] = new Point(Position.X + (int)SecondBase, Position.Y + (int)Height);
            points[0] = new Point(Position.X + +(int)FirstBase, Position.Y + 0);

            graphics.DrawPolygon(new Pen(Color), points);
            graphics.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
