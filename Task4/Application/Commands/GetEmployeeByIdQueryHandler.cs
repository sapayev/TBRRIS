using MediatR;
using Microsoft.EntityFrameworkCore;
using Task4.Common.DTOs;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly AppDbContext _context;

    public GetEmployeeByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .Include(e => e.Position)
            .Where(e => e.Id == request.Id)
            .Select(e => new EmployeeDto
            {
                FullName = e.FullName,
                Position = e.Position.Name,
                DateOfBirth = e.DateOfBirth,
                HiredAt = e.HiredAt,
                Salary = e.Salary
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (employee == null)
            throw new Exception("Employee not found");

        return employee;
    }
}