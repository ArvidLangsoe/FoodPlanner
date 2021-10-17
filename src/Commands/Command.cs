using MediatR;

namespace Kappelhoj.FoodPlanner.Commands
{
    public abstract class Command<T> : IRequest<T>
    {
    }
}
