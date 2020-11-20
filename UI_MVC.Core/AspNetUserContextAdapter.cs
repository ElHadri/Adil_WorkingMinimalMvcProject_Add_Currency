using DomainLogic;
using DomainLogic.Interfaces;

using Microsoft.AspNetCore.Http;

namespace UI_MVC.Core
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static HttpContextAccessor Accessor = new HttpContextAccessor();

        public Currency PreferedCurrency
        {
            get { return Currency.MAD; }  // je l'ai comme un choix préféré de l'utilisateur
        }

        public bool IsInRole(Role role)
        {
            //return Accessor.HttpContext.User.IsInRole(role.ToString());
            return false;
        }
    }
}
