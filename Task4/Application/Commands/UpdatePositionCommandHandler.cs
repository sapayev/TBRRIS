using MediatR;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Unit>
{
    private readonly AppDbContext _context;

    public UpdatePositionCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _context.Positions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (position is null)
            throw new Exception("Position not found");

        position.Name = request.Name;
        position.BaseSalary = request.BaseSalary;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}