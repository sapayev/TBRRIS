using MediatR;
using Task4.Common.DTOs;

namespace Task4.Application.Queries;

public record GetEmployeesQuery(
    string? FullNameFilter,
    string? PositionFilter,
    string? SortBy, // "name", "salary", "position"
    bool SortDescending,
    int Page,
    int PageSize
) : IRequest<List<EmployeeDto>>;