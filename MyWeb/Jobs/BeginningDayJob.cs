using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace MyWeb.Jobs
{
    [DisallowConcurrentExecution]
    public class BeginningDayJob : IJob
    {
        private readonly ILogger<BeginningDayJob> _logger;

        public BeginningDayJob(ILogger<BeginningDayJob> logger)
        {
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi thực thi Job {this.GetType().FullName}: {ex}");
            }
        }
    }
}
