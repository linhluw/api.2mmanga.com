using System.Collections.Generic;

namespace MyWeb.Quartz
{
    public class QuartzOptions
    {
        public bool Enabled { get; set; }

        public List<JobOption> JobOption { get; set; }
    }

    public class JobOption
    {
        public bool Enabled { get; set; }

        public string JobName { get; set; }

        public string JobType { get; set; }

        public string CronExpression { get; set; }
    }
}
