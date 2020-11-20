using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IMessageService
    {
        // Send a receipt email to the customer

        void SendReceipt(OrderReceipt orderReceipt);
    }
}
