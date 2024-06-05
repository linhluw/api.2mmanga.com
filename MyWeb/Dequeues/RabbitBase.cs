using RabbitMQ.Client;
using System;

namespace MyWeb.Dequeues
{
    public class RabbitBase : IDisposable
    {
        private ConnectionFactory factory = null;

        public RabbitBase(ConnectionFactory factory)
        {
            this.factory = factory;
        }

        private IConnection connection = null;
        /// <summary>
        /// Lấy ra connection
        /// </summary>
        public IConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = factory.CreateConnection();
                }
                return connection;
            }
        }

        private IModel channel = null;
        /// <summary>
        /// 
        /// </summary>
        public IModel Channel
        {
            get
            {
                if (channel == null)
                {
                    channel = Connection.CreateModel();

                }
                return channel;
            }
        }

        public void Publish(string exchangeKey, string routingKey, byte[] b)
        {
            var properties = Channel.CreateBasicProperties();
            Channel.BasicPublish(exchangeKey, routingKey, null, b);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (channel != null) channel.Dispose();
                if (connection != null) connection.Dispose();
                channel = null;
                connection = null;
            }
            catch { }
        }
    }
}
