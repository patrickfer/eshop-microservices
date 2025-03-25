namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IBasketContext _context;

    public BasketRepository(IBasketContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));   
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ShoppingCart>.Filter.Eq("UserName", userName); 
        var basket = await _context.ShoppingCarts.Find(filter).FirstOrDefaultAsync(cancellationToken);

        return basket is null ?  throw new BasketNotFoundException(userName) : basket; 
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        await _context.ShoppingCarts.InsertOneAsync(basket, cancellationToken : cancellationToken);
        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ShoppingCart>.Filter.Eq("UserName", userName);
        await _context.ShoppingCarts.DeleteOneAsync(filter, cancellationToken);

        return true;
    }
}
