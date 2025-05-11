// CreateOrderCommandHandler.cs
using MediatR;

public class CreateOrderCommandHandler : IRequest<Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
    {
        _orderRepository = orderRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.OrderId, request.CustomerId, request.Total);
        await _orderRepository.AddAsync(order);

        // ارسال Event به سایر سرویس‌ها
        await _publishEndpoint.Publish(new OrderCreatedEvent(order.Id, order.CustomerId, order.Total));

        return order.Id;
    }
}
