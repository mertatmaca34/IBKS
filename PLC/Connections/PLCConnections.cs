using PLC.Interfaces;
using PLC.Models;
using Sharp7;

namespace PLC.Connections
{
    public class PLCConnections : IPLCConnections
    {
        static readonly S7Client client = new S7Client(); //PLC Nesnesi Oluşturma

        int res = client.ConnectTo("10.33.2.253", 0, 1);

        S7Client IPLCConnections.Connect()
        {
            if (res != 0)
            {
                res = client.ConnectTo("10.33.2.253", 0, 1);
            }

            return client;
        }
    }
}