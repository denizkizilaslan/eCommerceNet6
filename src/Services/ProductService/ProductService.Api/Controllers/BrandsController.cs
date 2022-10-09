using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Repositories.Abstraction;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService brandService;
        private readonly ILogger<BrandsController> logger;
        public BrandsController(IBrandService brandService, ILogger<BrandsController> logger)
        {
            this.brandService = brandService;
            this.logger = logger;
        }
      

        [HttpGet]
        [Route("GetBrands")]
        public IActionResult GetBrands()
        {
            logger.LogInformation("GetBrands executed");
            return Ok(brandService.GetBrands());
        }
    }
}
