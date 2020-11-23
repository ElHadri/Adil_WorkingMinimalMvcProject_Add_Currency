using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using UI_MVC.Core.Controllers;

using DomainLogic;
using SqlDataAccessLayer;
using CurrencyConverterLibrary;
using DomainLogic.Interfaces;

namespace UI_MVC.Core
{
    /*here the entire setup for the application is encapsulated */
    public class CustomControllerActivator : IControllerActivator // abstract factory
    {
        private readonly string _connectionString;
        public CustomControllerActivator(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ASP.NET Core MVC invokes this method to create a new controller instance for each incoming request(Adil)
        public object Create(ControllerContext controllerContext) // 'controllerContext' paramater est obligatoire même s'il n'est pas utilisé ici
        {
            var commerceContext = new CommerceContext(_connectionString);
            var appender = new SqlAuditTrailAppender(userContext, commerceContext, new TimeProvider());
            var userRepository = new SqlUserRepository(commerceContext, appender);
            IUserContext userContext = new AspNetUserContextAdapter(userRepository);

            /* Here we know that MVC asks for a HomeController. */
            return
                new HomeController(
                    new ProductService(
                        new SqlProductRepository(commerceContext),
                        userContext,
                        new CurrencyConverterTrial()));

            /* If we do not know what MVC asks for. */
            //Type type = context.ActionDescriptor.ControllerTypeInfo.AsType();
            //if (type == typeof(HomeController))un
            //{
            //    return
            //    new HomeController(new ProductService(new SqlProductRepository(new CommerceContext(_connectionString)),
            //                                                                      new AspNetUserContextAdapter()));
            //if (type == typeof(XController))
            //{
            //    return
            //    new XController(new ProductService(new SqlProductRepository(new CommerceContext(_connectionString)),
            //                                                                      new AspNetUserContextAdapter()));
            //}
            //else
            //{
            //    throw new Exception("Unknown controller.");
            //}
        }

        public void Release(ControllerContext context, object controller) => (controller as IDisposable)?.Dispose();

    }
}


