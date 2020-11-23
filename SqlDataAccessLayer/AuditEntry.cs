using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDataAccessLayer
{
    public class AuditEntry
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeOfChange { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; }

    }
}
