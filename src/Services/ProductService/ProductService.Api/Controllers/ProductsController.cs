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
        public ProductsController(IProductService productService,IBrandService brandService)
        {
            this.productService = productService;
            this.brandService = brandService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            List<Product> productlist = new List<Product>();
            productlist = productService.GetProducts();

            return Ok(productlist);
        }

        [HttpGet]
        [Route("GetProductsByBrandId/{brandId}")]
        public IActionResult GetProductsByBrandId(int brandId)
        {

            List<Product> productlist = new List<Product>();
            productlist = productService.GetProductsByBrandId(brandId);


            return Ok(productlist);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel request)
        {
            Product model = new Product();

            model = request.ToEntity();
            model.Brand = brandService.GetBrand(request.BrandId);
            productService.AddProduct(model);

            return Ok(model);
        }

    }
}
