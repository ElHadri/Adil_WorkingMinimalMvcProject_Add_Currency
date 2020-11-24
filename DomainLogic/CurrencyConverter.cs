using System;

namespace DomainLogic
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly IExchangeRateProvider exchangeRateProvider;

        // ctor
        public CurrencyConverter(IExchangeRateProvider exchangeRateProvider)
        {
            if (exchangeRateProvider == null) throw new ArgumentNullException(nameof(exchangeRateProvider));

            this.exchangeRateProvider = exchangeRateProvider;
        }

        public Money Exchange(Money money, Currency targetCurrency)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            if (targetCurrency == null) throw new ArgumentNullException(nameof(targetCurrency));

            var exchangeRates = exchangeRateProvider.GetExchangeRatesFor(money.Currency);
            var exchangeRate = exchangeRates[targetCurrency];

            return new Money(money.Amount * exchangeRate, targetCurrency);
        }
    }
}
