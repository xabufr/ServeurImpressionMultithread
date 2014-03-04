using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface Client
    {
        void work();
        void sendJobInfos(Job job);
        void setServer(Server server);
        void sendNewJobId(Job job);
    }
}
