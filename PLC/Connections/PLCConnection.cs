using Sharp7;
using System.Collections.Generic;

namespace PLC.Connections
{
    internal class PLCConnection
    {
        static readonly S7Client client = new S7Client(); //PLC Nesnesi Oluşturma

        internal S7Client OpenConnection()
        {
            if (!client.Connected)
            {
                _ = client.ConnectTo("10.33.3.253", 0, 1);

                return client;
            }
            else
            {
                return client;
            }
        }
    }
}
