
using DomainLogic;

namespace UI_Console
{
    class ConsoleUserContextAdapter : IUserContext
    {
        public bool IsInRole(Role role)
        {
            return (role == Role.PreferredCustomer);
        }

    }
}
