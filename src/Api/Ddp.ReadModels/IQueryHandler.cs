using System.Threading;
using System.Threading.Tasks;

namespace Ddp.ReadModels
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}
