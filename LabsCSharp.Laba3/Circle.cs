using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public override double GetArea()
            => Radius * Radius * 3.14;
        
        public override Point GetCenter() 
            => new Point((int)(Position.X + Radius / 2), (int)(Position.Y + Radius / 2));
        
        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color), Position.X - (int)Radius, Position.Y - (int)Radius,
                (int)Radius + (int)Radius, (int)Radius + (int)Radius);
            graphics.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
