using PLC.Models;
using Presentation.Controller;
using System;
using System.ComponentModel;
using System.Drawing;
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

                //Coloring State Panels
                PanelInstantAkm.BackColor = ColorExtensions.FromDouble(dB41.Akm);
                PanelInstantCozunmusOksijen.BackColor = ColorExtensions.FromDouble(dB41.CozunmusOksijen);
                PanelInstantSicaklik.BackColor = ColorExtensions.FromDouble(dB41.KabinSicaklik);
                PanelInstantPh.BackColor = ColorExtensions.FromDouble(dB41.Ph);
                PanelInstantIletkenlik.BackColor = ColorExtensions.FromDouble(dB41.Iletkenlik);
                PanelInstantKoi.BackColor = ColorExtensions.FromDouble(dB41.Koi);
                PanelInstantDebi.BackColor = ColorExtensions.FromDouble(dB41.TesisDebi);
                PanelInstantAkisHizi.BackColor = ColorExtensions.FromDouble(dB41.NumuneHiz);
                PanelInstantDesarjDebi.BackColor = ColorExtensions.FromDouble(dB41.DesarjDebi);
                PanelInstantHariciDebi.BackColor = ColorExtensions.FromDouble(dB41.HariciDebi);
                PanelInstantHariciDebi2.BackColor = ColorExtensions.FromDouble(dB41.HariciDebi2);

                //DB4
                byte[] buffer4 = connection.ReadData(4, 0, 12);

                DB4DTO dB4 = connection.AssignDB4(buffer4);

                LabelSystemTime.Text = "Sistem Saati: " + dB4.SystemTime.ToString();

                //EB Tags
                byte[] bufferEBTags = connection.ReadData(0, 30);

                EBTagsDTO eBTagsDTO = connection.AssignEBTags(bufferEBTags);
                
                //Coloring State Panels
                PanelInstantKapi.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.Kapi);
                PanelInstantDuman.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.Duman);
                PanelInstantSuBaskini.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.SuBaskini);
                PanelInstantAcilStop.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.AcilStop);
                PanelInstantPompa1Termik.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.Pompa1Termik);
                PanelInstantPompa2Termik.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.Pompa2Termik);
                PanelInstantTemizSuPompaTermik.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.TemizSuTermik);
                PanelInstantYikamaTanki.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.YikamaTanki);
                PanelInstantEnerji.BackColor = ColorExtensions.FromBoolean(eBTagsDTO.Enerji);
            };
            bgw.RunWorkerAsync();
        }
    }
}
