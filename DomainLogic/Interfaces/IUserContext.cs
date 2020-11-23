namespace DomainLogic.Interfaces
{
    public interface IUserContext
    {
        Currency PreferedCurrency { get; }
        User CurrentUser { get; }
        bool IsInRole(Role role);
    }

    public enum Role
    {
        PreferredCustomer
    }
}

