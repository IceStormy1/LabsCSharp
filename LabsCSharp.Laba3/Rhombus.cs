using System.Drawing;

namespace LabsCSharp.Laba3
{
    public class Rhombus : Figure
    {
        public double FirstDiagonal { get; set; }
        public double SecondDiagonal { get; set; }

        public override double GetArea() => FirstDiagonal + SecondDiagonal * 0.5;
        
        public override Point GetCenter() => new Point((int)(Position.X + FirstDiagonal / 2), (int)(Position.Y + SecondDiagonal / 2));
        

        public override void Draw(Graphics graphics)
        {
            var points = new Point[4];

            points[0] = new Point(Position.X + 0, Position.Y + (int)FirstDiagonal / 2);
            points[1] = new Point(Position.X + ((int)SecondDiagonal / 2), Position.Y + 0);
            points[2] = new Point(Position.X + (int)SecondDiagonal, Position.Y + ((int)FirstDiagonal / 2));
            points[3] = new Point(Position.X + ((int)SecondDiagonal / 2), Position.Y + (int)FirstDiagonal);

            graphics.DrawPolygon(new Pen(Color), points);
            graphics.DrawString(GetArea().ToString(), new Font("Arial", 9), Brushes.Black, GetCenter());
        }
    }
}
