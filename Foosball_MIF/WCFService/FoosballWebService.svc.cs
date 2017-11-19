using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FoosballWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FoosballWebService.svc or FoosballWebService.svc.cs at the Solution Explorer and start debugging.
    public class FoosballWebService : IFoosballWebService
    {
        public void DoWork()
        {
        }

        public HelloWorldData GetHelloData(HelloWorldData helloWorldData)
        {
            if (helloWorldData == null)
            {
                throw new ArgumentNullException("helloWorldData");
            }

            if (helloWorldData.SayHello)
            {
                helloWorldData.Name = String.Format("Hello world to {0}", helloWorldData.Name);
            }
            return helloWorldData;
        }

        public string SayHelloTo(string name)
        {
            return string.Format("Hello World to you, {0}", name);
        }
    }
}
