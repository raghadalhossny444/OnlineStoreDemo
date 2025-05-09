using Microsoft.AspNetCore.Mvc;
using OnlineStore.BusineesLogic.Managers;


namespace OnlineStore.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly productManager _service;
        public ProductController(productManager service) => _service = service;
        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }
    }
}
