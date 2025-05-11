using Payment.Domain.ValueObjects;

namespace Payment.Domain.Entities;

public class Payment
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime PaidAt { get; private set; }

    private Payment() { }

    public Payment(Guid orderId, decimal amount)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public void CompletePayment()
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Payment is not in pending status.");

        Status = PaymentStatus.Completed;
        PaidAt = DateTime.UtcNow;
    }

    public void FailPayment()
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Only pending payments can fail.");

        Status = PaymentStatus.Failed;
    }
}
