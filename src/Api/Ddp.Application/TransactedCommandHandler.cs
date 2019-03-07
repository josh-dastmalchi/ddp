using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ddp.Application
{
    public abstract class TransactedCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand:ICommand
    {
        protected abstract Task HandleTransacted(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
        public async Task Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await HandleTransacted(command, cancellationToken);
                transactionScope.Complete();
            }   
        }
    }
}
