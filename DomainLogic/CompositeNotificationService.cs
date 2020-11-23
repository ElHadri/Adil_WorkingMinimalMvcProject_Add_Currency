using DomainLogic.Interfaces;

using System.Collections.Generic;

namespace DomainLogic
{
    public class CompositeNotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationService> services;
        public CompositeNotificationService(IEnumerable<INotificationService> services)
        {
            this.services = services;
        }

        // Forwards an incoming call to all wrapped instances
        public void OrderApproved(Order order)
        {
            foreach (var service in services)
            {
                service.OrderApproved(order);
            }
        }
    }
}
