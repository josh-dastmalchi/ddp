using System;

namespace Ddp.Domain
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message) {  }
    }
}