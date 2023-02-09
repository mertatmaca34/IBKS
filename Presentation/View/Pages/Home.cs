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
                DB41 dB41 = new DB41();

                var plcResult = dB41.Get();

                LabelInstantAkm.Text = plcResult.Akm.ToString();
                LabelInstantCozunmusOksijen.Text = plcResult.CozunmusOksijen.ToString();
                LabelInstantSicaklik.Text = plcResult.KabinSicaklik.ToString();
                LabelInstantPh.Text = plcResult.Ph.ToString();
                LabelInstantIletkenlik.Text = plcResult.Iletkenlik.ToString();
                LabelInstantKoi.Text = plcResult.Koi.ToString();
                LabelInstantAkisHizi.Text = plcResult.NumuneHiz.ToString();
                LabelInstantDebi.Text = plcResult.TesisDebi.ToString();
                LabelInstantDesarjDebi.Text = plcResult.DesarjDebi.ToString();
                LabelInstantHariciDebi.Text = plcResult.HariciDebi.ToString();
                LabelInstantHariciDebi2.Text = plcResult.HariciDebi2.ToString();
            };
            bgw.RunWorkerAsync();
        }
    }
}
