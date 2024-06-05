using System;
using System.Collections.Generic;

namespace MyWeb.Dequeues
{
    public class ProcessInfoAttribute : Attribute
    {
        public string Exchange { get; set; }

        public string RouteKey { get; set; }

        public string QueueName { get; set; } = "-Sync-" + Guid.NewGuid().ToString().ToUpper();

        public bool Durable { get; set; } = false;

        public bool Exclusive { get; set; } = true;

        public bool AutoDelete { get; set; } = true;

        public bool AutoAck { get; set; } = true;
    }

    public class JsonEntityBase<T>
    {
        public Guid ID { get; set; }

        public string RoutingKey { get; set; }

        public int TimeSend { get; set; }

        public List<T> Data { get; set; }
    }
}
