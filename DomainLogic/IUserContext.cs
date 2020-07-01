using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public interface IUserContext
    {
        bool IsInRole(Role role);
    }

    public enum Role { PreferredCustomer }
}

