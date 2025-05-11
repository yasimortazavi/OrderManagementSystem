using MediatR;

namespace Customer.Application.Commands.CreateCustomer;

public record CreateCustomerCommand(string Name, string Email) : IRequest<Guid>;
