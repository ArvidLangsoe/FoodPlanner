using MediatR;
using System;

namespace FoodPlanner.Commands
{
    public abstract class Command<T> : IRequest<T> 
    {
    }
}
