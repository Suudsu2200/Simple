using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class RequestRoute : System.Attribute
    {
        public string Path { get; private set; }
        public RequestRoute(string path)
        {
            Path = path;
        }
    }
}
