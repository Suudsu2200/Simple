using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleServer.Serializers;

namespace SimpleServer.Messengers
{
    public class SslConnectionListener : IConnectionListener
    {
        private X509Certificate _serverCertificate;
        private bool _isListening;
        private TcpListener _listener;

        public event ClientAcceptedHandler OnClientAccepted;

        public SslConnectionListener(X509Certificate serverCertificate)
        {
            _serverCertificate = serverCertificate;
            _isListening = false;
        }

        public void Listen(IPAddress listenerAddress, int listenerPort)
        {
            if (_isListening) return;
            _isListening = true;
            _listener = new TcpListener(listenerAddress, listenerPort);
            _listener.Start();
            ThreadPool.QueueUserWorkItem(ListenForClient);
        }

        public void Stop()
        {
            if (!_isListening) return;
            _isListening = false;
            _listener.Stop();
        }

        private void ListenForClient(object tcpListener)
        {
            while (_isListening)
            {
                TcpListener listener = (TcpListener) tcpListener;
                while (!listener.Pending())
                    Thread.Sleep(250);
                TcpClient client = listener.AcceptTcpClient();
                SslStream sslStream = new SslStream(client.GetStream());
                OnClientAccepted(sslStream);
            }
        }
    }
}
