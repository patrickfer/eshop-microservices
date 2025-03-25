namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts(int? pageNumber, int? pageSize, CancellationToken cancellationToken = default)
        {
            // Definir valores padrão para paginação
            var safePageNumber = pageNumber ?? 1;
            var safePageSize = pageSize ?? 10;

            var products = await _context.Products.Find(Builders<Product>.Filter.Empty)
                .Skip((safePageNumber - 1) * safePageSize)
                .Limit(safePageSize)
                .ToListAsync(cancellationToken);

            return products;
        }

        public async Task<Product> GetProductById(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync(cancellationToken);
        }

        public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken = default)
        {
            // Validação para evitar duplicações
            var existingProduct = await _context.Products.Find(p => p.Id == product.Id).FirstOrDefaultAsync(cancellationToken);
            if (existingProduct != null)
            {
                throw new InvalidOperationException($"Um produto com o ID {product.Id} já existe.");
            }

            await _context.Products.InsertOneAsync(product, cancellationToken: cancellationToken);
            return product;
        }

        public async Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken = default)
        {
            // Garantir que o produto existe antes de atualizar
            var existingProduct = await _context.Products.Find(p => p.Id == product.Id).FirstOrDefaultAsync(cancellationToken);
            if (existingProduct == null)
            {
                return false; // Produto não encontrado
            }

            var updateResult = await _context.Products.ReplaceOneAsync(
                filter: g => g.Id == product.Id,
                replacement: product,
                cancellationToken: cancellationToken
            );

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id, CancellationToken cancellationToken = default)
        {
            // Garantir que o produto existe antes de excluir
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var deleteResult = await _context.Products.DeleteOneAsync(filter, cancellationToken);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
