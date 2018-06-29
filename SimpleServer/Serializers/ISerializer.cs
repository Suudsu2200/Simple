using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Serializers
{
    public interface ISerializer
    {
        void Serialize(IRequestMethod request, Stream stream);
        IRequest Deserialize(Stream stream);
    }
}
