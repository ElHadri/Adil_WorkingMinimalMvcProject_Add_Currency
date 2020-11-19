namespace DomainLogic
{
    public interface ICurrencyConverter
    {
        Money Exchange(Money moneyWithCurrentCurrency, Currency targetCurrency);
    }
}
