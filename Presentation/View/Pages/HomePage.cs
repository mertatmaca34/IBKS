using Business.Interfaces;
using Business.Services;
using Newtonsoft.Json;
using Presentation.Controller;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using API.Models;
using API.Service;
using System.Configuration;
using System.Threading.Tasks;
using System.Threading;

namespace Presentation.View.Pages
{
    public partial class HomePage : Form
    {
        private protected APIService ApiService { get; set; }
        readonly PlcServices connection = PlcServices.Instance;
        private readonly IMinuteDataSendService minuteDataSendService = new MinuteDataSendService();
        private DateTime lastMinute;

        readonly string userName = ConfigurationManager.AppSettings["UserName"];
        readonly string password = ConfigurationManager.AppSettings["Password"];

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

            //API Bağlantısı
            this.ApiService = new APIService("https://entegrationsais.csb.gov.tr/", StationType.SAIS);
        }

        private void TimerReadPLC_Tick(object sender, EventArgs e)
        {
            //PLC Okuma ve Atama işlemlerinin arkaplanda yapılması.
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                if(connection?.dB4DTO?.SystemTime != null)
                {
                    //DB4 Okuma ve Label'a atama (Sistem Saati)
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

                        //API ile veri gönder
                        var loginResult = ApiService.Login(userName, password);

                        if (loginResult?.result == false)
                        {
                            //TODO
                        }
                        else
                        {
                            SendDataService sendDataService = new SendDataService();

                            var data = sendDataService.GenerateSendData(connection);
                            var res = ApiService.SendData(data);

                            if (res?.result == false)
                            {
                                MessageBox.Show("Sebep: " + res.message);
                                //TODO
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    //TODO
                    return;
                }
            };
            bgw.RunWorkerAsync();
        }
    }
}
