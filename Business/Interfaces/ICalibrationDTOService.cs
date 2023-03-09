using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ICalibrationDTOService
    {
        List<CalibrationDTO> GetAll();
        void Add(CalibrationDTO calibrationDTO);
    }
}
