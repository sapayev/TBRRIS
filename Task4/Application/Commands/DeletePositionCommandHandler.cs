using MediatR;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Unit>
{
    private readonly AppDbContext _context;

    public DeletePositionCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _context.Positions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (position is null)
            throw new Exception("Position not found");

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}