﻿namespace DomainLogic
{
    public class Money
    {
        public readonly decimal Amount;
        public readonly Currency Currency;

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
