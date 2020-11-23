namespace DomainLogic.Interfaces
{
    // Allows appending entries to the auditing table by passing in a domain Entity that’s being altered
    public interface IAuditTrailAppender
    {
        void Append(Entity changedEntity);
    }
}
