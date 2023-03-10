using API.Models;
using PLC.Services;
using Presentation;
using System;
using System.Configuration;

namespace API.Service
{
    public class SendDataService
    {
        readonly string Stationid = ConfigurationManager.AppSettings["Stationid"];
        readonly string SoftwareVersion = ConfigurationManager.AppSettings["SoftwareVersion"];
        public SendData GenerateSendData(PlcServices plcServices)
        {
            ModsService modsService = new ModsService();
            int status = modsService.GetStatus();

            SendData sendData = new SendData
            {
                Stationid = new Guid("9f3950ef-147a-46a5-ae5c-cb3c5028d829"),
                Readtime = plcServices.dB4DTO.SystemTime,
                SoftwareVersion = "1.0.0",
                Period = 1,
                AkisHizi = plcServices.dB41DTO.NumuneHiz,
                AkisHizi_Status = status,
                AKM = plcServices.dB41DTO.Akm,
                AKM_Status = status,
                CozunmusOksijen = plcServices.dB41DTO.CozunmusOksijen,
                CozunmusOksijen_Status = status,
                Debi = plcServices.dB41DTO.TesisDebi,
                Debi_Status = status,
                DesarjDebi = plcServices.dB41DTO.DesarjDebi,
                DesarjDebi_Status = status,
                HariciDebi = plcServices.dB41DTO.HariciDebi,
                HariciDebi_Status = status,
                HariciDebi2 = plcServices.dB41DTO.HariciDebi2,
                HariciDebi2_Status = status,
                KOi = plcServices.dB41DTO.Koi,
                KOi_Status = status,
                pH = plcServices.dB41DTO.Ph,
                pH_Status = status,
                Sicaklik = plcServices.dB41DTO.KabinSicaklik,
                Sicaklik_Status = status,
                Iletkenlik = plcServices.dB41DTO.Iletkenlik,
                Iletkenlik_Status = status
            };
            return sendData;
        }
    }
}
