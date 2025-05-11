namespace Payment.Domain.Interfaces;

public interface IPaymentRepository
{
    Task<Payment> GetByIdAsync(Guid id);
    Task AddAsync(Payment payment);
    Task SaveChangesAsync();
}
