using DomainLogic.DomainEvents;
using DomainLogic.Interfaces;

using System;

namespace DomainLogic
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEventHandler<CustomerCreated> handler;

        public CustomerService(
            ICustomerRepository customerRepository,
            IEventHandler<CustomerCreated> handler)
        {
            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");
            if (handler == null)
                throw new ArgumentNullException("customerCreatedEventHandler");

            this.customerRepository = customerRepository;
            this.handler = handler;
        }
    }
}
