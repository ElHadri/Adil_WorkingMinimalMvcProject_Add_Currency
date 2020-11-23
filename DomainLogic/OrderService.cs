using System;

using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

namespace DomainLogic
{
    // the consumer’s single responsibility becomes to orchestrate these higher-level services
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IEventHandler<OrderApproved> orderApproveddHandler;
        private readonly IEventHandler<OrderCancelled> orderCancelledHandler;
        public OrderService(
            IOrderRepository orderRepository,
            IEventHandler<OrderApproved> orderApproveddHandler,
            IEventHandler<OrderCancelled> orderCancelledHandler)
        {
            if (orderRepository == null)
                throw new ArgumentNullException("orderRepository");
            if (orderApproveddHandler == null)
                throw new ArgumentNullException("orderApproveddHandler");
            if (orderCancelledHandler == null)
                throw new ArgumentNullException("orderCancelledHandler");

            this.orderRepository = orderRepository;
            this.orderApproveddHandler = orderApproveddHandler;
            this.orderCancelledHandler = orderCancelledHandler;
        }

        public void ApproveOrder(Order order)
        {
            // Updates the database with the order’s new status
            order.Approve();
            orderRepository.Save(order);

            // Notifies other systems about the order (notifications are actions triggered when an order is approved)
            // Here we assume the order is already approved (we have an event) !!
            // Approving an order means you create an OrderApproved domain event and send it to the appropriate handlers for processing.
            orderApproveddHandler.Handle(new OrderApproved(order.Id));
        }
    }
}
