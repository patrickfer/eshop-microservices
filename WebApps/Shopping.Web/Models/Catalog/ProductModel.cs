namespace Shopping.Web.Models.Catalog
{
    public class ProductModel
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
    }

    //wrapper classes
    public record GetProductsResponse(IEnumerable<ProductModel> Products);
    public record GetProductByCategoryResponse(IEnumerable<ProductModel> Products);
    public record GetProductByIdResponse(ProductModel Product);
}
