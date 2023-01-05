using CQRS_Projects.CQRS.Queries.ProductQueries;
using CQRS_Projects.CQRS.Results.ProductResults;
using CQRS_Projects.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_Projects.CQRS.Handlers.ProductHandlers
{
    public class GetProductByAccounterQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductByAccounterQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public List<GetProductByAccounterQueryResult> Handle()
        {
            var values = _productContext.Products.Select(x => new GetProductByAccounterQueryResult
            {
                ProductID = x.ProductID,
                Brand=x.Brand,
                Name=x.Name,    
                PurchasePrice=x.PurchasePrice,  
                SalePrice=x.SalePrice,
                Stock = x.Stock,
                Tax=x.Tax
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
