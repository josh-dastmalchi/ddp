using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;

namespace Ddp.Data.Ef
{
    public class DdpContext : DbContext
    {
        public DbSet<EventTable> EventTables { get; set; }
    }
}
