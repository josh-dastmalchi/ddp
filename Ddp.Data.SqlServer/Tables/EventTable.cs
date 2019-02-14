using System;
using System.Collections.Generic;
using System.Text;

namespace Ddp.Data.Ef.Tables
{
    public class EventTable
    {
        public Guid EventId { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public int Sequence { get; set; }
        public int Version { get; set; }
    }
}
