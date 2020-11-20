using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IInventoryManagement
    {
        // Ask the selected warehouses to pick and ship the entire order or parts of it

        void NotifyWarehouses();
    }
}
