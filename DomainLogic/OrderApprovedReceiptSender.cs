using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

namespace DomainLogic
{
    public class OrderApprovedReceiptSender : IEventHandler<OrderApproved>
    {
        private readonly IMessageService messageService;
        public OrderApprovedReceiptSender(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public void Handle(OrderApproved e)
        {
            messageService.SendReceipt(new OrderReceipt());
        }
    }
}