using Business.Interfaces;
using Business.Services;
using Presentation.Controller;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation.View.Pages
{
    public partial class HomePage : Form
    {
        readonly PlcServices connection = PlcServices.Instance;
        private readonly IMinuteDataSendService minuteDataSendService = new MinuteDataSendService();
        DateTime lastMinute;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //Birden fazla thread kullanımı için yazılır.
            CheckForIllegalCrossThreadCalls = false;

            //PLC'ye connection sağlanır.
            connection.Connect("10.33.2.253", 0, 1);
        }

        private void TimerReadPLC_Tick(object sender, EventArgs e)
        {
            //PLC Okuma ve Atama işlemlerinin arkaplanda yapılması.
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                #region DB Okuma ve Label'lara atama (Sistem Saati)

                //DB4
                LabelSystemTime.Text = "Sistem Saati: " + connection.dB4DTO.SystemTime.ToString();

                #region EBTag'ların (bit'lerin) Durumlarını Gösteren Renklendirmeler
                //Coloring State Panels
                PanelInstantKapi.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.Kapi);
                PanelInstantDuman.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.Duman);
                PanelInstantSuBaskini.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.SuBaskini);
                PanelInstantAcilStop.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.AcilStop);
                PanelInstantPompa1Termik.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.Pompa1Termik);
                PanelInstantPompa2Termik.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.Pompa2Termik);
                PanelInstantTemizSuPompaTermik.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.TemizSuTermik);
                PanelInstantYikamaTanki.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.YikamaTanki);
                PanelInstantEnerji.BackColor = ColorExtensions.FromBoolean(connection.eBTagsDTO.Enerji);
                #endregion

                #region DB41 Atama
                //DB41

                #region Değerlerin ekrana gösterimi
                LabelInstantAkm.Text = connection.dB41DTO.Akm + " mg/l";
                LabelInstantCozunmusOksijen.Text = connection.dB41DTO.CozunmusOksijen + " mg/l";
                LabelInstantSicaklik.Text = connection.dB41DTO.KabinSicaklik + "°C";
                LabelInstantPh.Text = connection.dB41DTO.Ph.ToString();
                LabelInstantIletkenlik.Text = connection.dB41DTO.Iletkenlik + " mS/cm";
                LabelInstantKoi.Text = connection.dB41DTO.Koi + " mg/l";
                LabelInstantDebi.Text = connection.dB41DTO.NumuneHiz + " m/s";
                LabelInstantAkisHizi.Text = connection.dB41DTO.TesisDebi + " m³/d";
                LabelInstantDesarjDebi.Text = connection.dB41DTO.DesarjDebi + " m³/d";
                LabelInstantHariciDebi.Text = connection.dB41DTO.HariciDebi + " m³/d";
                LabelInstantHariciDebi2.Text = connection.dB41DTO.HariciDebi2 + " m³/d";
                #endregion

                #region Sensörlerinin Durumlarını Gösteren Renklendirmeler
                //Coloring State Panels
                PanelInstantAkm.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.Akm);
                PanelInstantCozunmusOksijen.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.CozunmusOksijen);
                PanelInstantSicaklik.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.KabinSicaklik);
                PanelInstantPh.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.Ph);
                PanelInstantIletkenlik.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.Iletkenlik);
                PanelInstantKoi.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.Koi);
                PanelInstantDebi.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.TesisDebi);
                PanelInstantAkisHizi.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.NumuneHiz);
                PanelInstantDesarjDebi.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.DesarjDebi);
                PanelInstantHariciDebi.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.HariciDebi);
                PanelInstantHariciDebi2.BackColor = ColorExtensions.FromDouble(connection.dB41DTO.HariciDebi2);
                #endregion

                if (lastMinute.Minute != connection.dB4DTO.SystemTime.Minute)
                {
                    lastMinute = connection.dB4DTO.SystemTime;
                    minuteDataSendService.Add(connection.dB41DTO);
                }
                #endregion

                #endregion
            };
            bgw.RunWorkerAsync();
        }
    }
}
