namespace Catalog.API.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts(int? pageNumber, int? pageSize, CancellationToken cancellationToken = default);
    Task<Product> GetProductById(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetProductByCategory(string categoryName, CancellationToken cancellationToken = default);

    Task<Product> CreateProduct(Product product, CancellationToken cancellationToken = default);
    Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken = default);
    Task<bool> DeleteProduct(string id, CancellationToken cancellationToken = default);
}
