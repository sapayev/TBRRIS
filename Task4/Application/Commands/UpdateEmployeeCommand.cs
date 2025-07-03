using MediatR;

namespace Task4.Application.Commands;

public record UpdateEmployeeCommand(
    int Id,
    string FullName,
    DateTime DateOfBirth,
    DateTime HiredAt,
    int PositionId
) : IRequest<Unit>;