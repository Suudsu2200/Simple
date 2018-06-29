using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleServer.Attributes;

namespace SimpleServer
{
    public class ServerBase
    {
        /*private Dictionary<typeof> _router;

        public ServerBase()
        { 
             
        }

        private void InitializeRouter()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            foreach (Type t in entryAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(Handler))))
            {
                Handler handler = (Handler)Activator.CreateInstance(t);
                MethodInfo info;
                if ( (info = t.GetMethods().SingleOrDefault(method => method.Name == "Handle")) != null)
                    _router.ADd

            }
        }*/

    }
}
