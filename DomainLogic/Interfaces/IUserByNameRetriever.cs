using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic.Interfaces
{
    public interface IUserByNameRetriever
    {
        User GetByName(string name);
    }
}
