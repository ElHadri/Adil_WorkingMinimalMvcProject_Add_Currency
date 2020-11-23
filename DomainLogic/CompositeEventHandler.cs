using DomainLogic.Interfaces;

using System.Collections.Generic;

namespace DomainLogic
{
    class CompositeEventHandler<TEvent> : IEventHandler<TEvent>
    {
        private readonly IEnumerable<IEventHandler<TEvent>> handlers;
        public CompositeEventHandler(IEnumerable<IEventHandler<TEvent>> handlers)
        {
            this.handlers = handlers;
        }

        // Forwards an incoming call to all wrapped instances
        public void Handle(TEvent e)
        {
            foreach (var handler in handlers)
            {
                handler.Handle(e);
            }
        }
    }
}