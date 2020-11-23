namespace DomainLogic.Interfaces
{
    //  a common Abstraction that models notifications
    public interface INotificationService
    {
        /* Each method represents a domain event. 
         * Abstractions with many members, however, typically violate the "InterfAce segregAtIon prIncIple"
         */

        void OrderApproved(Order order);
        //void OrderCancelled(Order order);
        //void OrderShipped(Order order);
        //void OrderDelivered(Order order);
        //void CustomerCreated(Customer customer);
        //void CustomerMadePreferred(Customer customer);
    }
}