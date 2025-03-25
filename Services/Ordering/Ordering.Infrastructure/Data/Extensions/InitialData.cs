namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "patrick", "patrick@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
        };

    public static IEnumerable<Product> Products =>
       new List<Product>
       {
            Product.Create(ProductId.Of("60d5f5a4e2b1c3d7f9e8a6b4"), "IPhone X", 950.00M),
            Product.Create(ProductId.Of("6512fbd1c9a5d3f4e8b7a9c2"), "Samsung 10", 950.00M),
            Product.Create(ProductId.Of("5f2a3b4c6d7e8f9a0b1c2d3e"), "Huawei Plus", 650.00M),
            Product.Create(ProductId.Of("4e3d2c1b0a9f8e7d6c5b4a3f"), "Xiaomi Mi 9", 470.00M)
       };

    public static IEnumerable<Order> OrderWithItems
    {
        get
        {
            var address1 = Address.Of("patrick", "fernando", "patrick@gmail.com", "United States", "Washington", "Seattle", "Bellevue Ave", "98103");
            var address2 = Address.Of("john", "lennon", "john@gmail.com", "England", "Merseyside", "Liverpool", "Penny Lane", "56");

            var payment1 = Payment.Of("patrick", "555555555444444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "6666666667777888888", "06/29", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of("60d5f5a4e2b1c3d7f9e8a6b4"), 2, 950);
            order1.Add(ProductId.Of("5f2a3b4c6d7e8f9a0b1c2d3e"), 1, 650);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);

            order2.Add(ProductId.Of("4e3d2c1b0a9f8e7d6c5b4a3f"), 1, 470);
            order2.Add(ProductId.Of("5f2a3b4c6d7e8f9a0b1c2d3e"), 2, 650);

            return new List<Order> { order1, order2 };

        }
    }
}
