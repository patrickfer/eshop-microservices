namespace Ordering.Application.Dtos;

public record OrderItemDto (
    Guid OrderId,
    string ProductId,
    int Quantity,
    decimal Price
    );

