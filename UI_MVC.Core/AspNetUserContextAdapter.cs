using DomainLogic;
using DomainLogic.Interfaces;

using Microsoft.AspNetCore.Http;

using System;

namespace UI_MVC.Core
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static HttpContextAccessor Accessor = new HttpContextAccessor();

        // added to allow retrieving user information from the database.
        private readonly IUserRepository repository;

        public AspNetUserContextAdapter(IUserRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("userRepository");

            this.repository = repository;
        }

        public User CurrentUser
        {
            // Gets the name of the logged-in user from the HttpContext and uses it to request a User instance from the IUserRepository
            get
            {
                var user = Accessor.HttpContext.User;
                string userName = user.Identity.Name;
                return repository.GetByName(userName);
            }
        }

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
