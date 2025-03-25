namespace Basket.API.Data;

public class BasketContext : IBasketContext
{
    public BasketContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        ShoppingCarts = database.GetCollection<ShoppingCart>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
    }
    public IMongoCollection<ShoppingCart> ShoppingCarts { get; }
}
