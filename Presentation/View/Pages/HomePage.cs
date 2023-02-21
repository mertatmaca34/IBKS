using PLC.Models;
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

            connection.Connect("10.33.1.253", 0, 1);
        }

        private void TimerReadPLC_Tick(object sender, EventArgs e)
        {
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                //DB41
                byte[] buffer41 = connection.ReadData(41, 0, 248);

                DB41DTO dB41 = connection.AssignDB41(buffer41);

                LabelInstantAkm.Text = dB41.Akm + " mg/l";
                LabelInstantCozunmusOksijen.Text = dB41.CozunmusOksijen + " mg/l";
                LabelInstantSicaklik.Text = dB41.KabinSicaklik + "°C";
                LabelInstantPh.Text = dB41.Ph.ToString();
                LabelInstantIletkenlik.Text = dB41.Iletkenlik + " mS/cm";
                LabelInstantKoi.Text = dB41.Koi + " mg/l";
                LabelInstantDebi.Text = dB41.NumuneHiz + " m/s";
                LabelInstantAkisHizi.Text = dB41.TesisDebi + " m³/d";
                LabelInstantDesarjDebi.Text = dB41.DesarjDebi + " m³/d";
                LabelInstantHariciDebi.Text = dB41.HariciDebi + " m³/d";
                LabelInstantHariciDebi2.Text = dB41.HariciDebi2 + " m³/d";

                //DB4
                byte[] buffer4 = connection.ReadData(4, 0, 12);

                DB4DTO dB4 = connection.AssignDB4(buffer4);

                LabelSystemTime.Text = "Sistem Saati:: " + dB4.SystemTime.ToString();
            };
            bgw.RunWorkerAsync();
        }

    }
}
