using Task1.Models;

namespace TestTask1;

public class UnitTest1
{
    [Fact]
    public void Circle_IsCorrect()
    {
        var circle = new Circle(2);
        double expected = Math.PI * 4;
        Assert.Equal(expected, circle.GetArea(), 5);
    }

    [Fact]
    public void Triangle_IsCorrect()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.GetArea(), 5);
    }

    [Fact]
    public void Triangle_IsRightAngled_ReturnsTrue()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRightAngled());
    }

    [Fact]
    public void Triangle_NotRightAngled_ReturnsFalse()
    {
        var triangle = new Triangle(4, 5, 6);
        Assert.False(triangle.IsRightAngled());
    }
}