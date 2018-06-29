using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleServer.Serializers;

namespace SimpleServer.Messengers
{
    public delegate void ClientAcceptedHandler(Stream stream);

    public interface IConnectionListener
    {  
        event ClientAcceptedHandler OnClientAccepted;
        void Listen(IPAddress listenerAddress, int listenerPort);
        void Stop();
    }
}
