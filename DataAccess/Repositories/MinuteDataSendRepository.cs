using Data_Access.Contexts;
using Data_Access.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class MinuteDataSendRepository : IMinuteDataSendRepository
    {
        public void Add(MinuteDataSendDTO minuteDataSendDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                IBKSContext.minuteDataSendDTOs.Add(minuteDataSendDTO);
                IBKSContext.SaveChanges();
            }
        }

        public void Delete(MinuteDataSendDTO minuteDataSendDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                var dLog = IBKSContext.minuteDataSendDTOs.Find(minuteDataSendDTO.Readtime);

                IBKSContext.minuteDataSendDTOs.Add(minuteDataSendDTO);
                IBKSContext.SaveChanges();
            }
        }

        public List<MinuteDataSendDTO> GetAll()
        {
            List<MinuteDataSendDTO> minuteDataSendDTOs = new List<MinuteDataSendDTO>();
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                foreach (var item in IBKSContext.minuteDataSendDTOs)
                {
                    minuteDataSendDTOs.Add(item);
                }
                return minuteDataSendDTOs;
            }
        }

        public void Update(MinuteDataSendDTO minuteDataSendDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                var updateMinuteDataSendDTO = IBKSContext.minuteDataSendDTOs.Find(minuteDataSendDTO.Readtime);

                updateMinuteDataSendDTO.Readtime = minuteDataSendDTO.Readtime;
                updateMinuteDataSendDTO.AkisHizi = minuteDataSendDTO.AkisHizi;
                updateMinuteDataSendDTO.AkisHiziStatus = minuteDataSendDTO.AkisHiziStatus;
                updateMinuteDataSendDTO.AKM = minuteDataSendDTO.AKM;
                updateMinuteDataSendDTO.CozunmusOksijen = minuteDataSendDTO.CozunmusOksijen;
                updateMinuteDataSendDTO.Debi = minuteDataSendDTO.Debi;
                updateMinuteDataSendDTO.DebiStatus = minuteDataSendDTO.DebiStatus;
                updateMinuteDataSendDTO.DesarjDebi = minuteDataSendDTO.DesarjDebi;
                updateMinuteDataSendDTO.DesarjDebiStatus = minuteDataSendDTO.DesarjDebiStatus;
                updateMinuteDataSendDTO.HariciDebi = minuteDataSendDTO.HariciDebi;
                updateMinuteDataSendDTO.HariciDebiStatus = minuteDataSendDTO.HariciDebiStatus;
                updateMinuteDataSendDTO.HariciDebi2 = minuteDataSendDTO.HariciDebi2;
                updateMinuteDataSendDTO.HariciDebi2Status = minuteDataSendDTO.HariciDebi2Status;
                updateMinuteDataSendDTO.KOi = minuteDataSendDTO.KOi;
                updateMinuteDataSendDTO.KOiStatus = minuteDataSendDTO.KOiStatus;
                updateMinuteDataSendDTO.Ph = minuteDataSendDTO.Ph;
                updateMinuteDataSendDTO.PhStatus = minuteDataSendDTO.PhStatus;
                updateMinuteDataSendDTO.Sicaklik = minuteDataSendDTO.Sicaklik;
                updateMinuteDataSendDTO.SicaklikStatus = minuteDataSendDTO.SicaklikStatus;
                updateMinuteDataSendDTO.Iletkenlik = minuteDataSendDTO.Iletkenlik;
                updateMinuteDataSendDTO.IletkenlikStatus = minuteDataSendDTO.IletkenlikStatus;

                IBKSContext.SaveChanges();
            }
        }
    }
}
