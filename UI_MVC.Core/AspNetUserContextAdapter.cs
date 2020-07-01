using DomainLogic;
using Microsoft.AspNetCore.Http;

namespace UI_MVC.Core
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static HttpContextAccessor Accessor = new HttpContextAccessor();

        public bool IsInRole(Role role)
        {
            return Accessor.HttpContext.User.IsInRole(role.ToString());
        }
    }
}
    