using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Queries
{
    public abstract class Query<T> : IRequest<T>
    {
    }
}
