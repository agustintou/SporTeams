using ST.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ST.Repository.Base
{
    public interface IRepositoryQuery<T> where T : EntityBase
    {
        T GetById(long id);

        T GetById(long id, params Expression<Func<T, object>>[] includeProperties);

        T GetById(long id, string includeProperties);
        // ==================================================================================//
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll(string includeProperties);
        // ==================================================================================//

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado);

        IEnumerable<T> GetBYFilter(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, string includeProperties);
    }
}
