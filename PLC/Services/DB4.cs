using PLC.Connections;
using PLC.Interfaces;
using PLC.Models;
using System;

namespace PLC.Services
{
    public class DB4
    {
        public DB4DTO Get()
        {
            IPLCConnections pLCConnections = new PLCConnections();
            var client = pLCConnections.Connect();
            DB4DTO dB4 = new DB4DTO();
            byte[] db4Buffer = new byte[12];

            _ = client.DBRead(4, 0, db4Buffer.Length, db4Buffer);

            AssignDB4(dB4, db4Buffer);

            return dB4;
        }
        public DB4DTO AssignDB4(DB4DTO dB4, byte[] db4Buffer)
        {
            dB4.SystemTime = Utils.Get.Time(db4Buffer, 0);

            return dB4;
        }
    }
}