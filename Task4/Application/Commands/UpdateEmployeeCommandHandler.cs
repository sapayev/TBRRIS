using MediatR;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly AppDbContext _context;

    public UpdateEmployeeCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
        if (employee is null)
            throw new Exception("Employee not found");

        var position = await _context.Positions.FindAsync(new object[] { request.PositionId }, cancellationToken);
        if (position is null)
            throw new Exception("Position not found");

        employee.FullName = request.FullName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.HiredAt = request.HiredAt;
        employee.Salary = position.BaseSalary;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}