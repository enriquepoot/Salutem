using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quimank.Utilities.DataAccess;
using Salutem.Entities;

namespace Salutem.DataAccess.Interfaces
{
    public interface IAccessRepository : IRepositoryBase<Access>
    {
        Access GetByUserAndPassword(string UserIdentifier, string password = null);
    }
}
