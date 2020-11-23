using DomainLogic;
using DomainLogic.Interfaces;

namespace SqlDataAccessLayer
{
    public class SqlAuditTrailAppender : IAuditTrailAppender
    {
        private readonly IUserContext userContext;
        private readonly CommerceContext context;
        private readonly ITimeProvider timeProvider;

        // ctor
        public SqlAuditTrailAppender(IUserContext userContext, CommerceContext context, ITimeProvider timeProvider)
        {
            this.userContext = userContext;
            this.context = context;
            this.timeProvider = timeProvider;
        }

        public void Append(Entity changedEntity)
        {
            AuditEntry entry = new AuditEntry
            {
                UserId = userContext.CurrentUser.Id,
                TimeOfChange = timeProvider.Now,
                EntityId = changedEntity.Id,
                EntityType = changedEntity.GetType().Name
            };

            context.AuditEntries.Add(entry);
        }
    }
}
