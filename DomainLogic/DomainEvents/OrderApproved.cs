using System;

namespace DomainLogic.DomainEvents
{
    public class OrderApproved
    {
        public readonly Guid OrderId;
        public OrderApproved(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
