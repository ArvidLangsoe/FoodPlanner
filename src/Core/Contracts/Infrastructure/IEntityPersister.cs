using System.Threading.Tasks;

namespace Kappelhoj.FoodPlanner.Core.Contracts
{
    public interface IEntityPersister
    {
        public Task<T> PersistEntity<T>(T entity);

    }
}
