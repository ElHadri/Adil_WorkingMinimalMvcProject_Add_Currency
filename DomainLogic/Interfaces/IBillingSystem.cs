using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IBillingSystem
    {
        // Notify the accounting system about the invoice amount

        void NotifyAccounting();
    }
}
