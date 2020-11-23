namespace DomainLogic.Interfaces
{
    // We changed the name from "INotificationService" to "IEventHandler" to make it more apparent that this interface has a
    // wider scope than just notifying other systems
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent e);
    }
}
