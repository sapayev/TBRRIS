using Task1.Interfaces;
using Task1.Models;

class Program
{
    static void Main()
    {
        IFigure circle = new Circle(15);
        Console.WriteLine($"Площадь круга: {circle.GetArea():F2}");

        var triangle = new Triangle(3, 4, 5);
        Console.WriteLine($"Площадь треугольника: {triangle.GetArea():F2}");
        Console.WriteLine($"Прямоугольный? {triangle.IsRightAngled()}");
    }
}