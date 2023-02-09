using PLC.Connections;
using PLC.Models;
using Sharp7;

namespace PLC.Services
{
    public class DB41
    {
        S7Client client = new PLCConnection().OpenConnection();
        static readonly DB41DTO dB41 = new DB41DTO();
        static readonly byte[] db41Buffer = new byte[1024];

        public DB41DTO Get()
        {
            PLCConnection pLCConnection = new PLCConnection();

            client = pLCConnection.OpenConnection();
            _ = client.DBRead(41, 0, db41Buffer.Length, db41Buffer);

            //Assignments
            dB41.TesisDebi = Utils.Get.Real(db41Buffer, 0);
            dB41.TesisGünlükDebi = Utils.Get.Real(db41Buffer, 12);
            dB41.DesarjDebi = Utils.Get.Real(db41Buffer, 60); //Taşkan Debisi
            dB41.HariciDebi = Utils.Get.Real(db41Buffer, 52); //Çıkış Terfi Merkezi Debisi
            dB41.HariciDebi2 = Utils.Get.Real(db41Buffer, 56); //2. Kademe Çıkış Debisi
            dB41.NumuneHiz = Utils.Get.Real(db41Buffer, 4);
            dB41.NumuneDebi = Utils.Get.Real(db41Buffer, 8);
            dB41.Ph = Utils.Get.Real(db41Buffer, 16);
            dB41.Iletkenlik = Utils.Get.Real(db41Buffer, 20);
            dB41.CozunmusOksijen = Utils.Get.Real(db41Buffer, 24);
            dB41.NumuneSicaklik = Utils.Get.Real(db41Buffer, 28);
            dB41.Koi = Utils.Get.Real(db41Buffer, 32);
            dB41.Akm = Utils.Get.Real(db41Buffer, 36);
            dB41.KabinNem = Utils.Get.Real(db41Buffer, 44);
            dB41.KabinSicaklik = Utils.Get.Real(db41Buffer, 40);
            dB41.Pompa1Hz = Utils.Get.Real(db41Buffer, 140);
            dB41.Pompa2Hz = Utils.Get.Real(db41Buffer, 144);
            dB41.UpsGirisVolt = Utils.Get.Real(db41Buffer, 152);
            dB41.UpsCikisVolt = Utils.Get.Real(db41Buffer, 148);
            dB41.UpsKapasite = Utils.Get.Real(db41Buffer, 156);
            dB41.UpsSicaklik = Utils.Get.Real(db41Buffer, 160);
            dB41.UpsYuk = Utils.Get.Real(db41Buffer, 164);

            return dB41;
        }
    }
}
