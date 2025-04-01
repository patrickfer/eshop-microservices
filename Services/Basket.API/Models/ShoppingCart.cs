using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Basket.API.Models
{
    public class ShoppingCart
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        //Required for Mapping
        public ShoppingCart() 
        {
        }
    }
}
