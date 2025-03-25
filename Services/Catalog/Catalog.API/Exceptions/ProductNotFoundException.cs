namespace Catalog.API.Exceptions;

public class ProductNotFoundException: NotFoundException
{
    public ProductNotFoundException(string Id): base("Product", Id) 
    {
    }
}
