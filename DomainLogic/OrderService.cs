using DomainLogic.Interfaces;
using System;

namespace DomainLogic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMessageService messageService;
        private readonly IBillingSystem billingSystem;
        private readonly ILocationService locationService;
        private readonly IInventoryManagement inventoryManagement;

        public OrderService(
            IOrderRepository orderRepository,
            IMessageService messageService,
            IBillingSystem billingSystem,
            ILocationService locationService,
            IInventoryManagement inventoryManagement)
        {
            if (orderRepository == null)
                throw new ArgumentNullException("orderRepository");
            if (messageService == null)
                throw new ArgumentNullException("messageService");
            if (billingSystem == null)
                throw new ArgumentNullException("billingSystem");
            if (locationService == null)
                throw new ArgumentNullException("locationService");
            if (inventoryManagement == null)
                throw new ArgumentNullException("inventoryManagement");

            this.orderRepository = orderRepository;
            this.messageService = messageService;
            this.billingSystem = billingSystem;
            this.locationService = locationService;
            this.inventoryManagement = inventoryManagement;
        }

        public void ApproveOrder(Order order)
        {
            // Updates the database with the order’s new status
            order.Approve();
            orderRepository.Save(order);

            // Notifies other systems about the order
            messageService.SendReceipt(new OrderReceipt { /*...*/ });   // Notifies customer
            billingSystem.NotifyAccounting(/*...*/);                    // Notifies Accounting
            locationService.FindWarehouses(/*...*/);                    // Finds closest warehouse(s) to notify
            inventoryManagement.NotifyWarehouses(/*...*/);              // Notifies warehouse(s) about order
        }
    }
}