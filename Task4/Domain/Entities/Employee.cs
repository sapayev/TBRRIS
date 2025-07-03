namespace Task4.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public DateTime HiredAt { get; set; }

    public int PositionId { get; set; }
    public Position Position { get; set; }

    public decimal Salary { get; set; }
}