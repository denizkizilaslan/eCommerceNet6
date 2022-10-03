using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Repositories.Abstraction;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        [Route("GetBrands")]
        public IActionResult GetBrands()
        {
            List<Brand> brands = new List<Brand>();

            brands = brandService.GetBrands();

            return Ok(brands);
        }
    }
}
