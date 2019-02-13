using System;
using Ddp.Domain.EntityTypes;

namespace Testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var thing = new EntityType(Guid.NewGuid(), "mm");
            thing.Rename("mmmmmmm");
            
        }
    }
}
