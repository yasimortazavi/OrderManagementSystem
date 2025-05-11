// Features/Orders/Commands/CreateOrder/CreateOrderCommand.cs
using MassTransit.Mediator;

public record CreateOrderCommand(
    Guid CustomerId,
List<OrderItemDto> Items,
    string ShippingAddress) : IRequest<OrderDto>;

public record OrderItemDto(
    Guid ProductId,
    string ProductName,
    decimal UnitPrice,
    int Quantity);

public record OrderDto(
    Guid OrderId,
    Guid CustomerId,
    DateTime OrderDate,
    string Status,
    decimal TotalAmount);