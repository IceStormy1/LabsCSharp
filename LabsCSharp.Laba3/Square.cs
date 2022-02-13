using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Square : Figure
    {
        public double Side { get; set; }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Side / 2), (int)(Position.Y + Side / 2));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color), Position.X, Position.Y, (int)(Side), (int)(Side));
            graphics.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
