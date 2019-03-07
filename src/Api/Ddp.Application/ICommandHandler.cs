using System.Threading;
using System.Threading.Tasks;

namespace Ddp.Application
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}