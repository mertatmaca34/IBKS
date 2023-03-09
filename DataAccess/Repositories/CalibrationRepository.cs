using Data_Access.Contexts;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class CalibrationRepository : ICalibrationRepository
    {
        public void Add(CalibrationDTO calibrationDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                IBKSContext.CalibrationDTOs.Add(calibrationDTO);
                IBKSContext.SaveChanges();
            }
        }

        public void Delete(CalibrationDTO calibrationDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                var dLog = IBKSContext.CalibrationDTOs.Find(calibrationDTO);

                IBKSContext.CalibrationDTOs.Add(calibrationDTO);
                IBKSContext.SaveChanges();
            }
        }

        public List<CalibrationDTO> GetAll()
        {
            List<CalibrationDTO> calibrationDTOs = new List<CalibrationDTO>();
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                foreach (var item in IBKSContext.CalibrationDTOs)
                {
                    calibrationDTOs.Add(item);
                }
                return calibrationDTOs;
            }
        }

        public void Update(CalibrationDTO calibrationDTO)
        {
            using (IBKSContext IBKSContext = new IBKSContext())
            {
                var updateCalibrationDTO = IBKSContext.CalibrationDTOs.Find(calibrationDTO.TimeStamp);

                updateCalibrationDTO.TimeStamp = calibrationDTO.TimeStamp;
                updateCalibrationDTO.ZeroRef = calibrationDTO.ZeroRef;
                updateCalibrationDTO.ZeroMeas = calibrationDTO.ZeroMeas;
                updateCalibrationDTO.ZeroStd = calibrationDTO.ZeroDiff;
                updateCalibrationDTO.SpanRef = calibrationDTO.SpanRef;
                updateCalibrationDTO.SpanMeas = calibrationDTO.SpanMeas;
                updateCalibrationDTO.SpanDiff = calibrationDTO.SpanDiff;
                updateCalibrationDTO.SpanStd = calibrationDTO.SpanStd;
                updateCalibrationDTO.ResultFactor = calibrationDTO.ResultFactor;
                updateCalibrationDTO.IsItValid = calibrationDTO.IsItValid;

                IBKSContext.SaveChanges();
            }
        }
    }
}
