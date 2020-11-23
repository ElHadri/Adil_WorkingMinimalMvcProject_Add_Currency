using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

using System;

namespace DomainLogic
{
    public class RefundSender : IEventHandler<OrderCancelled>
    {
        private readonly IOrderRepository orderRepository;
        public RefundSender(IOrderRepository orderRepository)
        {
            if (orderRepository == null)
                throw new ArgumentNullException("orderRepository");

            this.orderRepository = orderRepository;
        }

        public void Handle(OrderCancelled e)
        {
            // to do ...
        }
    }
}
