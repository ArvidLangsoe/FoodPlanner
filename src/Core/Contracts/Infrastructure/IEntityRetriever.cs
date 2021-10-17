using System.Linq;
using System.Threading.Tasks;

namespace Kappelhoj.FoodPlanner.Core.Contracts
{
    public interface IEntityRetriever
    {

        public Task<IQueryable<T>> QueryEntities<T>();
    }
}
