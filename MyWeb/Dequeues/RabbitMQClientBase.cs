using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace MyWeb.Dequeues
{
    public class RabbitMQClientBase
    {
        private RabbitBase rabbit = null;

        private readonly IOptions<RabbitMQOptions> _rbo;

        public RabbitMQClientBase(IOptions<RabbitMQOptions> rbo)
        {
            _rbo = rbo;
        }

        protected virtual ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = _rbo.Value.HostName,// RabbitSetting.RabbitHostName,
                Port = _rbo.Value.Port, // RabbitSetting.RabbitPort,
                UserName = _rbo.Value.UserName, //RabbitSetting.RabbitUserName,
                Password = _rbo.Value.Password, // RabbitSetting.RabbitPassword,
                VirtualHost = string.IsNullOrEmpty(_rbo.Value.VirtualHost) ? "/" : _rbo.Value.VirtualHost,
                AutomaticRecoveryEnabled = true
            };
        }

        public RabbitBase Rabbit
        {
            get
            {
                if (rabbit == null) rabbit = new RabbitBase(CreateConnectionFactory());
                return rabbit;
            }
        }

        public void Send(string exchange, string routekey, byte[] obj)
        {
            Rabbit.Publish(exchange, routekey, obj);
        }
    }
}
