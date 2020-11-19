
using DomainLogic;

using System;

namespace UI_Console
{
    class ConsoleUserContextAdapter : IUserContext
    {
        private readonly bool _isPreferredCustomer;
        private readonly Currency _preferedCurrency;

        public ConsoleUserContextAdapter(bool isPreferredCustomer, Currency preferedCurrency)
        {
            _isPreferredCustomer = isPreferredCustomer;
            _preferedCurrency = preferedCurrency;
        }

        public Currency PreferedCurrency
        {
            get { return _preferedCurrency; }
        }

        public bool IsInRole(Role role)
        {
            return _isPreferredCustomer;
        }

    }
}
