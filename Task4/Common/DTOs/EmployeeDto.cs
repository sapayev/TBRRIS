namespace Task4.Common.DTOs;

public class EmployeeDto
{
    public string FullName { get; set; } = default!;
    public string Position { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public DateTime HiredAt { get; set; }
    public decimal Salary { get; set; }
}