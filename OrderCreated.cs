namespace BuildingBlocks.Contracts.Commands;

public interface OrderCreated
{
    Guid OrderId { get; }
    decimal TotalAmount { get; }
    DateTime CreatedAt { get; }
}
