using MediatR;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly AppDbContext _context;

    public DeleteEmployeeCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
        if (employee is null)
            throw new Exception("Employee not found");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}