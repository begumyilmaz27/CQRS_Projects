using CQRS_Projects.CQRS.Queries.ProductQueries;
using CQRS_Projects.CQRS.Results.ProductResults;
using CQRS_Projects.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS_Projects.CQRS.Handlers.ProductHandlers
{
    public class GetProductAccounterByIDQueryHandlers
    {
        private readonly ProductContext _productContext;

        public GetProductAccounterByIDQueryHandlers(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public GetProductAccounterByIDQueryResult Handle(GetProductAccounterByIDQuery query)
        {
            var values = _productContext.Products.Find(query.id); 
            return new GetProductAccounterByIDQueryResult
            {
                Brand = values.Brand,
                Description = values.Description,
                Name = values.Name,
                ProductID = values.ProductID,
                PurchasePrice = values.PurchasePrice,
                SalePrice = values.SalePrice,
                Stock = values.Stock,
                Tax = values.Tax
            };            

        }
    }
}
