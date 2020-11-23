using DomainLogic;
using DomainLogic.Interfaces;

using System;

namespace SqlDataAccessLayer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly IAuditTrailAppender appender;
        private readonly CommerceContext context;

        // ctor
        public SqlUserRepository(CommerceContext context, IAuditTrailAppender appender)
        {
            this.appender = appender;
            this.context = context;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException(); // to do 
        }

        public void Update(User user)
        {
            /* This allows an entry to be appended to the audit trail */
            appender.Append(user);

            //Original,unchanged code ...
        }
    }
}