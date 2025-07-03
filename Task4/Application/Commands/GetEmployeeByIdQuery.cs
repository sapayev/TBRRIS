using MediatR;
using Task4.Common.DTOs;

namespace Task4.Application.Commands;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;