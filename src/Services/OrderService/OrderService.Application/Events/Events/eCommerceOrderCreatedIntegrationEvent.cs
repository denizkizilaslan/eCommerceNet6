using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Events.Events
{
    public class eCommerceOrderCreatedIntegrationEvent:IntegrationEvent
    {
        public int Id { get; set; }
        public eCommerceOrderCreatedIntegrationEvent(int id)
        {
            Id = id;
        }
    }
}
