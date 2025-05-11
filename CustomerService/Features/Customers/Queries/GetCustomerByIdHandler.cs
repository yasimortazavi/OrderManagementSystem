// Features/Customers/Queries/GetCustomerById/GetCustomerByIdHandler.cs
using MediatR;
using CustomerService.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler :
        IRequestHandler<GetCustomerByIdQuery, CustomerDetailsDto>
    {
        private readonly CustomerDbContext _context;

        public GetCustomerByIdHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailsDto> Handle(
            GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (customer is null)
                throw new CustomerNotFoundException(request.Id);

            return new CustomerDetailsDto(
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Phone,
                customer.CreatedAt);
        }
    }
}