using BasketService.Api.Core.Application.Repositories;
using BasketService.Api.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILogger<BasketController> _logger;


        public BasketController(
            ILogger<BasketController> logger,
            IBasketService basketService)
        {
            _logger = logger;
            this.basketService = basketService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string id)
        {
            var basket = await basketService.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync([FromBody] CustomerBasket value)
        {
            return Ok(await basketService.UpdateBasketAsync(value));
        }


        [Route("additem/{customerId}")]
        [HttpPost]
        public async Task<ActionResult> additem(string customerId, [FromBody] BasketItem basketItem)
        {
            var basket = await basketService.GetBasketAsync(customerId);

            if (basket == null)
                basket = new CustomerBasket(customerId);

            basket.Items.Add(basketItem);
            await basketService.UpdateBasketAsync(basket);

            return Ok();


        }

        [HttpDelete("deleteBasketByIdAsync/{id}")]
        public async Task deleteBasketByIdAsync(string id)
        {
            await basketService.DeleteBasketAsync(id);
        }
    }
}
