using EventBus.Base.Abstraction;
using OrderConfirmService.Console.Events.Events;
using Serilog;

namespace OrderConfirmService.Console.Events.EventHandlers
{
    public class eCommerceOrderCreatedIntegrationEventHandler : IIntegrationEventHandler<eCommerceOrderCreatedIntegrationEvent>
    {
        public  Task Handle(eCommerceOrderCreatedIntegrationEvent @event)
        {
            
            string value = $"Handle method worked with id{@event.Id}";
            System.Console.WriteLine("Handle method worked with id" + @event.Id);
            return Task.CompletedTask;
        }
    }
}
