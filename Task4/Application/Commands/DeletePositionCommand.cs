using MediatR;

namespace Task4.Application.Commands;
public record DeletePositionCommand(int Id) : IRequest<Unit>;