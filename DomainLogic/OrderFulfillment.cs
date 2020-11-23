using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

namespace DomainLogic
{
    public class OrderFulfillment : IEventHandler<OrderApproved>
    {
        private readonly ILocationService locationService;
        private readonly IInventoryManagement inventoryManagement;
        public OrderFulfillment(
            ILocationService locationService,
            IInventoryManagement inventoryManagement)
        {
            this.locationService = locationService;
            this.inventoryManagement = inventoryManagement;
        }


        public void Handle(OrderApproved e)
        {
            locationService.FindWarehouses(/*...*/);
            inventoryManagement.NotifyWarehouses(/*...*/);
        }
    }
}
