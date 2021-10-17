using MediatR;

namespace Kappelhoj.FoodPlanner.Queries
{
    public abstract class Query<T> : IRequest<T>
    {
    }
}
