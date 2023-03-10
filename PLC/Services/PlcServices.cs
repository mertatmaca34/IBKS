using PLC.Models;
using PLC.Utils;
using Sharp7;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace Presentation
{
    public sealed class PlcServices
    {
        private static PlcServices instance = null;
        private static readonly object padlock = new object();
        private readonly S7Client client;

        public DB41DTO dB41DTO;
        public DB4DTO dB4DTO;
        public EBTagsDTO eBTagsDTO;
        public MBTagsDTO mBTagsDTO;
        PlcServices()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            client = new S7Client();

            Timer plcTimer = new Timer
            {
                Enabled = true,
                Interval = 1000,
            };
            plcTimer.Tick += new EventHandler(plcTimer_Tick);
        }

        private void plcTimer_Tick(object sender, EventArgs e)
        {
            byte[] buffer4;
            byte[] buffer41;
            byte[] bufferEBTags;
            byte[] bufferMBTags;

            buffer4 = ReadData(4, 0, 12);
            buffer41 = ReadData(41, 0, 248);
            bufferEBTags = ReadDataInput(0, 30);
            bufferMBTags = ReadDataMB(0, 102);

            AssignDB4(buffer4);
            AssignDB41(buffer41);
            AssignEBTags(bufferEBTags);
            AssignMBTags(bufferMBTags);
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
                return;
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
                client.DBRead(db, startByte, size, buffer);
            }

            return buffer;
        }

        public byte[] ReadDataInput(int startByte, int size)
        {
            byte[] buffer = new byte[size];

            int result = client.EBRead(startByte, size, buffer);

            if (result != 0)
            {
                client.EBRead(startByte, size, buffer);
            }

            return buffer;
        }

        public byte[] ReadDataMB(int startByte, int size)
        {
            byte[] buffer = new byte[size];

            int result = client.MBRead(startByte, size, buffer);

            if (result != 0)
            {
                client.EBRead(startByte, size, buffer);
            }

            return buffer;
        }

        public DB41DTO AssignDB41(byte[] buffer)
        {
            var dB41DTO = new DB41DTO
            {
                TesisDebi = Get.Real(buffer, 0, 60),
                TesisGünlükDebi = Get.Real(buffer, 12, 60),
                DesarjDebi = Get.Real(buffer, 60, 60), //Taşkan Debisi
                HariciDebi = Get.Real(buffer, 52, 60), //Çıkış Terfi Merkezi Debisi
                HariciDebi2 = Get.Real(buffer, 56, 60), //2. Kademe Çıkış Debisi
                NumuneHiz = Get.Real(buffer, 4),
                NumuneDebi = Get.Real(buffer, 8),
                Ph = Get.Real(buffer, 16),
                Iletkenlik = Get.Real(buffer, 20),
                CozunmusOksijen = Get.Real(buffer, 24),
                NumuneSicaklik = Get.Real(buffer, 28),
                Koi = Get.Real(buffer, 32),
                Akm = Get.Real(buffer, 36),
                KabinNem = Get.Real(buffer, 44),
                KabinSicaklik = Get.Real(buffer, 40),
                Pompa1Hz = Get.Real(buffer, 140),
                Pompa2Hz = Get.Real(buffer, 144),
                UpsGirisVolt = Get.Real(buffer, 152),
                UpsCikisVolt = Get.Real(buffer, 148),
                UpsKapasite = Get.Real(buffer, 156),
                UpsSicaklik = Get.Real(buffer, 160),
                UpsYuk = Get.Real(buffer, 164)
            };

            return dB41DTO;
        }

        public DB4DTO AssignDB4(byte[] buffer)
        {
            var dB4DTO = new DB4DTO
            {
                SystemTime = Get.Time(buffer, 0)
            };

            return dB4DTO;
        }

        public EBTagsDTO AssignEBTags(byte[] buffer)
        {
            var eBTagsDTO = new EBTagsDTO
            {
                Kapi = Get.Input(buffer, 25, 5),
                Duman = Get.Input(buffer, 1, 1),
                SuBaskini = Get.Input(buffer, 0, 7),
                AcilStop = Get.Input(buffer, 25, 7),
                Pompa1Termik = Get.Input(buffer, 27, 5),
                Pompa2Termik = Get.Input(buffer, 28, 0),
                TemizSuTermik = Get.Input(buffer, 28, 2),
                YikamaTanki = Get.Input(buffer, 28, 3),
                Enerji = Get.Input(buffer, 25, 6),
                Pompa1CalisiyorMu = Get.Input(buffer, 27, 4),
                Pompa2CalisiyorMu = Get.Input(buffer, 27, 7)
            };

            return eBTagsDTO;
        }
        public MBTagsDTO AssignMBTags(byte[] buffer)
        {
            var mBTagsDTO = new MBTagsDTO
            {
                YikamaVarMi = Get.MB(buffer, 24, 1),
                HaftalikYikamaVarMi = Get.MB(buffer, 24, 2),
                ModAutoMu = Get.MB(buffer, 10, 6),
                ModBakimMi = Get.MB(buffer, 10, 4),
                ModKalibrasyonMu = Get.MB(buffer, 10, 5),
                AkmTetik = Get.MB(buffer, 101, 1),
                KoiTetik = Get.MB(buffer, 101, 2),
                PhTetik = Get.MB(buffer, 101, 3)
            };

            return mBTagsDTO;
        }
    }
}
