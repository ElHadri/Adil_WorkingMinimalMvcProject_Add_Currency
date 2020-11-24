using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}
