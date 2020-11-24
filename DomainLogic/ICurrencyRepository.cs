using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencies();
    }
}
