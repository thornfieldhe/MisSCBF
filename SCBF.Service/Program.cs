using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCBF.Service
{
    using Topshelf;

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<DefaultService>();
                x.RunAsLocalSystem();

                x.SetDescription("提供MIS集成F服务");
                x.SetDisplayName("MIS服务集群");
                x.SetServiceName("MIS Service");
            });
        }
    }
}
