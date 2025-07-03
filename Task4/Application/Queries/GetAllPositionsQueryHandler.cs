using MediatR;
using Microsoft.EntityFrameworkCore;
using Task4.Common.DTOs;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Queries;

public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, List<PositionDto>>
{
    private readonly AppDbContext _context;

    public GetAllPositionsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Positions
            .Select(p => new PositionDto
            {
                Id = p.Id,
                Name = p.Name,
                BaseSalary = p.BaseSalary
            })
            .ToListAsync(cancellationToken);
    }
}