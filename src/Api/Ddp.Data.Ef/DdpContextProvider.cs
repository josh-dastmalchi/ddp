using System.Threading.Tasks;
using Autofac;

namespace Ddp.Data.Ef
{
    public class DdpContextProvider : IDdpContextProvider
    {
        private readonly IComponentContext _componentContext;
        private DdpContext _context;
        public DdpContextProvider(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public Task<DdpContext> Get()
        {
            if (_context == null)
            {
                _context = _componentContext.Resolve<DdpContext>();
            }

            return Task.FromResult(_context);
        }
    }
}
