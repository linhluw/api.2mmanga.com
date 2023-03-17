using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;
using MyWeb.Data;

namespace MyWeb.Jobs
{
    [DisallowConcurrentExecution]
    public class BeginningDayJob : IJob
    {
        private readonly ILogger<BeginningDayJob> _logger;
        private readonly IDbInitializer _dbInitializer;

        public BeginningDayJob(ILogger<BeginningDayJob> logger, IDbInitializer dbInitializer)
        {
            _logger = logger;
            _dbInitializer = dbInitializer;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                await _dbInitializer.SeedFromServiceCacheToInstanceCache();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi thực thi Job {this.GetType().FullName}: {ex}");
            }
        }
    }
}
