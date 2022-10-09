using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Repositories.Abstract;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IBasketService basketService, IOrderService orderService, IProductService productService)
        {
            _logger = logger;
            this.basketService = basketService;
            this.orderService = orderService;
            this.productService = productService;
        }
        public IActionResult Login() => View();

        public async Task<IActionResult> Shop()
        {
            var basketCount = await basketService.GetBasket();
            var result = await productService.GetProducts();
            ViewBag.BasketCount  = basketCount.Items.Count();
            return View(result);
        }


        public async Task<IActionResult> Cart()
        {
            var result = await basketService.GetBasket();
            return View(result);
        }




        [HttpPost]
        public async Task<IActionResult> AddtoBasket(int Id)
        {
            var resultAddItem =await basketService.AddItemToBasket(Id);
            if (resultAddItem)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostOrder(int Id)
        {
            var basket = await basketService.GetBasket();

            await orderService.AddOrder(basket);
            return RedirectToAction("Home/Shop");
        }


    }
}