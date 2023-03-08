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
        private readonly S7Client client;

        public DB41DTO dB41DTO;
        public DB4DTO dB4DTO;
        public EBTagsDTO eBTagsDTO;
        PlcServices()
        {
            client = new S7Client();

            System.Windows.Forms.Timer plcTimer = new System.Windows.Forms.Timer
            {
                Enabled = true,
                Interval = 1000,
            };
            plcTimer.Tick += new EventHandler(plcTimer_Tick);
        }

        private void plcTimer_Tick(object sender, EventArgs e)
        {
            byte[] buffer4 = ReadData(4, 0, 12);
            byte[] bufferEBTags = ReadData(0, 30);
            byte[] buffer41 = ReadData(41, 0, 248);

            AssignDB4(buffer4);
            AssignDB41(buffer41);
            AssignEBTags(bufferEBTags);
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

        public byte[] ReadData(int startByte, int size)
        {
            byte[] buffer = new byte[size];

            int result = client.EBRead(startByte, size, buffer);

            if (result != 0)
            {
                client.EBRead(startByte, size, buffer);
            }

            return buffer;
        }

        public DB41DTO AssignDB41(byte[] buffer)
        {
            dB41DTO = new DB41DTO
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
            dB4DTO = new DB4DTO
            {
                SystemTime = Get.Time(buffer, 0)
            };

            return dB4DTO;
        }

        public EBTagsDTO AssignEBTags(byte[] buffer)
        {
            eBTagsDTO = new EBTagsDTO
            {
                Kapi = Get.Bit(buffer, 25, 5),
                Duman = Get.Bit(buffer, 1, 1),
                SuBaskini = Get.Bit(buffer, 0, 7),
                AcilStop = Get.Bit(buffer, 25, 7),
                Pompa1Termik = Get.Bit(buffer, 27, 5),
                Pompa2Termik = Get.Bit(buffer, 28, 0),
                TemizSuTermik = Get.Bit(buffer, 28, 2),
                YikamaTanki = Get.Bit(buffer, 28, 3),
                Enerji = Get.Bit(buffer, 25, 6),
                Pompa1CalisiyorMu = Get.Bit(buffer, 27, 4),
                Pompa2CalisiyorMu = Get.Bit(buffer, 27, 7)
            };

            return eBTagsDTO;
        }
    }
}
