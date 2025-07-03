using MediatR;
using Microsoft.EntityFrameworkCore;
using Task4.Common.DTOs;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Queries;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    private readonly AppDbContext _context;

    public GetEmployeesQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Employees
            .Include(e => e.Position)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.FullNameFilter))
            query = query.Where(e => e.FullName.Contains(request.FullNameFilter));

        if (!string.IsNullOrWhiteSpace(request.PositionFilter))
            query = query.Where(e => e.Position.Name.Contains(request.PositionFilter));

        query = request.SortBy?.ToLower() switch
        {
            "name" => request.SortDescending ? query.OrderByDescending(e => e.FullName) : query.OrderBy(e => e.FullName),
            "salary" => request.SortDescending ? query.OrderByDescending(e => e.Salary) : query.OrderBy(e => e.Salary),
            "position" => request.SortDescending ? query.OrderByDescending(e => e.Position.Name) : query.OrderBy(e => e.Position.Name),
            _ => query.OrderBy(e => e.Id)
        };

        return await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(e => new EmployeeDto
            {
                FullName = e.FullName,
                Position = e.Position.Name,
                DateOfBirth = e.DateOfBirth,
                HiredAt = e.HiredAt,
                Salary = e.Salary
            })
            .ToListAsync(cancellationToken);
    }
}