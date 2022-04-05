namespace AreaCalculatorLib.Figures
{
    public class Triangle : IFigure
    {
        private float _a;
        private float _b;
        private float _c;

        public float A { get => _a; private set => _a = value; }
        public float B { get => _b; private set => _b = value; }
        public float C { get => _c; private set => _c = value; }

        public Triangle(float a, float b, float c)
        {
            RedefineSides(a, b, c);
        }

        public static bool IsTriangleRight(float a, float b, float c)
        {
            IsFigure(a, b, c);

            List<float> sides = new List<float>() { a, b, c };
            float hypotenuse = sides.Max();
            sides.Remove(hypotenuse);
            if (hypotenuse * hypotenuse == sides[0] * sides[0] + sides[1] * sides[1])
                return true;
            else
                return false;
        }
        private static void IsFigure(float a, float b, float c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new FigureException("Side or sides <= 0");
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new FigureException("One of the side more than sum of two others");
            }
        }
        public static float GetFigureArea(float a, float b, float c)
        {
            IsFigure(a, b, c);

            float p = (a + b + c) / 2;
            return MathF.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public float GetFigureArea()
        {
            return GetFigureArea(A, B, C);
        }
        public bool IsTriangleRight()
        {
            return IsTriangleRight(A, B, C);
        }
        public void RedefineSides(float a, float b, float c)
        {
            IsFigure(a, b, c);

            A = a;
            B = b;
            C = c;
        }
    }
}
