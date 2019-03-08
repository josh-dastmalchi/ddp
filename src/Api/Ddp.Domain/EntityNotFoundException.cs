using System;

namespace Ddp.Domain
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        } 
    }
}
