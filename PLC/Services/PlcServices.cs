using PLC.Models;
using PLC.Utils;
using Sharp7;
using System;

namespace Presentation
{
    public sealed class PlcServices
    {
        private static PlcServices instance = null;
        private static readonly object padlock = new object();
        private S7Client client;

        PlcServices()
        {
            client = new S7Client();
        }

        public static PlcServices Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PlcServices();
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

        public DB41DTO AssignDB41(byte[] buffer)
        {
            DB41DTO dB41 = new DB41DTO();
            _ = client.DBRead(41, 0, buffer.Length, buffer);

            dB41.TesisDebi = Get.Real(buffer, 0, 60);
            dB41.TesisGünlükDebi = Get.Real(buffer, 12, 60);
            dB41.DesarjDebi = Get.Real(buffer, 60, 60); //Taşkan Debisi
            dB41.HariciDebi = Get.Real(buffer, 52, 60); //Çıkış Terfi Merkezi Debisi
            dB41.HariciDebi2 = Get.Real(buffer, 56, 60); //2. Kademe Çıkış Debisi
            dB41.NumuneHiz = Get.Real(buffer, 4);
            dB41.NumuneDebi = Get.Real(buffer, 8);
            dB41.Ph = Get.Real(buffer, 16);
            dB41.Iletkenlik = Get.Real(buffer, 20);
            dB41.CozunmusOksijen = Get.Real(buffer, 24);
            dB41.NumuneSicaklik = Get.Real(buffer, 28);
            dB41.Koi = Get.Real(buffer, 32);
            dB41.Akm = Get.Real(buffer, 36);
            dB41.KabinNem = Get.Real(buffer, 44);
            dB41.KabinSicaklik = Get.Real(buffer, 40);
            dB41.Pompa1Hz = Get.Real(buffer, 140);
            dB41.Pompa2Hz = Get.Real(buffer, 144);
            dB41.UpsGirisVolt = Get.Real(buffer, 152);
            dB41.UpsCikisVolt = Get.Real(buffer, 148);
            dB41.UpsKapasite = Get.Real(buffer, 156);
            dB41.UpsSicaklik = Get.Real(buffer, 160);
            dB41.UpsYuk = Get.Real(buffer, 164);

            return dB41;
        }
    }

}
