using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IOrderRepository
    {
        // Update the order

        void Save(Order order);
    }
}
