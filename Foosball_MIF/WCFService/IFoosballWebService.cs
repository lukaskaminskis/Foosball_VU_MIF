using System.ServiceModel;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFoosballWebService" in both code and config file together.
    [ServiceContract]
    public interface IFoosballWebService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string SayHelloTo(string name);

        [OperationContract]
        HelloWorldData GetHelloData(HelloWorldData helloWorldData);

    }
}
