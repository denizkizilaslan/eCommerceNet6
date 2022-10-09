using BasketService.Api.Core.Application.Repositories;
using BasketService.Api.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILogger<BasketController> logger;

        public BasketController(
            ILogger<BasketController> logger,
            IBasketService basketService)
        {
            this.logger = logger;
            this.basketService = basketService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string id)
        {
            logger.LogInformation($"GetBasketByIdAsync executed: Id: {id}");
            var basket = await basketService.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync([FromBody] CustomerBasket value)
        {
            string json = JsonConvert.SerializeObject(value);
            logger.LogInformation($"UpdateBasketAsync executed: CustomerBasket: {json}");
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

            string json = JsonConvert.SerializeObject(basketItem);
            logger.LogInformation($"additem executed: BasketItem: {json}");
            
            return Ok();
        }

        [HttpDelete("deleteBasketByIdAsync/{id}")]
        public async Task deleteBasketByIdAsync(string id)
        {
            logger.LogInformation($"deleteBasketByIdAsync executed: Id: {id}");
            await basketService.DeleteBasketAsync(id);
        }
    }
}
