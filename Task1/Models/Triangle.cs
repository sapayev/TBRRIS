using Task1.Interfaces;

namespace Task1.Models;

public class Triangle : IFigure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    
    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Стороны должны быть положительными");
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Неравенство треугольника");

        A = a;
        B = b;
        C = c;
    }

    public double GetArea()
    {
        double area = (A + B + C) / 2;
        return Math.Sqrt(area*(area - A) * (area - B) * (area - C));
    }
    //Реализация проверки, является ли треугольник прямоугольным
    public bool IsRightAngled()
    {
        var sides = new[] { A, B, C };
        Array.Sort(sides); 
        return Math.Abs(sides[0]*sides[0] + sides[1]*sides[1] - sides[2]*sides[2]) < 1e-10;
    }
}