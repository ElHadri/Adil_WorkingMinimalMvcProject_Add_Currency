using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IUserService
    {
        void UpdateMailAddress(Guid userId, string newMailAddress);
    }
}
