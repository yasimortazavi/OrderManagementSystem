// Features/Customers/Commands/CreateCustomer/CreateCustomerCommand.cs
using MediatR;
using CustomerService.Models;

namespace CustomerService.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
        string FirstName,
        string LastName,
        string Email,
        string Phone) : IRequest<CustomerDto>;

    public record CustomerDto(
        Guid Id,
        string FullName,
        string Email,
        string Phone);
}