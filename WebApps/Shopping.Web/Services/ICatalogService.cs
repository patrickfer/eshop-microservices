namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

        [Get("/catalog-service/products/{id}")]
        Task<GetProductByIdResponse> GetProduct(string id);

        [Get("/catalog-service/products/catagory/{category}")]
        Task<GetProductByCategoryResponse> GetProductByCategory(string category);
    }
}
