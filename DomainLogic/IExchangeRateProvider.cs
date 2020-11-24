using System.Collections.ObjectModel;

namespace DomainLogic
{
    public interface IExchangeRateProvider
    {
        // By returning a read-only dictionary, we allow currencies to be easily cached using a decorator.
        ReadOnlyDictionary<Currency, decimal> GetExchangeRatesFor(Currency currency);

        void UpdateExchangeRate(Currency currency, decimal rate);
    }
}
