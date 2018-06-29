using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleServer.Serializers;

namespace SimpleServer.Messengers
{
    public class RequestListener : IRequestListener
    {
        private List<Stream> _addBuffer;
        private List<Stream> _clients;
        private ISerializer _serializer;

        public event RequestReceivedHandler OnRequestReceived;

        public RequestListener(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Listen()
        {

        }

        public void AddClient(Stream stream)
        {
            _addBuffer.Add(stream);
        }

        private void ListenForRequests()
        {
            foreach (Stream client in _clients)
            {
                if (_serializer.Deserialize(client) != null)
                {
                    ThreadPool.
                }
            }
            foreach (Stream clientToAdd in _addBuffer)
                _clients.Add(clientToAdd);
        }
    }
}
