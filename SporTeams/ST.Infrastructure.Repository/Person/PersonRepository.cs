using ST.Domain.Repository.Person;
using ST.Repository;

namespace ST.Infrastructure.Repository.Person
{
    public class PersonRepository : Repository<Domain.Entities.Person>, IPersonRepository
    {
    }
}
