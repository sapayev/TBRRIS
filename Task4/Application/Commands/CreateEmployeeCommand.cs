using MediatR;

namespace Task4.Application.Commands;

public record CreateEmployeeCommand(
    string FullName,
    DateTime DateOfBirth,
    DateTime HiredAt,
    int PositionId
) : IRequest<int>;