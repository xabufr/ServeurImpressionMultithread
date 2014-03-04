using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    abstract class Server
    {
        private PrinterPool printerPool;
        private Dictionary<Client, Thread> clients;
        public Server(PrinterPool printerPool)
        {
            this.printerPool = printerPool;
            this.clients = new Dictionary<Client, Thread>();
        }
        
    }
}
