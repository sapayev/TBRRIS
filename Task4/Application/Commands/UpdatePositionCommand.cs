using MediatR;

namespace Task4.Application.Commands;

public record UpdatePositionCommand(int Id, string Name, decimal BaseSalary) : IRequest<Unit>;