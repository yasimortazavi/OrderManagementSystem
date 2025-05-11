using MediatR;
using Customer.Domain.Entities;
using Customer.Domain.ValueObjects;
using Customer.Domain.Interfaces;

namespace Customer.Application.Commands.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);

        if (await _repository.ExistsAsync(email))
            throw new Exception("Customer with this email already exists.");

        var customer = new Customer(Guid.NewGuid(), request.Name, email);
        await _repository.AddAsync(customer);

        return customer.Id;
    }
}
