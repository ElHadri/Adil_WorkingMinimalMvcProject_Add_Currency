using DomainLogic;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SqlDataAccessLayer
{
    public class SqlExchangeRateProvider : IExchangeRateProvider
    {
        private readonly CommerceContext context;

        public SqlExchangeRateProvider(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            this.context = context;
        }

        public ReadOnlyDictionary<Currency, decimal> GetExchangeRatesFor(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            var rates = context.ExchangeRates.ToArray();

            var rate = rates.Single(r => r.CurrencyCode == currency.Code);

            var dictionary = rates.ToDictionary(
                keySelector: r => new Currency(r.CurrencyCode),
                elementSelector: r => r.Rate / rate.Rate);

            return new ReadOnlyDictionary<Currency, decimal>(dictionary);
        }

        public void UpdateExchangeRate(Currency currency, decimal rate)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            var rates = context.ExchangeRates.Single(r => r.CurrencyCode == currency.Code);

            rates.Rate = rate;

            context.SaveChanges();
        }
    }
}
