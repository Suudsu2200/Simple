using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleServer.Serializers;

namespace SimpleServer.UnitTests
{
    [TestFixture]
    public class SerializerTests
    {
        private JsonSerializer _serializer;
        private MemoryStream _stream;

        private class TestSerializationObject : IRequestMethod
        {
            public int intProperty { get; set; }
            public string stringProperty { get; set; }
        }

        public SerializerTests()
        {
            _serializer = new JsonSerializer();
            _stream = new MemoryStream();
        }

        [Test]
        public void SerializeDeserializeTest()
        {
            TestSerializationObject testObj = new TestSerializationObject
            {
                intProperty = 14,
                stringProperty = "TestString♪"
            };

            _serializer.Serialize(testObj, _stream);
            _stream.Seek(0, SeekOrigin.Begin);
            IRequest request = _serializer.Deserialize(_stream);

            Assert.AreEqual(typeof(TestSerializationObject), request.Method.GetType());
            Assert.AreEqual(testObj.intProperty, ((TestSerializationObject)request.Method).intProperty);
            Assert.AreEqual(testObj.stringProperty, ((TestSerializationObject)request.Method).stringProperty);
        }

    }
}
