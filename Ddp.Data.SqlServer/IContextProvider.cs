using System.Threading.Tasks;

namespace Ddp.Data.Ef
{
    public interface IContextProvider
    {
        Task<DdpContext> Get();
    }
}