using System.Threading;
using System.Threading.Tasks;

namespace Ddp.Application
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}