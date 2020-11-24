using DomainLogic;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDataAccessLayer
{
    public class SqlCurrencyRepository : ICurrencyRepository
    {
        private readonly CommerceContext context;

        // ctor
        public SqlCurrencyRepository(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            this.context = context;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            string[] codes = context.ExchangeRates.Select(rate => rate.CurrencyCode).ToArray();


            return codes.Select(code => new Currency(code));
        }
    }
}
