using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ProductsController(IProductService productService, IBrandService brandService)
        {
            this.productService = productService;
            this.brandService = brandService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts() => Ok(productService.GetProducts());

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var response = productService.GetProduct(productId);
            ProductModel model = new ProductModel { Name = response.Name, BrandId = response.Brand.Id, Description = response.Description, Price = response.Price, Quantity = 1 };
            return Ok(model);
        }


        [HttpGet]
        [Route("GetProductsByBrandId/{brandId}")]
        public IActionResult GetProductsByBrandId(int brandId) => Ok(productService.GetProductsByBrandId(brandId));


        [HttpPost]
        public IActionResult AddProduct(ProductModel request)
        {
            Product model = new Product();

            model = request.ToEntity();
            model.Brand = brandService.GetBrand(request.BrandId);
            productService.AddProduct(model);

            return Ok(model);
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product model) => Ok(productService.AddProduct(model));

    }
}
