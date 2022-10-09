using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductService.Application.Model;
using ProductService.Application.ModelToEntitiy;
using ProductService.Application.Repositories.Abstraction;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;
        private readonly IBrandService brandService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService productService, IBrandService brandService, ILogger<ProductsController> logger)
        {
            this.productService = productService;
            this.brandService = brandService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            logger.LogInformation("ProuctService executed");
            return Ok(productService.GetProducts());
        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            logger.LogInformation($"GetProductById executed. Product Id: {productId}");
            var response = productService.GetProduct(productId);
            ProductModel model = new ProductModel { Name = response.Name, BrandId = response.Brand.Id, Description = response.Description, Price = response.Price, Quantity = 1 };
            return Ok(model);
        }


        [HttpGet]
        [Route("GetProductsByBrandId/{brandId}")]
        public IActionResult GetProductsByBrandId(int brandId)
        {
            logger.LogInformation($"GetProductsByBrandId executed. Brand Id: {brandId}");
            return Ok(productService.GetProductsByBrandId(brandId));
        }


        [HttpPost]
        public IActionResult AddProduct(ProductModel request)
        {
            string json = JsonConvert.SerializeObject(request);
            logger.LogInformation($"AddProduct executed. ProductModel: {json}");
            Product model = new Product();

            model = request.ToEntity();
            model.Brand = brandService.GetBrand(request.BrandId);
            productService.AddProduct(model);

            return Ok(model);
        }
    }
}
