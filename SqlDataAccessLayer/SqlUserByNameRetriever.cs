using DomainLogic;
using DomainLogic.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDataAccessLayer
{
    public class SqlUserByNameRetriever : IUserByNameRetriever
    {
        private readonly CommerceContext _context;

        // ctor
        public SqlUserByNameRetriever(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException(); // to do ...
        }
    }
}
