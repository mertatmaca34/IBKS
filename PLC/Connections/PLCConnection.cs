using Sharp7;
using System;

namespace PLC.Connections
{
    public class PLCConnection
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
    }
}