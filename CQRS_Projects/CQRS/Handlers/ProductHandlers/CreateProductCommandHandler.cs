using CQRS_Projects.CQRS.Commands.ProductCommands;
using CQRS_Projects.DAL.Context;
using CQRS_Projects.DAL.Entities;

namespace CQRS_Projects.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly ProductContext _productContext;

        public CreateProductCommandHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void Handle(CreateProductCommand command)
        {
            _productContext.Products.Add(new Product
            {
                Name = command.Name,
                Brand = command.Brand,
                Cost = command.Cost,
                EndofDate = command.EndofDate,
                SalePrice = command.SalePrice,
                Status = command.Status,
                Size = command.Size,
                Stock = command.Stock,
                Tax = command.Tax,
                PurchasePrice = command.PurchasePrice,
                ProduceofDate = command.ProduceofDate,               

            });
            _productContext.SaveChanges();
        }
    }
}
 