using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        User GetById(Guid id);
        User GetByName(string name);
    }
}
