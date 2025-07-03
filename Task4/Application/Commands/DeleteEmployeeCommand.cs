using MediatR;

namespace Task4.Application.Commands;

public record DeleteEmployeeCommand(int Id) : IRequest<Unit>;