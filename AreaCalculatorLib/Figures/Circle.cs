namespace AreaCalculatorLib.Figures
{
    public class Circle : IFigure
    {
        private float _radius;
        public float Radius 
        { 
            get => _radius;
            set
            {
                IsFigure(value);
                _radius = value;
            }
        }
        public Circle (float r)
        {
            Radius = r;
        }
        public static float GetFigureArea(float r)
        {
            IsFigure(r);
            return MathF.PI * MathF.Pow(r, 2);
        }
        private static void IsFigure(float r)
        {
            if (r <= 0) throw new FigureException("Radius <= 0");
        }

        public float GetFigureArea() => GetFigureArea(Radius);

        
    }
}
