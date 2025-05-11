using MediatR;
using Customer.Domain.Interfaces;
using Customer.Application.DTOs;

namespace Customer.Application.Queries.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer == null) throw new Exception("Customer not found.");

        return new CustomerDto(customer.Id, customer.Name, customer.Email.ToString());
    }
}
