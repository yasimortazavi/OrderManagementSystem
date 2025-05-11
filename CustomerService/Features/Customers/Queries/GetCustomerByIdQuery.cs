// Features/Customers/Queries/GetCustomerById/GetCustomerByIdQuery.cs
using MediatR;

namespace CustomerService.Features.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDetailsDto>;

    public record CustomerDetailsDto(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        DateTime CreatedAt);
}