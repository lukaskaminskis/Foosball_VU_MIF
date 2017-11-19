
using System.Runtime.Serialization;

namespace WCFService
{
    public class HelloWorldData
    {
        public HelloWorldData()
        {
            Name = "Hello";
            SayHello = false;
        }

        [DataMember]
        public bool SayHello { get; set; }

        [DataMember]
        public string Name { get; set; }

    }
}