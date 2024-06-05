using Microsoft.Extensions.Options;
using MyWeb.Dequeues.Queues;
using System.Collections.Generic;
using System.Linq;

namespace MyWeb.Dequeues
{
    public partial class RabbitChannelProcess
    {
       
        public readonly RabbitMQClientBase _rb;
      
        public readonly IOptions<RabbitMQOnline> _rbOptions;

        public RabbitChannelProcess(
            RabbitMQClientBase rb,
            IOptions<RabbitMQOnline> rbOptions)
        {
            _rb = rb;
            _rbOptions = rbOptions;
        }

        public void InitProcess()
        {
            AddProcess<QueueNews>();
        }

        public void ReloadSystem()
        {
            // Method intentionally left empty.
        }

        private readonly List<RabbitChannelBase> listProcess = new List<RabbitChannelBase>();

        public List<RabbitChannelBase> ListProcess
        {
            get { return listProcess; }
        }

        protected void AddProcess<T>() where T : RabbitChannelBase, new()
        {
            var t = new T();
            var info = (ProcessInfoAttribute)typeof(T).GetCustomAttributes(true).FirstOrDefault();
            if (info != null)
            {
                t.rb = _rb;
                t.Center = this;
                t.processInfo = info;
                listProcess.Add(t);
            }
        }
    }
}
