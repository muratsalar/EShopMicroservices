using Marten.Pagination;

namespace Catalog.API.Products.GetProducts
{
    public record GetProdcutsQuery(int? PageNumber = 1, int? PageSize = 10): IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProdcutsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProdcutsQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10, cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
