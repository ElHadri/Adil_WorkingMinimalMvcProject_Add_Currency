using System;
using DomainLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using SqlDataAccessLayer;
using UI_MVC.Core.Controllers;

namespace UI_MVC.Core
{
    public class CustomControllerActivator : IControllerActivator
    {
        private readonly string _connectionString;
        public CustomControllerActivator(string connectionString)
        {
            _connectionString = connectionString;
        }

        // When a page request comes (Adil)
        public object Create(ControllerContext context) // 'context' paramater est obligatoire même s'il n'est pas utilisé ici
        {
            return new HomeController(new ProductService(new SqlProductRepository(new CommerceContext(_connectionString)),
                                                                                  new AspNetUserContextAdapter()));                                                        
        }

        public void Release(ControllerContext context, object controller) => (controller as IDisposable)?.Dispose();

    }
}


