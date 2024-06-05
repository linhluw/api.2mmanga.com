using Newtonsoft.Json;
using System.Text;
using System;
using MyWeb.DAL.Models;
using System.Linq;
using MyWeb.COM.Helper;

namespace MyWeb.Dequeues.Queues
{
    [ProcessInfo(Exchange = "Common", RouteKey = "News")]
    public class QueueNews : RabbitChannelBase
    {
        protected override void DoProcess(byte[] message)
        {
            try
            {
                var rq = JsonConvert.DeserializeObject<JsonEntityBase<News>>(Encoding.UTF8.GetString(message));
                if (rq != null && rq.ID != Guid.Empty && rq.Data.Any())
                {
                    rq.Data.ForEach(item =>
                    {
                        
                    });
                }
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay("QueueError", ex.ToString());
            }
        }
    }
}
