using MassTransit;
using OrderService.Controllers;
using PaymentService.Data;
using Shared.Models;

namespace PaymentService.Consumers;

public class PaymentConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly PaymentDbContext _context;
    private readonly IBus _bus;

    public PaymentConsumer(PaymentDbContext context, IBus bus)
    {
        _context = context;
        _bus = bus;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
       
        var paymentSuccess = new Random().Next(0, 2) > 0; 

        if (paymentSuccess)
        {
            await _bus.Publish(new PaymentCompletedEvent(context.Message.OrderId));
        }
        else
        {
            await _bus.Publish(new PaymentFailedEvent(context.Message.OrderId));
        }
    }
}

public record PaymentCompletedEvent(Guid OrderId);
public record PaymentFailedEvent(Guid OrderId);