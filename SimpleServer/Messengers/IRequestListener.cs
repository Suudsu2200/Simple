using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Messengers
{
    public delegate void RequestReceivedHandler(Stream stream);
    public interface IRequestListener
    {
        void Listen();
        void AddClient(Stream stream);
        event RequestReceivedHandler OnRequestReceived;
    }
}
