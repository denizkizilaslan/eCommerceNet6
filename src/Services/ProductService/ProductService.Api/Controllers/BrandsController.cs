using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Repositories.Abstraction;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService brandService;
        public BrandsController(IBrandService brandService) => this.brandService = brandService;
      

        [HttpGet]
        [Route("GetBrands")]
        public IActionResult GetBrands() => Ok(brandService.GetBrands());
       
    }
}
