namespace Shared.Events;

public interface IOrderStatusUpdatedHandler
{
    Task HandleAsync(OrderStatusUpdatedEvent @event, CancellationToken cancellationToken);
}