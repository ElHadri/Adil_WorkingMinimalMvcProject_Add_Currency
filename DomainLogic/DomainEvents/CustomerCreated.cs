using System;

namespace DomainLogic.DomainEvents
{
    public class CustomerCreated
    {
        public readonly Guid CustomerId;
        public CustomerCreated(Guid customerId)
        {
            CustomerId = customerId;
        }

    }
}
