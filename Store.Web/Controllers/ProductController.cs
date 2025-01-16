using Microsoft.AspNetCore.Mvc;
using wise_nut;
using wise_nut.Web.App;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
		private readonly ProductService productService;
		public ProductController(ProductService productService)
		{
			this.productService = productService;
		}
        public IActionResult Index(int id)
        {
			var model = productService.GetById(id);

			return View(model);
        }
    }
}
