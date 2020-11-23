using System;

namespace DomainLogic.Interfaces
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
