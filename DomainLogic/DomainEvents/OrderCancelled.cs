using System;

namespace DomainLogic.DomainEvents
{
    public class OrderCancelled
    {
        public readonly Guid OrderId;
        public OrderCancelled(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
