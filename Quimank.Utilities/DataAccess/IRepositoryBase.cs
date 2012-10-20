using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quimank.Utilities.DataAccess
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAllWithDeleted();
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
