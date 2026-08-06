namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling DeleteProductCommand for ProductId {ProductId}.", command.Id);
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product == null)
            {
                logger.LogWarning("Product with ID {ProductId} not found.", command.Id);
                throw new ProductNotFoundException(command.Id);
            }
            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Product with ID {ProductId} deleted successfully.", command.Id);
            return new DeleteProductResult(true);
        }
    }
}
