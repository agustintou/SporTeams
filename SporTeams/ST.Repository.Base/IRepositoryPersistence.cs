using ST.Domain.Base;

namespace ST.Repository.Base
{
    public interface IRepositoryPersistence<T> where T : EntityBase
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(long id);

        void Save();
    }
}
