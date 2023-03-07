using Business.Interfaces;
using Data_Access.Models;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using PLC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MinuteDataSendService : IMinuteDataSendService
    {
        IMinuteDataSendRepository MinuteDataSendRepository = new MinuteDataSendRepository();
        public void Add(DB41DTO dB41DTO)
        {
            var minuteSendDataDTO = new MinuteDataSendDTO
            {
                Stationid = new Guid("75a6a184-06d9-4027-a506-0ed619588e18"),
                SoftwareVersion = "1.0.0",
                Readtime = DateTime.Now,
                Period = 1,
                AkisHizi = dB41DTO.NumuneHiz,
                AkisHiziStatus = 1,
                AKM = dB41DTO.Akm,
                AKMStatus = 1,
                CozunmusOksijen = dB41DTO.CozunmusOksijen,
                CozunmusOksijenStatus = 1,
                Debi = dB41DTO.TesisDebi,
                DebiStatus = 1,
                DesarjDebi = dB41DTO.DesarjDebi,
                DesarjDebiStatus = 1,
                HariciDebi = dB41DTO.HariciDebi,
                HariciDebiStatus = 1,
                HariciDebi2 = dB41DTO.HariciDebi2,
                HariciDebi2Status = 1,
                KOi = dB41DTO.Koi,
                KOiStatus = 1,
                Ph = dB41DTO.Ph,
                PhStatus = 1,
                Sicaklik = dB41DTO.KabinSicaklik,
                SicaklikStatus = 1,
                Iletkenlik = dB41DTO.Iletkenlik,
                IletkenlikStatus = 1
            };
            MinuteDataSendRepository.Add(minuteSendDataDTO);
        }
        public Array GetAll()
        {
            var minuteDataSendDTOs = MinuteDataSendRepository.GetAll();

            return minuteDataSendDTOs.ToArray();
        }
    }
}
