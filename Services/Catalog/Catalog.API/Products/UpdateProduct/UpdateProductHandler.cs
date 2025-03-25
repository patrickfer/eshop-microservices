using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(string Id, string Name, string Category, string Summary, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);
internal class UpdateProductCommandHandler(ICatalogContext context, ILogger<UpdateProductCommandHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        var product = await context.Products.Find(p => p.Id == command.Id).FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        await context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

        return new UpdateProductResult(true);
    }
}
