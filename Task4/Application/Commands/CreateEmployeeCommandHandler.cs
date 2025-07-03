using MediatR;
using Task4.Domain.Entities;
using Task4.Infrastructure.Persistence;

namespace Task4.Application.Commands;


    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions.FindAsync(new object[] { request.PositionId }, cancellationToken);

            if (position is null)
                throw new Exception("Position not found");

            var employee = new Employee
            {
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                HiredAt = request.HiredAt,
                PositionId = request.PositionId,
                Salary = position.BaseSalary
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
}