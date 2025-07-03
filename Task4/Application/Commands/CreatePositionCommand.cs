using MediatR;

namespace Task4.Application.Commands;

public record CreatePositionCommand(string Name, decimal BaseSalary) : IRequest<int>;