using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Events.Events;
using OrderService.Application.IntegrationEvents;
using OrderService.Application.Model;
using OrderService.Application.ModelToEntitiy;
using OrderService.Application.Repositories.Abstraction;
using OrderService.Domain.Models;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IEventBus eventBus;
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderRepository, IEventBus eventBus, ILogger<OrderController> logger)
        {
            this.orderService = orderRepository;
            this.eventBus = eventBus;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            logger.LogInformation("GetOrders executed");

            return Ok(orderService.GetOrders());

        }


        [HttpPost]
        [Route("PostOrder")]
        public IActionResult PostOrder([FromBody] OrderModel orderModel)
        {
            Order model = new Order();

            model = orderModel.ToEntity();

            var result = orderService.AddOrder(model);
            logger.LogInformation("AddOrder executed");
            if (result)
            {
                ////todo
                //var orderStartedIntegrationEvent = new OrderStartedIntegrationEvent("guest", orderModel.ReferanceNumber);

                //eventBus.Publish(orderStartedIntegrationEvent);
                //model güncellenecej db güncelleme ve sepet boşaltma işlemleri yapılacak
                var orderStartedIntegrationEvent = new eCommerceOrderCreatedIntegrationEvent(4);

                eventBus.Publish(orderStartedIntegrationEvent);

                logger.LogInformation("eCommerceOrderCreatedIntegrationEvent Publish executed");
                return Ok();
            }
            return BadRequest();
        }

    }
}
