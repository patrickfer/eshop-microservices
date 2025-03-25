namespace Basket.API.Data;

public interface IBasketContext
{
    IMongoCollection<ShoppingCart> ShoppingCarts { get; }   
}
