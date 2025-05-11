using MediatR;
using Customer.Application.DTOs;

namespace Customer.Application.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto>;
