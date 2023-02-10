using PLC.Interfaces;
using Sharp7;

namespace PLC.Connections
{
    public class PLCConnections : IPLCConnections
    {
        static readonly S7Client client = new S7Client(); //PLC Nesnesi Oluşturma
        public S7Client Connect()
        {
            if (!client.Connected)
            {
                int plcResult = client.ConnectTo("10.33.2.253", 0, 1);
                return client;
            }
            else
            {
                return client;
            }
        }
        public void Disconnect()
        {
            client.Disconnect();
        }

        S7Client IPLCConnections.Connect(int res)
        {
            S7Client client = new S7Client();
            int plcResult = client.ConnectTo("10.33.2.253", 0, 1);

            return client;
        }
    }
}