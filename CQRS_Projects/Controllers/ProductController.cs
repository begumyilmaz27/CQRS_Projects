using CQRS_Projects.CQRS.Commands.ProductCommands;
using CQRS_Projects.CQRS.Handlers.ProductHandlers;
using CQRS_Projects.CQRS.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Projects.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductByAccounterQueryHandler _getProductByAccounterQueryHandler;
        private readonly GetProductStoragerQueryHandler _getProductStoragerQueryHandler;
        private readonly GetProductHumanResourceByIDQueryHandlers _getProductHumanResourceByIDQueryHandlers;
        private readonly GetProductAccounterByIDQueryHandlers _getProductAccounterByIDQueryHandlers;
        private readonly CreateProductCommandHandler _createProductCommandHandler;

        public ProductController(GetProductByAccounterQueryHandler getProductByAccounterQueryHandler, GetProductStoragerQueryHandler getProductStoragerQueryHandler, GetProductHumanResourceByIDQueryHandlers getProductHumanResoruceByIDQueryHandler, GetProductAccounterByIDQueryHandlers getProductAccounterByIDQueryHandlers, CreateProductCommandHandler createProductCommandHandler)
        {
            _getProductByAccounterQueryHandler = getProductByAccounterQueryHandler;
            _getProductStoragerQueryHandler = getProductStoragerQueryHandler;
            _getProductHumanResourceByIDQueryHandlers = getProductHumanResoruceByIDQueryHandler;
            _getProductAccounterByIDQueryHandlers = getProductAccounterByIDQueryHandlers;
            _createProductCommandHandler = createProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductByAccounterQueryHandler.Handle();
            return View(values);
        }
        public IActionResult StoragerIndex()
        {
            var values = _getProductStoragerQueryHandler.Handle();
            return View(values);
        }
        public IActionResult GetHumanResourcesIndex(int id)
        {
            var values = _getProductHumanResourceByIDQueryHandlers.Handle(new GetProductHumanResourceByIDQuery(id));
            return View(values);            
        }
        public IActionResult AccounterIndexByID(int id)
        {
            var values = _getProductAccounterByIDQueryHandlers.Handle(new GetProductAccounterByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


    }
}
