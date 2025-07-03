using MediatR;
using Task4.Domain.Entities;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, int>
{
    private readonly AppDbContext _context;

    public CreatePositionCommandHandler(AppDbContext context) => _context = context;

    public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var position = new Position
        {
            Name = request.Name,
            BaseSalary = request.BaseSalary
        };

        _context.Positions.Add(position);
        await _context.SaveChangesAsync(cancellationToken);
        return position.Id;
    }
}