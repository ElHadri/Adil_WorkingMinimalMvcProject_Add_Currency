using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    // Hides the interaction between "ILocationService" and "IInventoryManagement"
    public interface IOrderFulfillment
    {
        void Fulfill(Order order);
    }
}
