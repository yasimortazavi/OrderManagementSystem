// Features/Customers/Commands/CreateCustomer/CreateCustomerHandler.cs
using MediatR;
using CustomerService.Data;
using CustomerService.Models;
using Shared.Models;

namespace CustomerService.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly CustomerDbContext _context;

        public CreateCustomerHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CustomerDto(
                customer.Id,
                $"{customer.FirstName} {customer.LastName}",
                customer.Email,
                customer.Phone);
        }
    }
}