using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Serializers
{
    public interface IRequest
    {
        RequestHeader Header { get; set; }
        IRequestMethod Method { get; set; }
    }
}
