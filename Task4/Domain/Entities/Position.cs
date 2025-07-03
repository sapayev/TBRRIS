namespace Task4.Domain.Entities;

public class Position
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal BaseSalary { get; set; }

    public ICollection<Employee> Employees { get; set; }
}