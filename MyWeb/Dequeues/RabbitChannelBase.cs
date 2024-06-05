using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyWeb.Dequeues
{
    public abstract class RabbitChannelBase
    {
        public RabbitMQClientBase rb;

        protected EventingBasicConsumer consumer;

        public ProcessInfoAttribute processInfo { get; set; }

        public RabbitChannelProcess Center { get; set; }

        public virtual void Do()
        {
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                DoProcess(body.ToArray());
            };

        }
        protected abstract void DoProcess(byte[] message);

        public virtual void Init()
        {
            consumer = new EventingBasicConsumer(rb.Rabbit.Channel);
            rb.Rabbit.Channel.QueueDeclare(processInfo.RouteKey + processInfo.QueueName, processInfo.Durable, processInfo.Exclusive, processInfo.AutoDelete, null);
            rb.Rabbit.Channel.QueueBind(processInfo.RouteKey + processInfo.QueueName, processInfo.Exchange, processInfo.RouteKey);
            rb.Rabbit.Channel.BasicConsume(processInfo.RouteKey + processInfo.QueueName, autoAck: processInfo.AutoAck, consumer: consumer);
        }
    }
}
