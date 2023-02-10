using PLC.Connections;
using PLC.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation.View.Pages
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void TimerReadPLC_Tick(object sender, EventArgs e)
        {
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                try
                {
                    //DB41
                    DB41 dB41 = new DB41();

                    var dB41Result = dB41.Get();

                    LabelInstantAkm.Text = dB41Result.Akm + " mg/l";
                    LabelInstantCozunmusOksijen.Text = dB41Result.CozunmusOksijen + " mg/l";
                    LabelInstantSicaklik.Text = dB41Result.KabinSicaklik + "°C";
                    LabelInstantPh.Text = dB41Result.Ph.ToString();
                    LabelInstantIletkenlik.Text = dB41Result.Iletkenlik + " mS/cm";
                    LabelInstantKoi.Text = dB41Result.Koi + " mg/l";
                    LabelInstantAkisHizi.Text = dB41Result.NumuneHiz + " m/s";
                    LabelInstantDebi.Text = dB41Result.TesisDebi + " m³/d";
                    LabelInstantDesarjDebi.Text = dB41Result.DesarjDebi + " m³/d";
                    LabelInstantHariciDebi.Text = dB41Result.HariciDebi + " m³/d";
                    LabelInstantHariciDebi2.Text = dB41Result.HariciDebi2 + " m³/d";

                    //DB4
                    DB4 dB4 = new DB4();

                    var dB4Result = dB4.Get();

                    LabelSystemTime.Text = dB4Result.SystemTime.ToString();
                }
                catch (Exception)
                {
                    //TODO
                }
            };
            bgw.RunWorkerAsync();
        }
    }
}
