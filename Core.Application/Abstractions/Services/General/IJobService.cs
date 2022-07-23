using System.Linq.Expressions;
using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.General
{
    public interface IJobService : IScopedService
    {
        string Enqueue(Expression<Func<Task>> methodCall);
    }
}