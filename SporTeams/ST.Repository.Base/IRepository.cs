using ST.Domain.Base;

namespace ST.Repository.Base
{
    public interface IRepository<T> : IRepositoryQuery<T>, IRepositoryPersistence<T> where T : EntityBase
    {

    }
}
