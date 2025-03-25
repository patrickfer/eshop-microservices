namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(string Id): ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

internal class DeleteProductCommandHandler
    (IProductRepository repository, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);

        await repository.DeleteProduct(command.Id, cancellationToken);

        return new DeleteProductResult(true);
    }
}
