namespace DomainLogic.Interfaces
{
    public interface IUserContext
    {
        Currency PreferedCurrency { get; }
        bool IsInRole(Role role);
    }

    public enum Role
    {
        PreferredCustomer
    }
}

