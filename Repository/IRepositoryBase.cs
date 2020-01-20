using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ethereal_EM.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T FindByCompositeID(int ID1, int ID2);
        T FindByCompositeID(int ID1, int ID2, int ID3);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool AnyByCondition(Expression<Func<T, bool>> expression);
        T FindByID(int ID);
        T FindByString(string ID);
        void Create(dynamic entity, bool flush = true);
        void Update(dynamic entity, bool flush = true);
        void Delete(dynamic entity, bool flush = true);
        void Save();
        dynamic GetPermission(int id);
    }
}
