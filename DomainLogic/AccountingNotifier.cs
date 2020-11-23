using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

namespace DomainLogic
{
    public class AccountingNotifier : IEventHandler<OrderApproved>, IEventHandler<OrderCancelled>
    {
        private readonly IBillingSystem billingSystem;
        public AccountingNotifier(IBillingSystem billingSystem)
        {
            this.billingSystem = billingSystem;
        }

        public void Handle(OrderApproved e)
        {
            billingSystem.NotifyAccounting();
        }

        public void Handle(OrderCancelled e)
        {
            // to do...
        }
    }
}
