using Customer.Domain.ValueObjects;

namespace Customer.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(Guid id);
    Task AddAsync(Customer customer);
    Task<bool> ExistsAsync(Email email);
}
