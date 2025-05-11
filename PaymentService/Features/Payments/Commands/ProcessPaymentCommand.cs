// Features/Payments/Commands/ProcessPayment/ProcessPaymentCommand.cs
using MassTransit.Mediator;

public record ProcessPaymentCommand(
    Guid OrderId,
    decimal Amount,
string PaymentMethod,
    string CardToken) : IRequest<PaymentResultDto>;

public record PaymentResultDto(
    Guid PaymentId,
    Guid OrderId,
    string Status,
    DateTime ProcessedAt,
    string TransactionId);