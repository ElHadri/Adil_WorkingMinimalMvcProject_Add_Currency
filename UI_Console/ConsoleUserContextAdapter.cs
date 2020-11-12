
using DomainLogic;

using System;

namespace UI_Console
{
    class ConsoleUserContextAdapter : IUserContext
    {
        private readonly bool _isPreferredCustomer;
        public ConsoleUserContextAdapter(bool isPreferredCustomer)
        {
            _isPreferredCustomer = isPreferredCustomer;
        }

        public bool IsInRole(Role role)
        {
            return _isPreferredCustomer;
        }

    }
}
