using MediatR;
using Task4.Common.DTOs;

namespace Task4.Application.Queries;

public record GetAllPositionsQuery : IRequest<List<PositionDto>>;