using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation.View.Pages
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
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
                    PlcConnection2 connection = PlcConnection2.Instance;
                    connection.Connect("10.33.2.253", 0, 1);

                    byte[] data = connection.ReadData(41, 0, 248);


                    //DB41
                    //DB41 dB41 = new DB41();

                    //var dB41Result = dB41.Get();

                    LabelInstantAkm.Text = data[(int)Offsets.Akm] + " mg/l";
                    LabelInstantCozunmusOksijen.Text = data[(int)Offsets.CozunmusOksijen] + " mg/l";
                    LabelInstantSicaklik.Text = data[(int)Offsets.KabinSicaklik] + "°C";
                    LabelInstantPh.Text = data[(int)Offsets.Ph].ToString();
                    LabelInstantIletkenlik.Text = data[(int)Offsets.Iletkenlik] + " mS/cm";
                    LabelInstantKoi.Text = data[(int)Offsets.Koi] + " mg/l";
                    LabelInstantAkisHizi.Text = data[(int)Offsets.NumuneHiz] + " m/s";
                    LabelInstantDebi.Text = data[(int)Offsets.TesisDebi] + " m³/d";
                    LabelInstantDesarjDebi.Text = data[(int)Offsets.DesarjDebi] + " m³/d";
                    LabelInstantHariciDebi.Text = data[(int)Offsets.HariciDebi] + " m³/d";
                    LabelInstantHariciDebi2.Text = data[(int)Offsets.HariciDebi2] + " m³/d";
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
