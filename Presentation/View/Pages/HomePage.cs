using PLC.Models;
using PLC.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation.View.Pages
{
    public partial class HomePage : Form
    {
        PlcServices connection = PlcServices.Instance;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            connection.Connect("10.33.2.253", 0, 1);
        }
        
        public enum Offsets
        {
            TesisDebi = 0,
            TesisGunlukDebi = 12,
            DesarjDebi = 60,
            HariciDebi = 52,
            HariciDebi2 = 56,
            NumuneHiz = 4,
            NumuneDebi = 8,
            Ph = 16,
            Iletkenlik = 20,
            CozunmusOksijen = 24,
            NumuneSicaklik = 28,
            Koi = 32,
            Akm = 36,
            KabinSicaklik = 40,
            KabinNem = 44,
            Pompa1Hz = 140,
            Pompa2Hz = 144,
            UpsCikisVolt = 148,
            UpsGirisVolt = 152,
            UpsKapasite = 156,
            UpsSicaklik = 160,
            UpsYuk = 164
        }

        private void TimerReadPLC_Tick(object sender, EventArgs e)
        {
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                try
                {
                    byte[] buffer = connection.ReadData(41, 0, 248);

                    //DB41
                    DB41DTO dB41 = connection.AssignDB41(buffer);

                    //var dB41Result = dB41.Get();

                    LabelInstantAkm.Text = dB41.Akm + " mg/l";
                    LabelInstantCozunmusOksijen.Text = dB41.CozunmusOksijen + " mg/l";
                    LabelInstantSicaklik.Text = dB41.KabinSicaklik + "°C";
                    LabelInstantPh.Text = dB41.Ph.ToString();
                    LabelInstantIletkenlik.Text = dB41.Iletkenlik + " mS/cm";
                    LabelInstantKoi.Text = dB41.Koi + " mg/l";
                    LabelInstantAkisHizi.Text = dB41.NumuneHiz + " m/s";
                    LabelInstantDebi.Text = dB41.TesisDebi + " m³/d";
                    LabelInstantDesarjDebi.Text = dB41.DesarjDebi + " m³/d";
                    LabelInstantHariciDebi.Text = dB41.HariciDebi + " m³/d";
                    LabelInstantHariciDebi2.Text = dB41.HariciDebi2 + " m³/d";

                    /*
                    //DB4
                    DB4 dB4 = new DB4();

                    var dB4Result = dB4.Get();

                    LabelSystemTime.Text = dB4Result.SystemTime.ToString();*/
                }
                catch (Exception ex)
                {
                    //TODO

                    MessageBox.Show(ex.Message);
                }
            };
            bgw.RunWorkerAsync();
        }

    }
}
