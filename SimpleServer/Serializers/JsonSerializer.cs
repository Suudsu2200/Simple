using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace SimpleServer.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public void Serialize(IRequestMethod method, Stream stream)
        {
            string requestMethod = JsonConvert.SerializeObject(method);
            string requestHeader = JsonConvert.SerializeObject(new RequestHeader
                {
                    MethodSize = requestMethod.Length,
                    MethodType = method.GetType()
                });

            string fullRequest = requestHeader + "\r\n\r\n" + requestMethod;

            StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
            writer.Write(fullRequest);
            writer.Flush();
        }

        public IRequest Deserialize(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
            {
                RequestHeader header = DeserializeHeader(reader);
                IRequestMethod method = DeserializeMethod(reader, header.MethodSize, header.MethodType);

                return new Request
                {
                    Header = header,
                    Method = method
                };
            }
        }

        private RequestHeader DeserializeHeader(StreamReader reader)
        {
            StringBuilder headerString = new StringBuilder();
            while (!reader.EndOfStream)
            {
                string nextLine = reader.ReadLine();
                if (nextLine == string.Empty)
                    break;
                if (nextLine == null || headerString.Length + nextLine.Length > 1000)
                {
                    reader.BaseStream.Seek(Encoding.Unicode.GetByteCount(headerString + nextLine), SeekOrigin.Current);
                    return null;
                }
                headerString.Append(nextLine);
            }
            return JsonConvert.DeserializeObject<RequestHeader>(headerString.ToString());
        }

        private IRequestMethod DeserializeMethod(StreamReader reader, int methodSize, Type methodType)
        {
            char[] bytes = new char[methodSize];
            int bytesRead = reader.Read(bytes, 0, methodSize);
            if (bytesRead != methodSize)
                return null;
            return (IRequestMethod)JsonConvert.DeserializeObject(new string(bytes), methodType);
        }

    }
}
