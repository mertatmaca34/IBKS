using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICalibrationRepository
    {
        List<CalibrationDTO> GetAll();
        void Add(CalibrationDTO calibrationDTO);
        void Delete(CalibrationDTO calibrationDTO);
        void Update(CalibrationDTO calibrationDTO);
    }
}
