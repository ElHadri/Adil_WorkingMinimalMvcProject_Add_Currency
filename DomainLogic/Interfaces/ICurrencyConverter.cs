namespace DomainLogic.Interfaces
{
    public interface ICurrencyConverter
    {
        Money Exchange(Money moneyWithCurrentCurrency, Currency targetCurrency);
    }
}
