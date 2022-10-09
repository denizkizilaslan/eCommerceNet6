using EventBus.Base.Abstraction;
using OrderService.Application.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Events.EventHandlers
{
    public class eCommerceOrderCreatedIntegrationEventHandler : IIntegrationEventHandler<eCommerceOrderCreatedIntegrationEvent>
    {
        public  Task Handle(eCommerceOrderCreatedIntegrationEvent @event)
        {
            System.Console.WriteLine("eCommerceOrderCreatedIntegrationEvent" + @event.Id);
            return Task.CompletedTask;
        }
    }
}
