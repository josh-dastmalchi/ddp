using System.Threading.Tasks;

namespace Ddp.Data.Ef
{
    public interface IDdpContextProvider
    {
        Task<DdpContext> Get();
    }
}