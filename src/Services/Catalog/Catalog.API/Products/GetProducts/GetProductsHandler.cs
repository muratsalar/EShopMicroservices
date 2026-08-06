namespace Catalog.API.Products.GetProducts
{
    public record GetProdcutsQuery: IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) 
        : IQueryHandler<GetProdcutsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProdcutsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsQuery");
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
