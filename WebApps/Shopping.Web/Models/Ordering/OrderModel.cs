﻿namespace Shopping.Web.Models.Ordering
{
    public record OrderModel (
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressModel ShippingAddress,
        AddressModel BillingAddress,
        PaymentModel Payment,
        OrderStatus Status,
        List<OrderItemModel> OrderItems);

    public record OrderItemModel(Guid OrderId, string ProductId, int Quantity, decimal Price);

    public record AddressModel(string FirstName, string LastName, string EmailAddress, string Country, string State, string City, string Street, string ZipCode);

    public record PaymentModel(string CardName, string CardNumber, string Expiration, string CVV, int paymentMethod);

    public enum OrderStatus 
    {
        Draft = 1,
        Pending = 2,
        Completed = 3,
        Cancelled = 4
    }

    //wrapper classes
    public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);
    public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);
    public record GetOrdersByCustomerResponse(IEnumerable<OrderModel> Orders);
}
