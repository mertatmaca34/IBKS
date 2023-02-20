using Sharp7;
using System.ComponentModel.DataAnnotations;
using System;

namespace Presentation
{
    public sealed class PlcConnection2
    {
        private static PlcConnection2 instance = null;
        private static readonly object padlock = new object();
        private S7Client client;

        PlcConnection2()
        {
            client = new S7Client();
        }

        public static PlcConnection2 Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PlcConnection2();
                    }
                    return instance;
                }
            }
        }

        public void Connect(string ipAddress, int rack, int slot)
        {
            int result = client.ConnectTo(ipAddress, rack, slot);

            if (result != 0)
            {
                throw new Exception("Could not connect to PLC.");
            }
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public byte[] ReadData(int db, int startByte, int size)
        {
            byte[] buffer = new byte[size];

            int result = client.DBRead(db, startByte, size, buffer);

            if (result != 0)
            {
                throw new Exception("Error reading data from PLC.");
            }

            return buffer;
        }
    }

}
