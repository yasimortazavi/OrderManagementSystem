namespace Shared.Events;

public record OrderStatusUpdatedEvent(
    Guid OrderId,
    Guid CustomerId,
    string OldStatus,
    string NewStatus,
    DateTime UpdatedAt,
    string ChangedBy,
    string? Reason = null)
{
    public Dictionary<string, object> ToMetadata() => new()
    {
        {"OrderId", OrderId},
        {"CustomerId", CustomerId},
        {"ChangedBy", ChangedBy}
    };
}