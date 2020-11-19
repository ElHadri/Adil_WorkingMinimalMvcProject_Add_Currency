using DomainLogic;
using System;

namespace CurrencyConverterLibrary
{
    public class CurrencyConverterTrial : ICurrencyConverter
    {
        public Money Exchange(Money money, Currency targetCurrency)
        {
            switch (money.Currency)
            {
                case Currency.EUR:
                    switch (targetCurrency)
                    {
                        case Currency.EUR:
                            return new Money(money.Amount * 1m, Currency.EUR);
                        case Currency.USD:
                            return new Money(money.Amount * 1.12m, Currency.USD);
                        case Currency.MAD:
                            return new Money(money.Amount * 10.90m, Currency.MAD);
                        default:
                            return new Money(money.Amount * 1m, Currency.EUR);
                    }

                case Currency.USD:
                    switch (targetCurrency)
                    {
                        case Currency.EUR:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        case Currency.USD:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        case Currency.MAD:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        default:
                            return new Money(money.Amount * 0m, Currency.EUR);
                    }

                case Currency.MAD:
                    switch (targetCurrency)
                    {
                        case Currency.EUR:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        case Currency.USD:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        case Currency.MAD:
                            return new Money(money.Amount * 0m, Currency.EUR);
                        default:
                            return new Money(money.Amount * 0m, Currency.EUR);
                    }

                default:
                    throw new Exception("Adil");
            }
        }

    }
}
