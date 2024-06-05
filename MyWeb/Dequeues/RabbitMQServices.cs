using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace MyWeb.Dequeues
{
    public class RabbitMQServices : BackgroundService
    {
        public RabbitChannelProcess _process;

        public RabbitMQServices(RabbitChannelProcess process)
        {
            _process = process;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _process.InitProcess();
            foreach (var p in _process.ListProcess) { p.Init(); p.Do(); }
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _process.ReloadSystem();
                await Task.Delay(60 * 1_000, stoppingToken);
            }
        }
    }
}
