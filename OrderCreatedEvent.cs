using System;

namespace OrderManagementSystem.Contracts.Commands
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderCreatedEvent() { }

        public OrderCreatedEvent(Guid orderId, Guid customerId, decimal totalAmount, DateTime createdAt)
        {
            OrderId = orderId;
            CustomerId = customerId;
            TotalAmount = totalAmount;
            CreatedAt = createdAt;
        }
    }
}
