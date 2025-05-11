
public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly IPaymentService _paymentService;

    public OrderCreatedConsumer(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var evt = context.Message;
        await _paymentService.ProcessPayment(evt.OrderId, evt.Total);
    }
}
