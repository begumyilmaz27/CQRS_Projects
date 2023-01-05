using CQRS_Projects.CQRS.Queries.ProductQueries;
using CQRS_Projects.CQRS.Results.ProductResults;
using CQRS_Projects.DAL.Context;
using CQRS_Projects.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_Projects.CQRS.Handlers.ProductHandlers
{
    public class GetProductHumanResourceByIDQueryHandlers
    {
        private readonly ProductContext _productContext;

        public GetProductHumanResourceByIDQueryHandlers (ProductContext productContext)
        {
            _productContext = productContext;
        }

        public GetProductHumanResourceByIDQueryResult Handle(GetProductHumanResourceByIDQuery query)
        {
            var values = _productContext.Products.Find(query.id);
            return new GetProductHumanResourceByIDQueryResult
            {
                ProductID = values.ProductID,
                Brand = values.Brand,
                Name = values.Name,
                SalePrice = values.SalePrice
            };
        }
    }
}
