using PLC.Connections;
using PLC.Interfaces;
using PLC.Models;
using Sharp7;
using System;

namespace PLC.Services
{
    public class DB41
    {
        int plcResult;
        public DB41DTO Get()
        {
            IPLCConnections pLCConnections = new PLCConnections();

            S7Client client = pLCConnections.Connect(plcResult);

            DB41DTO dB41 = new DB41DTO();
            byte[] dB41Buffer = new byte[248];

            switch (plcResult)
            {
                case 0:
                    AssignDB41(client, dB41, dB41Buffer);
                    break;
                case 1:

                default:
                    break;
            }
            return dB41;
        }
        public DB41DTO AssignDB41(S7Client client, DB41DTO dB41, byte[] dB41Buffer)
        {
            _ = client.DBRead(41, 0, dB41Buffer.Length, dB41Buffer);

            dB41.TesisDebi = Utils.Get.Real(dB41Buffer, 0, 60);
            dB41.TesisGünlükDebi = Utils.Get.Real(dB41Buffer, 12, 60);
            dB41.DesarjDebi = Utils.Get.Real(dB41Buffer, 60, 60); //Taşkan Debisi
            dB41.HariciDebi = Utils.Get.Real(dB41Buffer, 52, 60); //Çıkış Terfi Merkezi Debisi
            dB41.HariciDebi2 = Utils.Get.Real(dB41Buffer, 56, 60); //2. Kademe Çıkış Debisi
            dB41.NumuneHiz = Utils.Get.Real(dB41Buffer, 4);
            dB41.NumuneDebi = Utils.Get.Real(dB41Buffer, 8);
            dB41.Ph = Utils.Get.Real(dB41Buffer, 16);
            dB41.Iletkenlik = Utils.Get.Real(dB41Buffer, 20);
            dB41.CozunmusOksijen = Utils.Get.Real(dB41Buffer, 24);
            dB41.NumuneSicaklik = Utils.Get.Real(dB41Buffer, 28);
            dB41.Koi = Utils.Get.Real(dB41Buffer, 32);
            dB41.Akm = Utils.Get.Real(dB41Buffer, 36);
            dB41.KabinNem = Utils.Get.Real(dB41Buffer, 44);
            dB41.KabinSicaklik = Utils.Get.Real(dB41Buffer, 40);
            dB41.Pompa1Hz = Utils.Get.Real(dB41Buffer, 140);
            dB41.Pompa2Hz = Utils.Get.Real(dB41Buffer, 144);
            dB41.UpsGirisVolt = Utils.Get.Real(dB41Buffer, 152);
            dB41.UpsCikisVolt = Utils.Get.Real(dB41Buffer, 148);
            dB41.UpsKapasite = Utils.Get.Real(dB41Buffer, 156);
            dB41.UpsSicaklik = Utils.Get.Real(dB41Buffer, 160);
            dB41.UpsYuk = Utils.Get.Real(dB41Buffer, 164);

            return dB41;
        }
    }
}
