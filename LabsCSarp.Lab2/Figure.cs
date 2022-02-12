namespace LabsCSharp.Lab2
{
    public abstract class Figure : IFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }

        public abstract double GetArea();
    }
}
