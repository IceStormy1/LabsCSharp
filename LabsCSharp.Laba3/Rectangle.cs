using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override Point GetCenter()
        {
            return new Point((int)(Position.X + Width / 2), (int)(Position.Y + Height / 2));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color), Position.X, Position.Y, (int)(Width), (int)(Height));
            graphics.DrawString(GetCenter().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
