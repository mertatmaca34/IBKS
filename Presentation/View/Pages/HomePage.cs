using Business.Interfaces;
using Business.Services;
using PLC.Models;
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
                byte[] buffer4 = connection.ReadData(4, 0, 12);

                DateTime systemTime;

                if (buffer4 != null)
                {
                    DB4DTO dB4 = connection.AssignDB4(buffer4);

                    LabelSystemTime.Text = "Sistem Saati: " + dB4.SystemTime.ToString();
                    systemTime = dB4.SystemTime;

                    #region EBTag'ları (bit değerler) Okuma
                    //EB Tags
                    byte[] bufferEBTags = connection.ReadData(0, 30);

                    EBTagsDTO eBTagsDTO = connection.AssignEBTags(bufferEBTags);
                    #endregion

                    #region EBTag'ların (bit'lerin) Durumlarını Gösteren Renklendirmeler
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
                    #endregion


                    #region DB41 Okuma/Atama
                    //DB41
                    byte[] buffer41 = connection.ReadData(41, 0, 248);

                    if (buffer41 != null)
                    {
                        DB41DTO dB41 = connection.AssignDB41(buffer41);

                        #region Değerlerin ekrana gösterimi
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
                        #endregion

                        #region DB41 Sensörlerinin Durumlarını Gösteren Renklendirmeler
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
                        #endregion

                        if (lastMinute.Minute != systemTime.Minute)
                        {
                            lastMinute = systemTime;
                            minuteDataSendService.Add(dB41);
                        }
                    }
                    #endregion
                }
                #endregion
            };
            bgw.RunWorkerAsync();
        }
    }
}
