using DomainLogic;

namespace CurrencyConverterLibrary
{
    public class CurrencyConverterTrial : ICurrencyConverter
    {
        public Money Exchange(Money money, Currency targetCurrency)
        {
            return new Money(money.Amount * 1m, Currency.EUR);
        }

    }
}
