// Features/Orders/Commands/UpdateOrderStatus/UpdateOrderStatusCommand.cs
using MassTransit.Mediator;
using MassTransit;
using OrderService.Data;
using Shared.Events;

public record UpdateOrderStatusCommand(
    Guid OrderId,
    string NewStatus,
    string ChangedBy,
    string? Reason = null) : IRequest<Unit>;

// Features/Orders/Commands/UpdateOrderStatus/UpdateOrderStatusHandler.cs
public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Unit>
{
    private readonly OrderDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public UpdateOrderStatusHandler(
        OrderDbContext context,
        IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Unit> Handle(
        UpdateOrderStatusCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

        if (order is null)
            throw new OrderNotFoundException(request.OrderId);

        var oldStatus = order.Status;
        order.Status = request.NewStatus;
        order.LastUpdated = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        // ارسال رویداد
        await _publishEndpoint.Publish(new OrderStatusUpdatedEvent(
            order.Id,
            order.CustomerId,
            oldStatus,
            order.Status,
            DateTime.UtcNow,
            request.ChangedBy,
            request.Reason), cancellationToken);

        return Unit.Value;
    }
}