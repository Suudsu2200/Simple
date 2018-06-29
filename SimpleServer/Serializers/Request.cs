using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Serializers
{
    public class Request : IRequest
    {
        public RequestHeader Header { get; set; }
        public IRequestMethod Method { get; set; }
    }
}
