using MediatR;
using System;

namespace Payment.Application.Commands
{
    public class CreatePaymentCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }

        public CreatePaymentCommand(Guid orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }
    }
}
